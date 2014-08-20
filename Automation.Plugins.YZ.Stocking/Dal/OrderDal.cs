using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;

namespace Automation.Plugins.YZ.Stocking.Dal
{
    public class OrderDal : AbstractBaseDal
    {
        public DataTable FindProductFromOrder()
        {
            var ra = TransactionScopeManager[Global.yzServiceName].NewRelationAccesser();
            string sql = @"select distinct product_code,product_name from sms_sort_order_allot_detail order by product_name";
            return ra.DoQuery(sql).Tables[0];
        }
    }
}
