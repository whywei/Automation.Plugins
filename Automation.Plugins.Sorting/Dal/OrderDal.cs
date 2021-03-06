﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBRabbit;

namespace Automation.Plugins.Sorting.Dal
{
    public class OrderDal : AbstractBaseDal
    {
        public DataTable FindMaster()
        {

            var ra = TransactionScopeManager[Global.THOK_Sorting_DB_NAME].NewRelationAccesser();
            string sql = @"SELECT ORDERDATE,BATCHNO,SORTNO, ORDERID,ROUTECODE,ROUTENAME,CUSTOMERCODE,CUSTOMERNAME, 
                            CASE STATUS WHEN '0' THEN '未下单' ELSE '已下单' END STATUS_A,
                            CASE STATUS1 WHEN '0' THEN '未下单' ELSE '已下单' END STATUS_B
                            FROM AS_SC_PALLETMASTER";
            return ra.DoQuery(sql).Tables[0];
        }

        public DataTable FindDetailBySortNo(string sortNo)
        {
            var ra = TransactionScopeManager[Global.THOK_Sorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"SELECT A.SORTNO, A.PACKNO,ORDERID, B.CHANNELNAME, 
                                             CASE B.CHANNELTYPE WHEN '2' THEN '立式机' WHEN '5' THEN '立式机' ELSE '卧式机' END CHANNELTYPE, 
                                             A.CIGARETTECODE, A.CIGARETTENAME, A.QUANTITY ,B.CHANNELADDRESS ,
                                             CASE WHEN A.CHANNELGROUP=1 THEN 'A线' ELSE 'B线' END  CHANNELLINE 
                                             FROM AS_SC_ORDER A 
                                             LEFT JOIN AS_SC_CHANNELUSED B ON A.CHANNELCODE=B.CHANNELCODE 
                                             WHERE A.SORTNO={0} ORDER BY PACKNO, A.CHANNELGROUP DESC,B.CHANNELADDRESS", sortNo);
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
            var ra = TransactionScopeManager[Global.THOK_Sorting_DB_NAME].NewRelationAccesser();
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
            var ra = TransactionScopeManager[Global.THOK_Sorting_DB_NAME].NewRelationAccesser();
            string sql = @"SELECT ORDERNO,MIN(SORTNO) AS SORTNO,ORDERID,ROUTECODE,ROUTENAME,CUSTOMERCODE,CUSTOMERNAME,BATCHNO,
                        ADDRESS,SUM(QUANTITY)AS QUANTITY,SUM(QUANTITY1) AS QUANTITY1,SUM(QUANTITY) + SUM(QUANTITY1) AS ALLQUANTITY,
                        CASE MIN(STATUS) WHEN '0' THEN '未下单' ELSE '已下单' END STATUS,MIN(ORDERDATE) AS ORDERDATE 
                        FROM AS_SC_PALLETMASTER
                        GROUP BY ORDERNO ,ORDERID,ROUTECODE,ROUTENAME,CUSTOMERCODE,CUSTOMERNAME,BATCHNO,ADDRESS ORDER BY SORTNO";
            return ra.DoQuery(sql).Tables[0];
        }

        public List<string> FindCigaretteList()
        {
            var ra = TransactionScopeManager[Global.THOK_Sorting_DB_NAME].NewRelationAccesser();
            string sql = @"SELECT CIGARETTECODE+'-'+CIGARETTENAME AS CIGARETTE
                           FROM AS_SC_ORDER GROUP BY CIGARETTECODE,CIGARETTENAME ORDER BY CIGARETTECODE";
            DataTable table= ra.DoQuery(sql).Tables[0];
            List<string> list = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(row["CIGARETTE"].ToString());
            }
            return list;
        }

        public DataTable FindPackMaster(string cigaretteCode,int quantity)
        {
            var ra = TransactionScopeManager[Global.THOK_Sorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"SELECT ORDERNO,MIN(SORTNO) AS SORTNO,ORDERID,ROUTECODE,ROUTENAME,CUSTOMERCODE,CUSTOMERNAME,BATCHNO,
                                        ADDRESS,SUM(QUANTITY)AS QUANTITY,SUM(QUANTITY1) AS QUANTITY1,SUM(QUANTITY) + SUM(QUANTITY1) AS ALLQUANTITY,
                                        CASE MIN(STATUS) WHEN '0' THEN '未下单' ELSE '已下单' END STATUS,MIN(ORDERDATE) AS ORDERDATE 
                                        FROM AS_SC_PALLETMASTER
                                        WHERE ORDERID IN (SELECT ORDERID  FROM AS_SC_ORDER WHERE  CIGARETTECODE = '{0}'  GROUP BY ORDERID,CIGARETTECODE HAVING SUM(QUANTITY) = {1} )
                                         GROUP BY ORDERNO ,ORDERID,ROUTECODE,ROUTENAME,CUSTOMERCODE,CUSTOMERNAME,BATCHNO,ADDRESS ORDER BY SORTNO", cigaretteCode,quantity);
            return ra.DoQuery(sql).Tables[0];
        }

        /// <summary>
        /// 根据A线或B线查询当前缺烟的流水号
        /// </summary>
        /// <param name="channelGroup">A线或者B线</param>
        /// <returns>返回一个流水号</returns>
        public string FindMaxSortedMaster(string channelGroup)
        {
            var ra = TransactionScopeManager[Global.THOK_Sorting_DB_NAME].NewRelationAccesser();
            string sql = "SELECT ISNULL(MAX(SORTNO),0) FROM AS_SC_PALLETMASTER WHERE STATUS{0} ='1'";
            object result = ra.DoScalar(string.Format(sql, channelGroup == "A" ? "" : "1"));
            return result == null ? "0" : result.ToString();
        }

        public void UpdateOrderDetailByChannelCode(string sourceChannel, string targetChannel)
        {
            var ra = TransactionScopeManager[Global.THOK_Sorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format("UPDATE AS_SC_ORDER SET CHANNELCODE='{0}' WHERE CHANNELCODE='{1}'", targetChannel, sourceChannel);
            ra.DoCommand(sql);
        }

        public DataTable FindHandSupply(string condition)
        {
            var ra = TransactionScopeManager[Global.THOK_Sorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"SELECT A.SUPPLYNO,A.SORTNO,A.CIGARETTECODE,A.BATCHNO,A.CIGARETTENAME,
                           A.LINECODE,A.ORDERDATE,A.SUPPLYBATCH,A.QUANTITY,A.CHANNELCODE,CHANNELNAME,
                           CASE WHEN A.STATUS = 1 THEN '已补货' ELSE '未补货' END STATUS 
                           FROM AS_SC_HANDLESUPPLY A LEFT JOIN AS_SC_CHANNELUSED B ON A.CHANNELCODE = B.CHANNELCODE 
                           {0} ORDER BY A.SUPPLYNO", condition);
            return ra.DoQuery(sql).Tables[0];
        }
    }
}
