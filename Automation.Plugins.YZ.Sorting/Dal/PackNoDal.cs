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
            string sql = @"SELECT order_date,batch_no,line_code,pack_no
      ,master_Id,order_id
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
      ,status
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
            string sql = string.Format(@"SELECT pack_no
      ,channel_code
      ,product_code
      ,product_name
      ,quantity as dquantity
  FROM sort_order_allot_detail where pack_no={0}", pack_no);
            return ra.DoQuery(string.Format(sql)).Tables[0];
        }


    }
}
