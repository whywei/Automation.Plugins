using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;

namespace Automation.Plugins.YZ.Sorting.Dal
{
    public class SortingDal : AbstractBaseDal
    {
        public int FindMinUnSortPackNo(int groupNo)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = "SELECT ISNULL(MIN(pack_no),0) pack_no FROM sorting WHERE status='0' AND group_no={0}";
            return Convert.ToInt32(ra.DoScalar(string.Format(sql, groupNo)));
        }

        public DataTable FindSortingInformation(int groupNo)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = @"SELECT TOP 25 sort_no,pack_no,quantity,group_no,channel_address,remain_quantity,export_no,product_code,piece_barcode,
                        customer_order FROM sorting WHERE group_no={0} AND status='0' ORDER BY pack_no,sort_no";
            return ra.DoQuery(string.Format(sql, groupNo)).Tables[0];
        }

        public void UpdateSoringStatus(string sortNoList)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = "UPDATE sorting SET status='1' WHERE sort_no in ({0}) ";
            ra.DoCommand(string.Format(sql, sortNoList));
        }

        public int FindMaxPackNo(int groupNo)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = "SELECT ISNULL(MAX(pack_no),0) pack_no FROM sorting WHERE group_no={0}";
            return Convert.ToInt32(ra.DoScalar(string.Format(sql, groupNo)));
        }
        
        public DataTable FindUnSortPackNo(int groupNo)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = "SELECT distinct pack_no FROM sorting WHERE group_no={0} and status='0' order by pack_no desc";
            return ra.DoQuery(string.Format(sql,groupNo)).Tables[0];
        }

        public void InsertIntoSorting(int sortNo, DataRow row)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = @"DECLARE @AA INT
                        DECLARE @REMAINQUANTITY INT
                        DECLARE @SORTNO INT
                        SET @AA=0
                        SET @REMAINQUANTITY={5}
                        SET @SORTNO={0}
                        WHILE @AA<{2}
                        BEGIN
                           INSERT INTO sorting VALUES(@SORTNO,'{1}',{2},'{3}',{10},'{4}',@REMAINQUANTITY-@AA,'{6}','{7}','{8}','{11}',{9},'0')
                           SET @AA=@AA+1
                           SET @SORTNO=@SORTNO+1
                        END";
            ra.DoCommand(string.Format(sql, sortNo, row["pack_no"], row["quantity"], row["channel_code"], row["sort_address"], row["REMAINQUANTITY"],
                row["export_no"], row["product_code"], row["product_name"], row["customer_order"], row["group_no"], row["piece_barcode"]));
        }

        public int FindMaxSortNo()
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = "SELECT ISNULL(MAX(sort_no),0) sort_no FROM sorting";
            return Convert.ToInt32(ra.DoScalar(sql));
        }

        public int FindMaxSortNo(int groupNo)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = "SELECT ISNULL(MAX(sort_no),0) sort_no FROM sorting where group_no={0}";
            return Convert.ToInt32(ra.DoScalar(string.Format(sql, groupNo)));
        }

        public void UpdateSortingByChannelCode(string channelCode, string cigaretteCode, string cigaretteName, string quantity)
        { 
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"update sorting
                                        set product_code = '{0}',product_name = '{1}',quantity = {2}
                                        where channel_code='{3}' and status = 0 ", cigaretteCode, cigaretteName, quantity, channelCode);
            ra.DoCommand(sql);
        }

        public DataTable FindSortingForCacheQuery(int sortNo, int groupNo, int quantity)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = @"SELECT TOP {2} sort_no,A.pack_no,B.customer_name,A.product_name,1 quantity,B.quantity bag_quantity,C.channel_name
                        ,CASE A.group_no WHEN '1' THEN 'A线' ELSE 'B线' END group_no,A.remain_quantity,A.export_no
                        FROM sorting A LEFT JOIN sort_order_allot_master B ON A.pack_no=B.pack_no
                        LEFT JOIN Channel_Allot C ON A.channel_code=C.channel_code AND A.product_code=C.product_code
                        WHERE A.group_no={1} AND sort_no>={0}
                        ORDER BY A.pack_no,A.sort_no";
            return ra.DoQuery(string.Format(sql, sortNo, groupNo, quantity)).Tables[0];
        }

        public DataTable FindSortingForCacheQuery(string packNo)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = @"SELECT sort_no,A.pack_no,B.customer_name,A.product_name,1 quantity,B.quantity bag_quantity,C.channel_name
                        ,CASE A.group_no WHEN '1' THEN 'A线' ELSE 'B线' END group_no,A.remain_quantity,A.export_no
                        FROM sorting A LEFT JOIN sort_order_allot_master B ON A.pack_no=B.pack_no
                        LEFT JOIN Channel_Allot C ON A.channel_code=C.channel_code AND A.product_code=C.product_code
                        WHERE A.pack_no={0}
                        ORDER BY A.pack_no,A.sort_no";
            return ra.DoQuery(string.Format(sql, packNo)).Tables[0];
        }

        public string FindPackNoBySortNo(string sortNo)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = @"SELECT DISTINCT pack_no FROM sorting WHERE sort_no={0}";
            object obj = ra.DoScalar(string.Format(sql, sortNo));
            return obj == null ? "0" : obj.ToString();
        }

        public int FindIsSortMaxPackNo(int groupNo)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = @"SELECT ISNULL(MAX(pack_no),0) pack_no FROM sorting WHERE group_no={0} AND status='1'";
            return Convert.ToInt32(ra.DoScalar(string.Format(sql, groupNo)));
        }
    }
}
