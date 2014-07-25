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

        public DataTable FindSortingInformation(int packNo,int groupNo)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = @"SELECT sort_no,pack_no,quantity,group_no,channel_address,remain_quantity,export_no,product_code,
                      customer_order FROM sorting WHERE pack_no={0} AND group_no={1} AND status='0' ORDER BY sort_no";
            return ra.DoQuery(string.Format(sql, packNo,groupNo)).Tables[0];
        }

        public void UpdateSoringStatus(int packNo, int groupNo)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = "UPDATE sorting SET status='1' WHERE pack_no={0} AND group_no={1}";
            ra.DoCommand(string.Format(sql, packNo, groupNo));
        }

        public int FindMaxPackNo()
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = "SELECT ISNULL(MAX(pack_no),0) pack_no FROM sorting";
            return Convert.ToInt32(ra.DoScalar(sql));
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
                           INSERT INTO sorting VALUES(@SORTNO,'{1}',{2},'{3}',{10},'{4}',@REMAINQUANTITY-@AA,'{6}','{7}','{8}',{9},'0')
                           SET @AA=@AA+1
                           SET @SORTNO=@SORTNO+1
                        END";
            ra.DoCommand(string.Format(sql, sortNo, row["pack_no"], row["quantity"], row["channel_code"], row["sort_address"], row["REMAINQUANTITY"], row["export_no"], row["product_code"], row["product_name"], row["customer_order"], row["group_no"]));
        }

        public int FindMaxSortNo()
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = "SELECT ISNULL(MAX(sort_no),0) sort_no FROM sorting";
            return Convert.ToInt32(ra.DoScalar(sql));
        }

        public void UpdateSortingByChannelCode(string channelCode, string cigaretteCode, string cigaretteName, string quantity)
        { 
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"update sorting
                                        set product_code = '{0}',product_name = '{1}',quantity = {2}
                                        where channel_code='{3}' and status = 0 ", cigaretteCode, cigaretteName, quantity, channelCode);
            ra.DoCommand(sql);
        }
    }
}
