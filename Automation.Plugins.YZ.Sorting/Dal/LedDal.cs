using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;

namespace Automation.Plugins.YZ.Sorting.Dal
{
   public class LedDal:AbstractBaseDal
    {

        public DataTable FindMaster()
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = @"SELECT led_code,led_name,led_ip,xaxes,yaxes,width,height,led_group_code,order_no,           
           case [status] when '1' then '可用' else  '不可用' end status,
           case [led_type] when '1' then '整屏' else  '分屏' end led_type           
           FROM [sort_db].[dbo].[led] where led_group_code is null";
            return ra.DoQuery(sql).Tables[0];
        }


        public DataTable FindDetailByLedGroupNo(string led_code)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"SELECT led_code,led_name,led_ip,xaxes,yaxes,width,height,led_group_code,order_no,           
           case status when '1' then '可用' else '不可用' end status,
           case led_type when '1' then '整屏' else '分屏' end led_type           
           FROM led WHERE led_group_code ='{0}'", led_code);
            return ra.DoQuery(sql).Tables[0];
        }
    }
}
