using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;

namespace Automation.Plugins.YZ.Stocking.Dal
{
    public class StockTaskDal : AbstractBaseDal
    {
        public void UpdateBarcode(string productCode, string barcode)
        {
            var ra = TransactionScopeManager[Global.yzServiceName].NewRelationAccesser();
            string sql = @"update sms_supply_task set product_barcode='{0}' where product_code='{1}'";
            ra.DoCommand(string.Format(sql, barcode, productCode));
        }

        public DataTable FindStockTaskStorage()
        {
            var ra = TransactionScopeManager[Global.yzServiceName].NewRelationAccesser();
            string sql = @"SELECT [id]
                      ,[supply_id]
                      ,[pack_no]
                      ,[sorting_line_code]
                      ,[group_no]
                      ,[channel_code]
                      ,[channel_name]
                      ,[product_code]
                      ,[product_name]
                      ,[product_barcode]
                      ,[origin_position_address]
                      ,[target_supply_address]
                      ,case [status]  when '1' then '已下单' else  '未下单' end [status] FROM [sms_supply_task]";
            return ra.DoQuery(sql).Tables[0];
        }
    }
}
