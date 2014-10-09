using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;

namespace Automation.Plugins.Share.Sorting.Dal
{
    public class SortingRecordDal : AbstractBaseDal
    {


        public DataTable FindSortingRecordMaster()
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"select sort_no,pack_no,a.quantity,b.channel_name,b.sort_address,
                           a.remain_quantity,export_no,a.product_code,a.product_name,a.customer_order,
                           case a.group_no when '1' then 'A线' when '2' then 'B线' end as group_no,
                           case a.status when '1' then '已下单' when '0' then '未下单' end as status
                           from sorting a left join channel_allot b on a.channel_code=b.channel_code
                           and a.product_code=b.product_code order by sort_no";
            return ra.DoQuery(string.Format(sql)).Tables[0];
        }
    }
}
