using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;

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
    }
}
