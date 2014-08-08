using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;

namespace Automation.Plugins.YZ.ManualSupply.Dal
{
    public class ProductCheckDal : AbstractBaseDal
    {
        public DataTable GetProductCheck(string product_name)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string condition = null;
            if (string.IsNullOrEmpty(product_name))
            {
                condition = null;
            }
            else
            {
                condition = "where product_name = '" + product_name + "'";
            }
            string sql = string.Format(@"select a.supply_id,a.supply_batch,a.pack_no,a.channel_code,a.product_code
                                        ,a.product_name,a.quantity,b.channel_name
                                        ,case when a.status = 1 then '已补货' else '未补货' end status 
                                        from handle_supply a 
                                        left join channel_allot b on a.channel_code = b.channel_code AND a.product_code=b.product_code
                                        order by a.supply_id, a.quantity desc", condition);
            return ra.DoQuery(sql).Tables[0];
        }
    }
}