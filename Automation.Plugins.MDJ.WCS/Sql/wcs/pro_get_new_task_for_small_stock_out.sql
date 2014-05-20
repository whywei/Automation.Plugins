USE [wms_rfid_db]
GO
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[pro_get_new_task_for_small_stock_out] 
	@srm_name  nvarchar(50),
	@travelPos int,
	@waitingTask int,
	@waitingTasks nvarchar(4000),
	@product_code nvarchar(20)
AS
	declare @empty_position_id int
	
	declare @empty_position cursor
BEGIN	
	SET NOCOUNT ON;
	
	set @empty_position = cursor for
		select top 1 id from wcs_position
		where position_type = '03'    /*小品种出库位置*/
			and has_goods = 0
			and srmName = @srm_name   /*当前位置为当前堆垛机执行*/
	
	open @empty_position
	fetch next from @empty_position into @empty_position_id
	if(@@fetch_status=0)
	begin
		select top 1 a.*,
			f.length,f.width,f.height,
			
			c.travel_pos as travelPos1,c.lift_pos as liftPos1,/*当前位置*/
			d.travel_pos as travelPos2,d.lift_pos as liftPos2,/*下个位置*/
			
			c.id as currentPositionID,                        --当前位置
			c.position_name as currentPositionName,
			c.position_type as currentPositionType,
			c.extension as CurrentPositionExtension,
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
			left join wcs_position d on d.id = @empty_position_id	  --下个位置
			left join wcs_position e on e.id = a.target_position_id   --目标位置
			left join wcs_product_size	f on f.product_code = a.product_code
		where a.[state] = '01'			 			/*任务等待中*/
			and e.position_type != '03'				/*当前位置不是小品种出库位置*/
			and a.current_position_state = '02'		/*已到达当前位置*/
			and c.able_stock_out = 1				/*当前位置可以出库*/
			and c.srmName = @srm_name				/*当前位置为当前堆垛机执行*/
			and d.srmName = @srm_name				/*下个位置为当前堆垛机执行*/
			and e.position_type = '03'				/*目标位置是小品种出库位置*/
	end
	close @empty_position
	deallocate @empty_position	
END