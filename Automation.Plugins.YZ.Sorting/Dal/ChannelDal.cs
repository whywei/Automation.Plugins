using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;
using Automation.Plugins.YZ.Sorting.Model;

namespace Automation.Plugins.YZ.Sorting.Dal
{
    public class ChannelDal : AbstractBaseDal
    {


        /// <summary>
        /// 查询烟道信息
        /// </summary>
        /// <returns>烟道信息表</returns>
        public DataTable FindSortChannel()
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = @"SELECT channel_code ,channel_name,product_code,product_name,quantity,
                           remain_quantity,channel_capacity,group_no,order_no,sort_address,supply_address,led_no,x,y,
                           width,height,case channel_type when '1' then '立式机(人工)' when '2' then '立式机(自动)' when '3' then '通道机'when '4' then '卧式机' else  '混合烟道' end channel_type,
                           case status when '1' then '可用' else  '不可用' end status FROM Channel_Allot";
            return ra.DoQuery(string.Format(sql)).Tables[0];
        }


      
        public void InsertChannel(DataTable channelTable)
        {

            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            ra.DoScalar("TRUNCATE TABLE Channel_Allot");
            
            foreach (DataRow row in channelTable.Rows) {
                string sql = string.Format(@"insert into Channel_Allot values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}')",
                row["channel_code"], row["channel_type"], row["channel_name"], row["product_code"], row["product_name"],
                row["quantity"], row["remain_quantity"], row["channel_capacity"],row["group_no"], row["order_no"],
                row["sort_address"], row["supply_address"], row["led_no"], row["x"],
                row["y"], row["width"], row["height"], row["is_active"]);
                ra.DoCommand(sql);
            }
        }

        public string[] GetChannel()
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = "select distinct channel_name from handle_supply a left join channel_allot b on a.channel_code=b.channel_code";
            DataTable dt = ra.DoQuery(sql).Tables[0];
            string[] array = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                array[i] = Convert.ToString(dr["channel_name"]);
            }
            return array;
        }
    }
}
