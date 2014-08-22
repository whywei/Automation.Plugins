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

        public DataTable FindUnStockTask()
        {
            var ra = TransactionScopeManager[Global.yzServiceName].NewRelationAccesser();
            string sql = @"select top 25 id,product_code,product_barcode,origin_position_address,target_supply_address,status,0 as storageId
                        from sms_supply_task where status='0' order by supply_id";
            return ra.DoQuery(sql).Tables[0];
        }

        public void UpdateSupplyTask(string id, string originPositionAddress)
        {
            var ra = TransactionScopeManager[Global.yzServiceName].NewRelationAccesser();
            string sql = @"update dbo.sms_supply_task set origin_position_address='{0}',status='1' where id={1}";
            ra.DoCommand(string.Format(sql, originPositionAddress, id));
        }

        public DataTable FindSupplyTaskForLED(int originPositionAddress,int quantity)
        {
            string condition="";
            if (originPositionAddress > 0)
            {
                condition = string.Format("and origin_position_address={0} ", originPositionAddress);
            }
            var ra = TransactionScopeManager[Global.yzServiceName].NewRelationAccesser();
            string sql = @"select top {1} supply_id,product_code,product_name from sms_supply_task
                        where status='1' {0} order by supply_id desc";
            return ra.DoQuery(string.Format(sql, condition, quantity)).Tables[0];
        }
    }
}
