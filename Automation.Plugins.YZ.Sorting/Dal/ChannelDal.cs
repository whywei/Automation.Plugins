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
        /// <summary>查询烟道信息</summary>
        public DataTable FindChannel()
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select a.channel_code, a.channel_name
                                        ,case a.channel_type when '1' then '立式机(人工)' when '2' then '立式机(自动)' when '3' then '通道机'when '4' then '卧式机' else  '混合烟道' end channel_type
                                        ,a.sort_address, a.supply_address
                                        ,a.product_code, a.product_name, a.quantity, a.remain_quantity, a.group_no
                                        ,case a.status when '1' then '可用' else  '不可用' end status
                                        from channel_allot a");
            return ra.DoQuery(sql).Tables[0];
        }
        
        public void InsertChannel(DataRow row)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"insert into Channel_Allot values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}')",
            row["channel_code"], row["channel_type"], row["channel_name"], row["product_code"], row["product_name"],
            row["quantity"], row["remain_quantity"], row["channel_capacity"], row["group_no"], row["order_no"],
            row["sort_address"], row["supply_address"], row["led_no"], row["x"],
            row["y"], row["width"], row["height"], row["is_active"]);
            ra.DoCommand(sql);
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

        public string[] GetChannel(string channelName)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@" select channel_name from dbo.Channel_Allot where channel_type 
                         = (select distinct channel_type from Channel_Allot where channel_name='{0}')", channelName);
            DataTable dt = ra.DoQuery(sql).Tables[0];
            string[] array = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                array[i] = Convert.ToString(dr["channel_name"]);
            }
            System.Windows.Forms.MessageBox.Show(array+",");
            return array;
        }
    }
}
