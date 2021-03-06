﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBRabbit;
using Automation.Core;

namespace Automation.Plugins.Share.Sorting.Dal
{
    public class CustomerDal : AbstractBaseDal
    {
        /// <summary>
        /// 客户查询
        /// </summary>
        /// <returns>客户查询</returns>
        public DataTable FindMaster()
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"select order_date,batch_no,min(pack_no) pack_no,dist_name,deliver_line_name,customer_code,customer_name,address,
                           customer_info,sum(quantity) as quantity,customer_order,customer_deliver_order,
                           case status when '01' then '未下单' else '已下单' end status 
                           from sort_order_allot_master 
                           group by customer_code ,order_date,batch_no,dist_name,deliver_line_name,customer_code,
                           customer_name,address,customer_info,status,customer_order,customer_deliver_order
                           order by pack_no asc";
            return ra.DoQuery(sql).Tables[0];
        }

        /// <summary>
        /// 客户查询
        /// </summary>
        /// <returns>客户查询</returns>
        public DataTable FindDetail(string customer_code)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = string.Format(@"select a.pack_no,a.channel_code,a.product_code,a.product_name,a.quantity,b.channel_name 
                                         ,channel_type=case b.channel_type when '1'then '立式机（人工）' when '2'then '立式机（自动）' when '3'then '通道机' when '4' then '卧式机' when '5' then '混合道' end
                                         from sort_order_allot_detail a left join channel_allot b on a.channel_code=b.channel_code and a.product_code=b.product_code
                                         where a.pack_no in(select pack_no from sort_order_allot_master where customer_code='{0}')", customer_code);
            return ra.DoQuery(string.Format(sql)).Tables[0];
        }

        public DataTable FindProduct(string product_name, string quantity)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = "";
            if (quantity!="")
                sql = string.Format(@"select order_date,batch_no,min(pack_no) pack_no,dist_name,deliver_line_name,customer_code,customer_name,
                            address,customer_info,sum(quantity) as quantity,customer_order,customer_deliver_order,
                            case status when '01' then '未下单' else '已下单' end status  
                            from sort_db.dbo.sort_order_allot_master 
                            where customer_code in (select customer_code
                            from sort_order_allot_master a left join sort_order_allot_detail b on a.pack_no=b.pack_no
                            where product_name='{0}' 
                            group by customer_code,product_name having sum(b.quantity)='{1}')
                            group by customer_code ,order_date,batch_no,dist_name,deliver_line_name,customer_code,
                            customer_name,address,customer_info,status,customer_order,customer_deliver_order order by pack_no asc", product_name, quantity);
            else
                sql = string.Format(@"select order_date,batch_no,min(pack_no) pack_no,dist_name,deliver_line_name,customer_code,customer_name,address,
                            customer_info,sum(quantity) as quantity,customer_order,customer_deliver_order,
                            case status when '01' then '未下单' else '已下单' end status  
                            from sort_db.dbo.sort_order_allot_master 
                            where customer_code in (
                            select customer_code 
                            from sort_db.dbo.sort_order_allot_master a left join dbo.sort_order_allot_detail b on a.pack_no=b.pack_no
                            where product_name='{0}')
                            group by customer_code ,order_date,batch_no,dist_name,deliver_line_name,customer_code,
                            customer_name,address,customer_info,status,customer_order,customer_deliver_order order by pack_no asc", product_name, quantity);
            return ra.DoQuery(sql).Tables[0];
        }

        public string[] GetProduct()
        {
            //try
            //{
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
                string sql = "select distinct product_name from sort_order_allot_detail ";
                DataTable dt = ra.DoQuery(sql).Tables[0];
                string[] array = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    array[i] = Convert.ToString(dr["product_name"]);
                }
                return array;
            //}
            //catch (Exception e)
            //{
            //    Logger.Error(e.Message);
            //    return null;
            //}
        }
    }
}