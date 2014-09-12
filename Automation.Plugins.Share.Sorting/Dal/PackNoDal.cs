using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBRabbit;

namespace Automation.Plugins.Share.Sorting.Dal
{
    public class PackNoDal : AbstractBaseDal
    {

        /// <summary>
        /// 烟包查询
        /// </summary>
        /// <returns>烟包查询</returns>
        public DataTable FindMaster()
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"select order_date,batch_no,line_code,pack_no,order_id,dist_code ,dist_name,deliver_line_code
                  ,deliver_line_name,customer_code ,customer_name,license_no,address,customer_order,customer_deliver_order 
                  ,customer_info,quantity as mquantity,export_no,start_time ,finish_time
                  ,case status when '01' then '未下单' else '已下单' end status
                  from sort_order_allot_master";
            return ra.DoQuery(string.Format(sql)).Tables[0];
        }

        /// <summary>
        /// 烟包查询
        /// </summary>
        /// <returns>烟包查询</returns>
        public DataTable FindDetail(string pack_no)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = string.Format(@"select a.pack_no,c.order_id,a.channel_code,a.product_code,a.product_name
                  ,a.quantity as dquantity,case when b.group_no=1 then 'A线' else 'B线' end  channelline ,b.channel_name 
                  ,channel_type=case b.channel_type when '1'then '立式机（人工）' when '2'then '立式机（自动）' when '3'then '通道机' when '4' then '卧式机' when '5' then '混合道' end
                  ,b.sort_address
                  from sort_order_allot_detail a left join channel_allot b on a.channel_code=b.channel_code and a.product_code=b.product_code
                  left join sort_order_allot_master c on a.pack_no=c.pack_no
                  where a.pack_no={0}", pack_no);
            return ra.DoQuery(string.Format(sql)).Tables[0];
        }
    }
}
