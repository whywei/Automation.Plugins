using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;

namespace Automation.Plugins.Share.ManualSupply.Dal
{
    public class ProductCheckDal : AbstractBaseDal
    {
        public DataTable GetProductCheck()
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select c.line_code,a.product_code,a.product_name,sum(a.quantity) as quantity
                                        ,isnull(stockquantity,0) as stockquantity
                                        ,(sum(a.quantity)-isnull(stockquantity,0)) as remainquantity
                                        ,c.order_date
                                        from handle_supply  a left join (
                                        select product_code,isnull(sum(quantity),0) as stockquantity from handle_supply 
                                        where status='1' group by product_code) b on a.product_code=b.product_code
                                        left join dbo.sort_order_allot_master c on a.pack_no=c.pack_no
                                        group by c.line_code,a.product_code,a.product_name,stockquantity,c.order_date
                                        order by c.line_code");
            return ra.DoQuery(sql).Tables[0];
        }
    }
}