USE [StockDB]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pro_get_supply_info]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[pro_get_supply_info]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[pro_get_supply_info] 

AS
BEGIN
	SET NOCOUNT ON;
	
	select top 1 c as product_code ,A as product_name ,1 as quantity from 
	(
		select '00001A' AS A,'雪茄龙' AS B,1 as c
		union ALL 
		select '00005A' AS A,'硬盒骆驼'AS B,2 as c
		union ALL 
		select '00001A' AS A,'雪茄龙' AS B,3 as c
		union ALL 
		select '00005A' AS A,'硬盒骆驼'AS B,4 as c
		union ALL 
		select '00005A' AS A,'硬盒骆驼'AS B,5 as c
		union ALL 
		select '00005A' AS A,'硬盒骆驼'AS B,6 as c
		union ALL 
		select '00005A' AS A,'硬盒骆驼'AS B,7 as c
		union ALL 
		select '00005A' AS A,'硬盒骆驼'AS B,8 as c
		union ALL 
		select '00005A' AS A,'硬盒骆驼'AS B,9 as c
		union ALL 
		select '00005A' AS A,'硬盒骆驼'AS B,10 as c
		union ALL 
		select '00005A' AS A,'硬盒骆驼'AS B,11 as c
		union ALL 
		select '00005A' AS A,'硬盒骆驼'AS B,12 as c
	) a
	left join AS_STATEMANAGER_ORDER b on b.STATECODE = '02'
	where c > b.ROW_INDEX

	--declare @order cursor
	--declare @product_code nvarchar(20)
	--declare @product_code_temp nvarchar(20)
	--declare @quantity int

	--set @order = cursor for
	--	select CIGARETTECODE from V_STATE_ORDER02 a
	--	left join dbo.AS_STATEMANAGER_ORDER b on b.STATECODE = '02'
	--	where a.ROW_INDEX > b.ROW_INDEX

	--set @product_code = ''
	--set @product_code_temp = ''
	--set @quantity = 0

	--open @order
	--fetch next from @order into @product_code_temp
	--while(@@fetch_status=0)
	--begin
	--	if(@product_code = '')
	--	begin
	--		set @product_code = @product_code_temp
	--	end
	--	if(@product_code = @product_code_temp)
	--	begin
	--		set @quantity = @quantity + 1
	--	end
	--	else
	--	begin
	--		break 
	--	end
	--	fetch next from @order into @product_code_temp
	--end
	--close @order
	--deallocate @order
	--select @product_code,@quantity
END
GO

