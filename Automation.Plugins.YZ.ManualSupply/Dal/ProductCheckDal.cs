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
        public DataTable GetProductCheck()
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select supply_batch ,a.product_code,a.product_name,sum(quantity) as quantity,
                                        isnull(stockquantity,0) as stockquantity,(sum(quantity)-isnull(stockquantity,0)) as remainquantity
                                        from handle_supply  a left join (
                                        select product_code,isnull(sum(quantity),0) as stockquantity from handle_supply 
                                        where status='1' group by supply_batch,product_code) b on a.product_code=b.product_code
                                        group by supply_batch,a.product_code,a.product_name,stockquantity
                                        order by supply_batch");
            return ra.DoQuery(sql).Tables[0];
        }
    }
}