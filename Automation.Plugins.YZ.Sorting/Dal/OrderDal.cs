using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;
using THOK.Util;
using Automation.Core.Util;

namespace Automation.Plugins.YZ.Sorting.Dal
{
    public class OrderDal : AbstractBaseDal
    {
        public DataTable FindMaster()
        {

            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = @"select [order_date],[batch_no],[line_code],[pack_no],[order_id],[dist_code],
       [dist_name],[deliver_line_code],[deliver_line_name],[customer_code],[customer_name],[license_no],
       [address],[customer_order],[customer_deliver_order],[quantity],[export_no],[start_time],[finish_time],
       CASE status WHEN '0' THEN '未下单' ELSE '已下单' END status FROM SORT_ORDER_ALLOT_MASTER";
            return ra.DoQuery(sql).Tables[0];
        }

        public DataTable FindDetailBySortNo(string pack_no)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"SELECT a.[pack_no],a.[channel_code],b.[channel_name],a.[product_code],a.[product_name],a.[quantity],
            c.[customer_deliver_order],c.[quantity] as quantity1,c.[export_no]
            FROM [sort_order_allot_detail] a left join Channel_Allot b on a.channel_code=b.channel_code 
            left join SORT_ORDER_ALLOT_MASTER c on a.pack_no=c.pack_no 
            WHERE a.pack_no={0} ORDER BY pack_no", pack_no);
            return ra.DoQuery(sql).Tables[0];
        }

