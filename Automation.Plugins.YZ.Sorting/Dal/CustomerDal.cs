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
                           customer_name,address,customer_Info,status
                           order by dist_name asc";
            return ra.DoQuery(string.Format(sql)).Tables[0];
        }

        /// <summary>
        /// 客户查询
        /// </summary>
        /// <returns>客户查询</returns>
        public DataTable FindDetail(string customer_code)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"SELECT A.pack_no,A.channel_code,A.product_code,A.product_name,A.quantity,B.channel_name 
                                         ,channel_type=CASE B.channel_type WHEN '1'THEN '立式机（人工）' WHEN '2'THEN '立式机（自动）' WHEN '3'THEN '通道机' WHEN '4' THEN '卧式机' WHEN '5' THEN '混合道' END
                                         FROM sort_order_allot_detail A LEFT JOIN Channel_Allot B ON A.channel_code=B.channel_code
                                         where A.pack_no in(select pack_no from sort_order_allot_master where customer_code='{0}')", customer_code);
            return ra.DoQuery(string.Format(sql)).Tables[0];
        }

        public DataTable FindProduct(string product_name, string quantity)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = "";
            if (quantity!="")
                sql = string.Format(@"SELECT order_date,batch_no,dist_name,deliver_line_name,customer_code,customer_name,
                            address,customer_Info,sum(quantity) as quantity,
                            CASE STATUS WHEN '0' THEN '未下单' ELSE '已下单' END status  
                            FROM sort_db.dbo.sort_order_allot_master 
                            where customer_code in (select customer_code
                            FROM sort_db.dbo.sort_order_allot_master a left join dbo.sort_order_allot_detail b on a.pack_no=b.pack_no
                            where product_name='{0}' 
                            group by customer_code,product_name having sum(b.quantity)='{1}')
                            group by customer_code ,order_date,batch_no,dist_name,deliver_line_name,customer_code,
                            customer_name,address,customer_Info,status order by dist_name asc", product_name, quantity);
            else
                sql = string.Format(@"SELECT order_date,batch_no,dist_name,deliver_line_name,customer_code,customer_name,address,
                            customer_Info,sum(quantity) as quantity,
                            CASE STATUS WHEN '0' THEN '未下单' ELSE '已下单' END status  
                            FROM sort_db.dbo.sort_order_allot_master 
                            where customer_code in (
                            select customer_code 
                            from sort_db.dbo.sort_order_allot_master a left join dbo.sort_order_allot_detail b on a.pack_no=b.pack_no
                            where product_name='{0}')
                            group by customer_code ,order_date,batch_no,dist_name,deliver_line_name,customer_code,
                            customer_name,address,customer_Info,status order by dist_name asc", product_name, quantity);
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