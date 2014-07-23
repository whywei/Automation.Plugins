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
        public DataTable FindMaster(string product_name)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = @"SELECT order_date,batch_no,dist_name,deliver_line_name,customer_code,customer_name,address,
                           customer_Info,sum(quantity) as quantity,
                           CASE STATUS WHEN '0' THEN '未下单' ELSE '已下单' END status 
                           FROM sort_db.dbo.sort_order_allot_master 
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
                                         FROM sort_order_allot_detail where pack_no in(select pack_no from sort_order_allot_master where customer_code='{0}')", customer_code);
            return ra.DoQuery(string.Format(sql)).Tables[0];
        }

        public DataTable FindProduct(string product_name, string quantity)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = "";
            if (quantity!="")
                sql=string.Format(@"SELECT order_date,batch_no,dist_name,deliver_line_name,customer_code,customer_name,address,
                           customer_Info,sum(a.quantity) as quantity,
                           CASE STATUS WHEN '0' THEN '未下单' ELSE '已下单' END status  
                           FROM sort_db.dbo.sort_order_allot_master a left join dbo.sort_order_allot_detail b on a.pack_no=b.pack_no
                           where product_name='{0}'and b.quantity='{1}'
                           group by customer_code ,order_date,batch_no,dist_name,deliver_line_name,customer_code,
                           customer_name,address,customer_Info,status", product_name, quantity);
            else
                sql = string.Format(@"SELECT order_date,batch_no,dist_name,deliver_line_name,customer_code,customer_name,address,
                           customer_Info,sum(a.quantity) as quantity,
                           CASE STATUS WHEN '0' THEN '未下单' ELSE '已下单' END status  
                           FROM sort_db.dbo.sort_order_allot_master a left join dbo.sort_order_allot_detail b on a.pack_no=b.pack_no
                           where product_name='{0}'
                           group by customer_code ,order_date,batch_no,dist_name,deliver_line_name,customer_code,
                           customer_name,address,customer_Info,status", product_name, quantity);
            return ra.DoQuery(string.Format(sql)).Tables[0];
        }

        public string[] GetProduct()
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = "select distinct product_name from sort_order_allot_detail ";
            DataTable dt = ra.DoQuery(sql).Tables[0];
            string[] array = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                array[i] = Convert.ToString(dr["product_name"]);
            }
            return array;
        }
    }
}