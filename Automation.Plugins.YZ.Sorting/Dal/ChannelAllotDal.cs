using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;

namespace Automation.Plugins.YZ.Sorting.Dal
{
    class ChannelAllotDal : AbstractBaseDal
    {
        //2：立式机 ；3：通道机 ；4：卧式机 ；5：混合烟道
        public DataTable FindMaster()
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = @" select channel_code
      ,channel_name,product_code,product_name,real_quantity,led_code
      ,remain_quantity,middle_quantity,max_quantity,in_quantity,out_quantity
      ,group_no,order_no,address,cell_code, 
      case channel_type when '2' then '立式机' when '3' then '通道机'when '4' then '卧式机' else  '混合烟道' end channel_type,
      case status when '1' then '可用' else  '不可用' end status
      FROM Channel_Allot";
            return ra.DoQuery(sql).Tables[0];
        }
    }
}
