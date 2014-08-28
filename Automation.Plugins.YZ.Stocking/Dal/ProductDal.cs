using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;

namespace Automation.Plugins.YZ.Stocking.Dal
{
    public class ProductDal:AbstractBaseDal
    {
        public void UpdateBarcode(string productCode,string barcode)
        {
            var ra = TransactionScopeManager[Global.dataBaseServiceName].NewRelationAccesser();
            string sql = @"update wms_product set piece_barcode='{0}' where product_code='{1}'";
            ra.DoCommand(string.Format(sql, barcode, productCode));
        }
    }
}
