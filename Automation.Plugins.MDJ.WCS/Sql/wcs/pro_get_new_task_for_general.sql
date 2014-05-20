USE [wms_rfid_db]
GO
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[pro_get_new_task_for_general] 
	@srm_name  nvarchar(50),
	@travelPos int,
	@waitingTask int,
	@waitingTasks nvarchar(4000),
	@product_code nvarchar(20)
AS
	declare @id int
		
	declare @task_type char(2)
	declare @target_position_id int
	declare @target_position_type char(2)
		
	declare @new_task cursor	
	declare @next_position_id int
BEGIN	
	SET NOCOUNT ON;
	
	set @new_task = cursor for
		select top 1 a.id,a.task_type,a.target_position_id,d.position_type
		from wcs_task a
			left join wcs_position b on b.id = a.origin_position_id   --起始位置
			left join wcs_position c on c.id = a.current_position_id  --当前位置
			left join wcs_position d on d.id = a.target_position_id   --目标位置
		where a.[state] = '01'			 			/*任务等待中*/
			and a.current_position_state = '02'		/*已到达当前位置*/
			and c.able_stock_out = 1				/*当前位置可以出库*/
			and a.current_position_id <> a.target_position_id
			and c.srmName = @srm_name				/*当前位置为当前堆垛机执行*/
			and (d.position_type = '01'				/*目标位置是正常位置*/
				or (d.position_type = '02'			/*或者目标位置是大品种拆盘位置*/
					and d.has_goods = 0)				/*位置状态须为空，无货*/
				or d.position_type='05'				/*或者目标位置是空托盘拆垛位置*/
				or (d.position_type = '06'			/*或者目标位置是出库位置*/
					and d.has_goods = 0					/*位置状态须为空，无货*/
					and (select count(*) from wcs_task t1
							left join wcs_position t2 on t1.target_position_id = t2.id
						 where t1.state != '04'
							and t2.position_type = '06'
							and (t1.state = '02' or t1.current_position_id <> origin_position_id)
						) = 0)
				or (d.position_type = '03'
					and (a.current_position_id <> a.origin_position_id 
						or (select count(*) from wcs_task t1
								left join wcs_position t2 on t1.target_position_id = t2.id
								where t1.state != '04' 
								and t2.position_type = '03'
								and (t1.state ='02' or current_position_id in (select position_id from wcs_path_node where path_id = a.path_id))
							) <
							(select count(*) from wcs_position
								where position_type = '03'/*小品种出库位置*/
									and has_goods = 0) 
						)
					)
				or (d.position_type = '04' 
					and (a.current_position_id <> a.origin_position_id 
						or (select count(*) from wcs_task t1
								left join wcs_position t2 on t1.target_position_id = t2.id
								where t1.state != '04'
								and t2.position_type = '04'	
								and (t1.state ='02' or current_position_id in (select position_id from wcs_path_node where path_id = a.path_id))
							) <
							(select count(*) from wcs_position
									where position_type = '04'/*异型烟出库位置*/
										and has_goods = 0) 
						)
					)
				)
			and (@waitingTask = 0 or @waitingTask = a.id )
			and (@waitingTasks = '' or CHARINDEX(CONVERT(varchar, a.id),@waitingTasks) = 0)
			and (a.storage_sequence  
				= (select isNull(min(storage_sequence),0) from wms_storage
					where quantity > 0 and cell_code = a.origin_cell_code)
				or a.order_type = '00'
				or a.order_type = '01'
				or a.order_type = '05' 
				or a.order_type = '06' 
				or a.order_type = '07' 
				or a.order_type = '08'
				or a.order_type = '09')
			and (a.current_position_id = a.origin_position_id or a.current_position_id in (select position_id from wcs_path_node where path_id = a.path_id))
			and not ((c.position_type = '03'and d.position_type = '03') or (c.position_type = '04'and d.position_type = '04'))
		order by a.task_level desc ,				        /*根据优先级排序*/
			abs(c.travel_pos - @travelPos)					/*根据就近排序*/

	open @new_task
	fetch next from @new_task into @id,@task_type,@target_position_id,@target_position_type
	if(@@fetch_status=0)
	begin
		SET @next_position_id = (select top 1 id from (
                                    select b.id, b.position_name ,0 as path_node_order from wcs_task a
                                    left join wcs_position b on a.origin_position_id = b.id
                                    where a.id = @id
                                    union
                                    select c.id, c.position_name ,b.path_node_order  from wcs_task a
                                    left join wcs_path_node b on a.path_id = b.path_id
                                    left join wcs_position c on b.position_id = c.id
                                    where a.id= @id
                                    union
                                    select b.id,b.position_name ,10000 as path_node_order from wcs_task a
                                    left join wcs_position b on a.target_position_id = b.id
                                    where a.id = @id
                                ) t
                                where t.path_node_order > (select isnull(b.path_node_order,0) from wcs_task a
                                    left join wcs_path_node b on a.path_id = b.path_id and a.current_position_id = b.position_id
                                    where a.id= @id)
                                order by path_node_order )
		print @id
		print @next_position_id

		if(@next_position_id = @target_position_id and @task_type != '03')
		begin
			if(@target_position_type = '03')
			begin
				set @next_position_id = (select top 1 id from wcs_position
					where position_type = '03'/*小品种出库位置*/
						and has_goods = 0)
			end
			else if(@target_position_type = '04')
			begin
				set @next_position_id = (select top 1 id from wcs_position
					where position_type = '04'/*异型烟出库位置*/
						and has_goods = 0)
			end
		end

		select a.*,
			f.length,f.width,f.height,
			
			c.travel_pos as travelPos1,c.lift_pos as liftPos1,/*当前位置*/
			d.travel_pos as travelPos2,d.lift_pos as liftPos2,/*下个位置*/
			
			c.id as currentPositionID,                        --当前位置
			c.position_name as currentPositionName,
			c.position_type as currentPositionType,
			c.extension as currentPositionExtension,
			a.current_position_state as currentPositionState,
			c.has_get_request,
			
			d.id as nextPositionID,							  --下个位置					
			d.position_name as nextPositionName,
			d.position_type as nextPositionType,
			d.extension as nextPositionExtension,
			d.has_put_request,
			
			e.id as endPositionID,							  --目标位置	
			e.position_name as endPositionName,
			e.position_type as endPositionType     
		from wcs_task a
			left join wcs_position b on b.id = a.origin_position_id   --起始位置
			left join wcs_position c on c.id = a.current_position_id  --当前位置
			left join wcs_position d on d.id = @next_position_id	  --下个位置
			left join wcs_position e on e.id = a.target_position_id   --目标位置
			left join wcs_product_size	f on f.product_code = a.product_code
		where a.id = @id
			and a.[state] = '01'			 		/*任务等待中*/
			and a.current_position_state = '02'		/*已到达当前位置*/
			and c.able_stock_out = 1				/*当前位置可以出库*/
			and c.srmName = @srm_name				/*当前位置为当前堆垛机执行*/
			and d.srmName = @srm_name				/*下个位置为当前堆垛机执行*/
	end
	close @new_task
	deallocate @new_task
END