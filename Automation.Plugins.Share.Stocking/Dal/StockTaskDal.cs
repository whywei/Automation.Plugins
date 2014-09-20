using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;

namespace Automation.Plugins.Share.Stocking.Dal
{
    public class StockTaskDal : AbstractBaseDal
    {
        public void UpdateBarcode(string productCode, string barcode)
        {
            var ra = TransactionScopeManager[Global.DATABASE_NAME].NewRelationAccesser();
            string sql = @"update sms_supply_task set product_barcode='{0}' where product_code='{1}'";
            ra.DoCommand(string.Format(sql, barcode, productCode));
        }

        public DataTable FindStockTask(string sql)
        {
            var ra = TransactionScopeManager[Global.DATABASE_NAME].NewRelationAccesser();
            sql = string.Format(@"select * from ({0}) a order by a.id asc", sql);
            return ra.DoQuery(sql).Tables[0];
        }

        public DataTable FindStockTaskForLED(string sql, int quantity)
        {
            var ra = TransactionScopeManager[Global.DATABASE_NAME].NewRelationAccesser();
            sql = string.Format(@"select top {0} * from ({1}) a where a.status='1' order by a.id desc", quantity, sql);
            return ra.DoQuery(sql).Tables[0];
        }

        public DataTable FindUnStockTask()
        {
            var ra = TransactionScopeManager[Global.DATABASE_NAME].NewRelationAccesser();
            string sql = @"select top 25 id,product_code,product_barcode,origin_position_address,target_supply_address,status
                            from sms_supply_task where status='0' order by id";
            return ra.DoQuery(sql).Tables[0];
        }

        public void UpdateStockTaskStatus(string id)
        {
            var ra = TransactionScopeManager[Global.DATABASE_NAME].NewRelationAccesser();
            string sql = @"update sms_supply_task set status='1' where id = {0}";
            ra.DoCommand(string.Format(sql, id));
        }
    }
}
