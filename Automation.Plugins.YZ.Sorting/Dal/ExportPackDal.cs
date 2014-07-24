using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;

namespace Automation.Plugins.YZ.Sorting.Dal
{
    public class ExportPackDal: AbstractBaseDal
    {
        public DataTable FindExportPack()
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = @"SELECT id,pack_no,total_quantity,bag_quantity,quantity,export_no,order_date
                      ,batch_no,line_code,order_id,deliver_line_code,deliver_line_name,customer_code
                      ,customer_name,address,customer_order,customer_Info,product_code,product_name
                      ,CASE status WHEN '0' THEN '未读取' ELSE '已读取' END status
                      FROM export_pack ORDER BY pack_no,id";
            return ra.DoQuery(sql).Tables[0];
        }

        public void InsertIntoExportPack(DataRow row)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = @"INSERT INTO export_pack VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','0')";
            sql = string.Format(sql, row["pack_no"].ToString().Trim(), row["total_quantity"].ToString().Trim()
                , row["bag_quantity"].ToString().Trim(), row["quantity"].ToString().Trim(), row["export_no"].ToString().Trim()
                , row["order_date"].ToString().Trim(), row["batch_no"].ToString().Trim(), row["line_code"].ToString().Trim()
                , row["order_id"].ToString().Trim(), row["deliver_line_code"].ToString().Trim(), row["deliver_line_name"].ToString().Trim()
                , row["customer_code"].ToString().Trim(), row["customer_name"].ToString().Trim(), row["address"].ToString().Trim()
                , row["customer_order"].ToString().Trim(), row["customer_deliver_order"].ToString().Trim(), row["customer_Info"].ToString().Trim()
                , row["product_code"].ToString().Trim(), row["product_name"].ToString().Trim());
            ra.DoQuery(sql);
        }
    }
}
