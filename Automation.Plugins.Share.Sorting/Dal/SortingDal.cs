using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;

namespace Automation.Plugins.Share.Sorting.Dal
{
    public class SortingDal : AbstractBaseDal
    {
        public int FindMinUnSortPackNo(int groupNo)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = "select isnull(min(pack_no),0) pack_no from sorting where status='0' and group_no={0}";
            return Convert.ToInt32(ra.DoScalar(string.Format(sql, groupNo)));
        }

        public DataTable FindSortingInformation(int groupNo)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"select top 25 sort_no,pack_no,quantity,group_no,channel_address,remain_quantity,export_no,product_code,piece_barcode,customer_order
                            from sorting where group_no={0} and status='0' order by pack_no,sort_no";
            return ra.DoQuery(string.Format(sql, groupNo)).Tables[0];
        }

        public void UpdateSoringStatus(string sortNo)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = "update sorting set status='1' where sort_no in ({0}) ";
            ra.DoCommand(string.Format(sql, sortNo));
        }

        public int FindMaxPackNo(int groupNo)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = "select isnull(max(pack_no),0) pack_no from sorting where group_no={0}";
            return Convert.ToInt32(ra.DoScalar(string.Format(sql, groupNo)));
        }
        
        public DataTable FindUnSortPackNo(int groupNo)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = "select distinct pack_no from sorting where group_no={0} and status='0' order by pack_no desc";
            return ra.DoQuery(string.Format(sql,groupNo)).Tables[0];
        }

        public void InsertIntoSorting(int sortNo, int remainquantity, DataRow row)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"declare @aa int
                        declare @remainquantity int
                        declare @sortno int
                        set @aa=0
                        set @remainquantity={5}
                        set @sortno={0}
                        while @aa<{2}
                        begin
                           insert into sorting values(@sortno,'{1}',{2},'{3}',{10},'{4}',@remainquantity-@aa,'{6}','{7}','{8}','{11}',{9},'0')
                           set @aa=@aa+1
                           set @sortno=@sortno+1
                        end";
            ra.DoCommand(string.Format(sql, sortNo, row["pack_no"], row["quantity"], row["channel_code"], row["sort_address"], remainquantity,
                row["export_no"], row["product_code"], row["product_name"], row["customer_order"], row["group_no"], row["piece_barcode"]));
        }

        public int FindMaxSortNo()
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = "select isnull(max(sort_no),0) sort_no from sorting";
            return Convert.ToInt32(ra.DoScalar(sql));
        }

        public int FindMaxSortNo(int groupNo)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = "select isnull(max(sort_no),0) sort_no from sorting where group_no={0}";
            return Convert.ToInt32(ra.DoScalar(string.Format(sql, groupNo)));
        }

        public void UpdateSortingByChannelCode(string channelCode, string cigaretteCode, string cigaretteName, string quantity)
        { 
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = string.Format(@"update sorting
                                        set product_code = '{0}',product_name = '{1}',quantity = {2}
                                        where channel_code='{3}' and status = 0 ", cigaretteCode, cigaretteName, quantity, channelCode);
            ra.DoCommand(sql);
        }

        public DataTable FindSortingForCacheQuery(int sortNo, int groupNo, int quantity)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"select top {2} sort_no,a.pack_no,b.customer_name,a.product_name,1 quantity,b.quantity bag_quantity,c.channel_name
                        ,case a.group_no when '1' then 'A线' else 'B线' end group_no,a.remain_quantity,a.export_no
                        from sorting a left join sort_order_allot_master b on a.pack_no=b.pack_no
                        left join channel_allot c on a.channel_code=c.channel_code and a.product_code=c.product_code
                        where a.group_no={1} and sort_no>={0}
                        order by a.pack_no,a.sort_no";
            return ra.DoQuery(string.Format(sql, sortNo, groupNo, quantity)).Tables[0];
        }

        public DataTable FindSortingForCacheQuery(string packNo)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"select sort_no,a.pack_no,b.customer_name,a.product_name,1 quantity,b.quantity bag_quantity,c.channel_name
                        ,case a.group_no when '1' then 'A线' else 'B线' end group_no,a.remain_quantity,a.export_no
                        from sorting a left join sort_order_allot_master b on a.pack_no=b.pack_no
                        left join channel_allot c on a.channel_code=c.channel_code and a.product_code=c.product_code
                        where a.pack_no={0}
                        order by a.pack_no,a.sort_no";
            return ra.DoQuery(string.Format(sql, packNo)).Tables[0];
        }

        public string FindPackNoBySortNo(string sortNo)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"select distinct pack_no from sorting where sort_no={0}";
            object obj = ra.DoScalar(string.Format(sql, sortNo));
            return obj == null ? "0" : obj.ToString();
        }

        public int FindIsSortMaxPackNo(int groupNo)
        {
            var ra = TransactionScopeManager[Global.SORTING_DATABASE_NAME].NewRelationAccesser();
            string sql = @"select isnull(max(pack_no),0) pack_no from sorting where group_no={0} and status='1'";
            return Convert.ToInt32(ra.DoScalar(string.Format(sql, groupNo)));
        }
    }
}
