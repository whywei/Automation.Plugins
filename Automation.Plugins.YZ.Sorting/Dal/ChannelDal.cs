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
      
        public void InsertChannel(DataTable channelTable)
        {

            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            ra.DoScalar("TRUNCATE TABLE Channel_Allot");
            
            foreach (DataRow row in channelTable.Rows) {
                string sql = string.Format(@"insert into Channel_Allot values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}')",
                row["channel_code"], row["channel_type"], row["channel_name"], row["product_code"], row["product_name"],
                row["quantity"], row["remain_quantity"], row["channel_capacity"], row["middle_quantity"], row["max_quantity"], row["group_no"], row["order_no"],
                row["sort_address"], row["supply_address"], row["led_no"], row["x"],
                row["y"], row["width"], row["height"], row["status"]);
                ra.DoCommand(sql);
            }
        }
    }
}
