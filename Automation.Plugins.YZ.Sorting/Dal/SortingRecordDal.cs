using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;

namespace Automation.Plugins.YZ.Sorting.Dal
{
    public class SortingRecordDal : AbstractBaseDal
    {


        public DataTable FindSortingRecordMaster()
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = @"SELECT sort_no,pack_no,a.quantity,b.channel_name,b.sort_address,
                           qemain_quantity,export_no,a.product_code,a.product_name,
                           case a.status when '1' then '已下单' when '0' then '未下单' END as status
                           FROM sorting a left join Channel_Allot b on a.channel_code=b.channel_code
                           and a.product_code=b.product_code order by sort_no";
            return ra.DoQuery(string.Format(sql)).Tables[0];
        }

        //包号查询
        public DataTable FindSortingRecordByPackNo(int pack)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = @"SELECT sort_no,pack_no,a.quantity,b.channel_name,b.sort_address,
                           qemain_quantity,export_no,a.product_code,a.product_name,
                           case a.status when '1' then '已下单' when '0' then '未下单' END as status
                           FROM sorting a left join Channel_Allot b on a.channel_code=b.channel_code
                           and a.product_code=b.product_code where pack_no={0} order by sort_no ";
            return ra.DoQuery(string.Format(sql,pack)).Tables[0];
        }

    }
}