        /// <summary>
        /// 查询多沟带缓存段
        /// </summary>
        /// <param name="channelGroup">通道组</param>
        /// <param name="sortNoStart">前端订单号</param>
        /// <returns>返回多沟带缓存段起所有订单数据</returns>         
        public DataTable FindDetailForCacheOrderQuery(string channelGroup, int sortNoStart)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = @"SELECT A.SORTNO,A.ORDERID,A.CIGARETTECODE, A.CIGARETTENAME, A.QUANTITY ,C.CUSTOMERNAME,B.CHANNELNAME,   
                        CASE B.CHANNELTYPE WHEN '2' THEN '立式机' WHEN '5' THEN '立式机' ELSE '卧式机' END CHANNELTYPE,   
                        CASE WHEN A.CHANNELGROUP=1 THEN 'A线' ELSE 'B线' END  CHANNELLINE
                        FROM AS_SC_ORDER A  
                          LEFT JOIN AS_SC_CHANNELUSED B ON A.CHANNELCODE=B.CHANNELCODE   
                            LEFT JOIN AS_SC_PALLETMASTER C ON A.SORTNO = C.SORTNO AND A.ORDERID = C.ORDERID AND A.ORDERDATE = C.ORDERDATE
                              WHERE A.CHANNELGROUP ={0} AND A.SORTNO >={1} ORDER BY A.SORTNO,B.CHANNELADDRESS";
            return ra.DoQuery(string.Format(sql, channelGroup == "A" ? "1" : "2", sortNoStart)).Tables[0];
        }

        public DataTable FindCustomerMaster()
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = @"SELECT ORDERNO,MIN(SORTNO) AS SORTNO,ORDERID,ROUTECODE,ROUTENAME,CUSTOMERCODE,CUSTOMERNAME,BATCHNO,
                        ADDRESS,SUM(QUANTITY)AS QUANTITY,SUM(QUANTITY1) AS QUANTITY1,SUM(QUANTITY) + SUM(QUANTITY1) AS ALLQUANTITY,
                        CASE MIN(STATUS) WHEN '0' THEN '未下单' ELSE '已下单' END STATUS,MIN(ORDERDATE) AS ORDERDATE 
                        FROM AS_SC_PALLETMASTER
                        GROUP BY ORDERNO ,ORDERID,ROUTECODE,ROUTENAME,CUSTOMERCODE,CUSTOMERNAME,BATCHNO,ADDRESS ORDER BY SORTNO";
            return ra.DoQuery(sql).Tables[0];
        }

        public List<string> FindCigaretteList()
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = @"SELECT CIGARETTECODE+'-'+CIGARETTENAME AS CIGARETTE
                           FROM AS_SC_ORDER GROUP BY CIGARETTECODE,CIGARETTENAME ORDER BY CIGARETTECODE";
            DataTable table = ra.DoQuery(sql).Tables[0];
            List<string> list = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(row["CIGARETTE"].ToString());
            }
            return list;
        }

        public DataTable FindPackMaster(string cigaretteCode, int quantity)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"SELECT ORDERNO,MIN(SORTNO) AS SORTNO,ORDERID,ROUTECODE,ROUTENAME,CUSTOMERCODE,CUSTOMERNAME,BATCHNO,
                                        ADDRESS,SUM(QUANTITY)AS QUANTITY,SUM(QUANTITY1) AS QUANTITY1,SUM(QUANTITY) + SUM(QUANTITY1) AS ALLQUANTITY,
                                        CASE MIN(STATUS) WHEN '0' THEN '未下单' ELSE '已下单' END STATUS,MIN(ORDERDATE) AS ORDERDATE 
                                        FROM AS_SC_PALLETMASTER
                                        WHERE ORDERID IN (SELECT ORDERID  FROM AS_SC_ORDER WHERE  CIGARETTECODE = '{0}'  GROUP BY ORDERID,CIGARETTECODE HAVING SUM(QUANTITY) = {1} )
                                         GROUP BY ORDERNO ,ORDERID,ROUTECODE,ROUTENAME,CUSTOMERCODE,CUSTOMERNAME,BATCHNO,ADDRESS ORDER BY SORTNO", cigaretteCode, quantity);
            return ra.DoQuery(sql).Tables[0];
        }

        /// <summary>
        /// 根据A线或B线查询当前缺烟的流水号
        /// </summary>
        /// <param name="channelGroup">A线或者B线</param>
        /// <returns>返回一个流水号</returns>
        public string FindMaxSortedMaster(string channelGroup)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = "SELECT ISNULL(MAX(SORTNO),0) FROM AS_SC_PALLETMASTER WHERE STATUS{0} ='1'";
            object result = ra.DoScalar(string.Format(sql, channelGroup == "A" ? "" : "1"));
            return result == null ? "0" : result.ToString();
        }

        public void UpdateOrderDetailByChannelCode(string sourceChannelCode, string targetChannelCode)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format("update sort_order_allot_detail set channel_code='{0}' where channel_code='{1}'", targetChannelCode, sourceChannelCode);
            ra.DoCommand(sql);
        }

        public DataTable FindHandSupply(string condition)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"SELECT A.SUPPLYNO,A.SORTNO,A.CIGARETTECODE,A.BATCHNO,A.CIGARETTENAME,
                           A.LINECODE,A.ORDERDATE,A.SUPPLYBATCH,A.QUANTITY,A.CHANNELCODE,CHANNELNAME,
                           CASE WHEN A.STATUS = 1 THEN '已补货' ELSE '未补货' END STATUS 
                           FROM AS_SC_HANDLESUPPLY A LEFT JOIN AS_SC_CHANNELUSED B ON A.CHANNELCODE = B.CHANNELCODE 
                           {0} ORDER BY A.SUPPLYNO", condition);
            return ra.DoQuery(sql).Tables[0];
        }

        //判断是否存在未分拣数据
        public bool FindUnsortCount()
        {

            //01未完成 02已完成
            var ra = TransactionScopeManager[Global.yzServiceName].NewRelationAccesser();
            string sql = string.Format(@"SELECT COUNT(*) FROM sms_sort_order_allot_master WHERE STATUS='01'");
            var r = ra.DoScalar(sql);
            return Convert.ToInt32(DBNullUtil.Convert(r)) > 0;
        }

        /// <summary>
        /// 删除贴标机数据
        /// </summary>
        public void DeleteTable(string tableName)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            ra.DoScalar(string.Format("TRUNCATE TABLE {0}",tableName));
        }


        public void InsertMaster(DataRow row)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = @"insert into sort_order_allot_master values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}')";
            ra.DoCommand(string.Format(sql,row["order_date"], row["batch_no"], row["sorting_line_code"], row["pack_no"]
                ,row["order_id"], row["dist_code"], row["dist_name"], row["deliver_line_code"],row["deliver_line_name"]
                , row["customer_code"], row["customer_name"], row["license_code"],row["address"], row["customer_order"]
                , row["customer_deliver_order"], row["customer_Info"],row["quantity"],row["export_no"],row["start_time"]
                , row["finish_time"], row["status"]));
        }

        public void InsertOrderDetail(DataRow row)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"insert into sort_order_allot_detail values('{0}','{1}','{2}','{3}','{4}')",
            row["pack_no"], row["channel_code"], row["product_code"], row["product_name"], row["quantity"]);
            ra.DoCommand(sql);
        }

        public void InsertHandleSupply(DataRow row)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"insert into handle_supply values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
            row["supply_id"], row["supply_batch"], row["pack_no"], row["channel_code"], row["product_code"], row["product_name"], row["quantity"], '0');
            ra.DoCommand(sql);
        }

        public DataTable FindOrderInfo(string sortNo)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = "";
            if (sortNo != "all")
                sql = @"SELECT COUNT(DISTINCT customer_code) customer_num, COUNT(DISTINCT deliver_line_code) deliver_line_num,
                         (SELECT ISNULL(SUM(quantity),0) FROM sort_order_allot_master WHERE finish_time <= GETDATE() AND STATUS=1 ) quantity
                         FROM sort_order_allot_master WHERE finish_time <= GETDATE()";
            else
                sql = @"SELECT COUNT(DISTINCT customer_code) customer_num, COUNT(DISTINCT deliver_line_code) deliver_line_num,
                         (SELECT ISNULL(SUM(quantity),0) FROM sort_order_allot_master) quantity
                         FROM sort_order_allot_master";
            return ra.DoQuery(sql).Tables[0];
        }

        /// <summary>
        /// 获取主单最大的包号
        /// </summary>
        /// <returns>包号</returns>
        public int FindMaxPackNoFromMaster()
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = "SELECT ISNULL(MAX(pack_no),0) pack_no FROM sort_order_allot_master";
            return Convert.ToInt32(ra.DoScalar(sql));
        }

        /// <summary>
        /// 获取主单卷烟总条数
        /// </summary>
        /// <returns>条数</returns>
        public int FindSumQuantityFromMaster()
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = "SELECT ISNULL(SUM(quantity),0) quantity FROM sort_order_allot_master";
            return Convert.ToInt32(ra.DoScalar(sql));
        }

        public void UpdateMasterStatus(int packNo)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = "UPDATE sort_order_allot_master SET status='1',start_time=GETDATE() WHERE pack_no<={0} AND status='0'";
            ra.DoCommand(string.Format(sql, packNo));
        }

        public DataTable FindOrderDetailByPackNo(int packNo)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = @"SELECT A.pack_no,A.channel_code,C.sort_address,C.group_no,B.export_no,B.customer_order,A.product_code,A.product_name,A.quantity
                        ,(SELECT ISNULL(SUM(D.quantity),0) FROM sort_order_allot_detail D LEFT JOIN Channel_Allot E 
                        ON D.channel_code=E.channel_code WHERE D.pack_no={0} AND E.group_no=C.group_no) TOTALQUANTITY
                        ,(SELECT ISNULL(SUM(D.quantity),0) FROM sort_order_allot_detail D LEFT JOIN Channel_Allot E 
                        ON D.channel_code=E.channel_code WHERE D.pack_no>={0} AND E.channel_code=C.channel_code) REMAINQUANTITY
                        FROM sort_order_allot_detail A LEFT JOIN sort_order_allot_master B ON A.pack_no=B.pack_no
                        LEFT JOIN Channel_Allot C ON A.channel_code=C.channel_code 
                        where A.pack_no={0} ORDER BY A.pack_no ASC,C.group_no DESC,C.sort_address";
            return ra.DoQuery(string.Format(sql, packNo)).Tables[0];
        }

        public DataTable FindExporNoFromMaster()
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = "SELECT DISTINCT export_no,CONVERT(VARCHAR(100),order_date,23) order_date FROM sort_order_allot_master";
            return ra.DoQuery(sql).Tables[0];
        }

        public DataTable FindPackData(string condition)
        {
            var ra = TransactionScopeManager[Global.yzSorting_DB_NAME].NewRelationAccesser();
            string sql = @"SELECT row_number() over(ORDER BY A.pack_no,C.group_no DESC,C.sort_address,D.supply_batch,D.supply_id) id
                        ,A.pack_no,(SELECT ISNULL(SUM(E.quantity),0) FROM sort_order_allot_master E WHERE E.customer_code=B.customer_code) TOTAL_QUANTITY
                        ,B.quantity BAG_QUANTITY,A.quantity,B.export_no,CONVERT(VARCHAR(100),B.order_date,23) order_date,B.batch_no,B.line_code
                        ,B.order_id,B.deliver_line_code,B.deliver_line_name,B.customer_code,B.customer_name,B.address,B.customer_order
                        ,B.customer_deliver_order,B.customer_Info,A.product_code,A.product_name,B.dist_code,B.dist_name
                        FROM sort_order_allot_detail A LEFT JOIN sort_order_allot_master B ON A.pack_no=B.pack_no
                        LEFT JOIN Channel_Allot C ON A.channel_code=C.channel_code
                        LEFT JOIN handle_supply D ON A.channel_code =D.channel_code
                        {0}
                        ORDER BY A.pack_no,C.group_no DESC,C.sort_address,D.supply_batch,D.supply_id";
            return ra.DoQuery(string.Format(sql,condition)).Tables[0];
        }
    }
}

