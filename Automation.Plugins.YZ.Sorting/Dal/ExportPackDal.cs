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
    }
}
