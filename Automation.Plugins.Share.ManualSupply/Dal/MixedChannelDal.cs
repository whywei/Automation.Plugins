using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;

namespace Automation.Plugins.Share.ManualSupply.Dal
{
    public class MixedChannelDal : AbstractBaseDal
    {
        public DataTable GetMixedChannel(string channel_code)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select distinct a.supply_id ,a.supply_batch ,a.pack_no ,
                                        c.deliver_line_name,c.customer_name,
                                        a.channel_code ,
                                        b.channel_name,
                                        a.product_code,
                                        a.product_name ,
                                        a.quantity,
                                        case when a.status = 1 then '已补货' else '未补货' end status,
                                        case when d.status = 1 then '已下单' else '未下单' end xStatus 
                                        from handle_supply a 
                                        left join channel_allot b on a.channel_code = b.channel_code 
                                        left join dbo.sort_order_allot_master c on a.pack_no=c.pack_no
                                        left join (select * from (SELECT pack_no,status,row_number() over(partition by pack_no order by pack_no) rk from dbo.sorting) t  
                                        where rk = 1) d on a.pack_no=d.pack_no
                                        where a.channel_code='{0}'
                                        order by a.supply_id,a.quantity desc", channel_code);
            return ra.DoQuery(sql).Tables[0];
        }

        public DataTable GetAllMixedChannel()
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select distinct a.supply_id ,a.supply_batch ,a.pack_no ,
                                        c.deliver_line_name,c.customer_name,
                                        a.channel_code ,
                                        b.channel_name,
                                        a.product_code,
                                        a.product_name,
                                        a.quantity,
                                        case when a.status = 1 then '已补货' else '未补货' end status,
                                        case when d.status = 1 then '已下单' else '未下单' end xStatus 
                                        from handle_supply a 
                                        left join channel_allot b on a.channel_code = b.channel_code 
                                        left join dbo.sort_order_allot_master c on a.pack_no=c.pack_no
                                        left join (select * from (SELECT pack_no,status,row_number() over(partition by pack_no order by pack_no) rk from dbo.sorting) t  
                                        where rk = 1) d on a.pack_no=d.pack_no
                                        order by a.supply_id,a.quantity desc");
            return ra.DoQuery(sql).Tables[0];
        }

        public DataTable FindMixedChannel()
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select a.channel_code ,b.channel_name
                                        from handle_supply a 
                                        left join channel_allot b on a.channel_code = b.channel_code 
                                        group by a.channel_code,b.channel_name
                                        order by a.channel_code ");
            return ra.DoQuery(sql).Tables[0];
        }

    }
}
