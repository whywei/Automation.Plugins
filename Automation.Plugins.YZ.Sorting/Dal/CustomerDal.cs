using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBRabbit;

namespace Automation.Plugins.YZ.Sorting.Dal
{
    public class CustomerDal : AbstractBaseDal
    {

        /// <summary>
        /// 客户查询
        /// </summary>
        /// <returns>客户查询</returns>
        public DataTable FindMaster()
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = @"SELECT order_date,batch_no,dist_name,deliver_line_name,customer_code,customer_name,address,
                           customer_Info,sum(quantity) as quantity,status FROM sort_db.dbo.sort_order_allot_master 
                           group by customer_code ,order_date,batch_no,dist_name,deliver_line_name,customer_code,
                           customer_name,address,customer_Info,status";
            return ra.DoQuery(string.Format(sql)).Tables[0];
        }

        /// <summary>
        /// 客户查询
        /// </summary>
        /// <returns>客户查询</returns>
        public DataTable FindDetail(string customer_code)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"SELECT pack_no,channel_code,product_code,product_name,quantity
                                         FROM sort_order_allot_detail where pack_no in(select pack_no from sort_order_allot_master where customer_code={0})", customer_code);
            return ra.DoQuery(string.Format(sql)).Tables[0];
        }


    }
}