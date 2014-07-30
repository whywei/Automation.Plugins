using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBRabbit;

namespace Automation.Plugins.YZ.Sorting.Dal
{
    public class PackNoDal : AbstractBaseDal
    {

        /// <summary>
        /// 烟包查询
        /// </summary>
        /// <returns>烟包查询</returns>
        public DataTable FindMaster()
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = @"SELECT order_date
      ,batch_no
      ,line_code
      ,pack_no
      ,order_id
      ,dist_code
      ,dist_name
      ,deliver_line_code
      ,deliver_line_name
      ,customer_code
      ,customer_name
      ,license_no
      ,address
      ,customer_order
      ,customer_deliver_order
      ,customer_Info
      ,quantity as mquantity
      ,export_no
      ,start_time
      ,finish_time
      ,CASE STATUS WHEN '01' THEN '未下单' ELSE '已下单' END status
      FROM sort_order_allot_master";
            return ra.DoQuery(string.Format(sql)).Tables[0];
        }

        /// <summary>
        /// 烟包查询
        /// </summary>
        /// <returns>烟包查询</returns>
        public DataTable FindDetail(string pack_no)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"SELECT A.pack_no
      ,C.order_id
      ,A.channel_code
      ,A.product_code
      ,A.product_name
      ,A.quantity as dquantity
      ,CASE WHEN B.group_no=1 THEN 'A线' ELSE 'B线' END  channelline
      ,B.channel_name 
      ,channel_type=CASE B.channel_type WHEN '1'THEN '立式机（人工）' WHEN '2'THEN '立式机（自动）' WHEN '3'THEN '通道机' WHEN '4' THEN '卧式机' WHEN '5' THEN '混合道' END
      ,B.sort_address
      FROM sort_order_allot_detail A LEFT JOIN Channel_Allot B ON A.channel_code=B.channel_code AND A.product_code=B.product_code
      LEFT JOIN sort_order_allot_master C ON A.pack_no=C.pack_no
      where A.pack_no={0}", pack_no);
            return ra.DoQuery(string.Format(sql)).Tables[0];
        }


    }
}
