USE [StockDB]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pro_update_supply_info]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[pro_update_supply_info]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[pro_update_supply_info] 
	@product_code nvarchar(20),@quantity int
AS
BEGIN
	SET NOCOUNT ON;
	update AS_STATEMANAGER_ORDER set ROW_INDEX = ROW_INDEX + @quantity
	where STATECODE = '02'
END
GO

