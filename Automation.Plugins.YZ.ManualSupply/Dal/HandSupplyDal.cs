using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBRabbit;

namespace Automation.Plugins.YZ.ManualSupply.Dal
{
    public class HandSupplyDal : AbstractBaseDal
    {
        public DataTable GetHandSupplyBySupplyBatch(int supplyBatch)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select a.supply_id ,a.supply_batch ,a.pack_no ,a.channel_code ,a.product_code
                                        ,a.product_name ,a.quantity
                                        ,case when a.status = 1 then '已补货' else '未补货' end status 
                                        from handle_supply a 
                                        left join channel_allot b on a.channel_code = b.channel_code 
                                        where a.supply_batch='{0}' order by a.supply_id,a.quantity desc", supplyBatch);
            return ra.DoQuery(sql).Tables[0];
        }
    }
}
