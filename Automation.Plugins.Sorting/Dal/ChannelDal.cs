using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;

namespace Automation.Plugins.Sorting.Dal
{
    public class ChannelDal:AbstractBaseDal
    {
        /// <summary>
        /// 根据流水号查询烟道信息
        /// </summary>
        /// <param name="sortNo">流水号</param>
        /// <param name="channelGroup">A线或者B线</param>
        /// <returns>返回查询到的烟道信息表</returns>
        public DataTable FindChannelQuantity(int sortNo)
        {
            var ra = TransactionScopeManager[Global.THOK_Sorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"SELECT CHANNELCODE,CHANNELNAME,LINECODE,CHANNELTYPE,STATUS,CIGARETTECODE,
                                         CIGARETTENAME,QUANTITY,REMAINQUANTITY,CHANNELADDRESS,SORTQUANTITY,
                                         REMAINQUANTITY / 50 BOXQUANTITY, REMAINQUANTITY % 50 ITEMQUANTITY,
                                         CASE C.CHANNELGROUP WHEN '1' THEN 'A线' ELSE 'B线' END CHANNELGROUP
                                         FROM (SELECT A.CHANNELCODE,A.CHANNELNAME, A.LINECODE,
                                         CASE CHANNELTYPE WHEN '2' THEN '立式机' WHEN '5' THEN '立式机' ELSE '卧式机' END CHANNELTYPE,
                                         CASE STATUS WHEN '0' THEN '未启用' ELSE '已启用' END STATUS,  
                                         A.CIGARETTECODE, A.CIGARETTENAME, A.QUANTITY,ISNULL(B.QUANTITY,0) SORTQUANTITY,
                                         A.QUANTITY - ISNULL(B.QUANTITY,0) REMAINQUANTITY,
                                         A.CHANNELADDRESS, A.CHANNELGROUP
                                         FROM AS_SC_CHANNELUSED A
                                         LEFT JOIN(SELECT CHANNELCODE, SUM(QUANTITY) QUANTITY
                                         FROM AS_SC_ORDER WHERE SORTNO <= '{0}' GROUP BY CHANNELCODE) B
                                         ON A.CHANNELCODE = B.CHANNELCODE) C
                                         ORDER BY CHANNELNAME ", sortNo);
            return ra.DoQuery(sql).Tables[0];
        }

        /// <summary>
        /// 根据流水号查询烟道信息
        /// </summary>
        /// <param name="sortNo">A线流水号</param>
        /// <param name="channelGroup">B线流水号</param>
        /// <returns>返回查询到的烟道信息表</returns>
        public DataTable FindAllChannelQuantity(string sortNo_A, string sortNo_B)
        {
            var ra = TransactionScopeManager[Global.THOK_Sorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"SELECT CHANNELCODE,CHANNELNAME,LINECODE,CHANNELTYPE,STATUS,CIGARETTECODE,
                                        CIGARETTENAME,QUANTITY,REMAINQUANTITY,CHANNELADDRESS,SORTQUANTITY,
                                        REMAINQUANTITY / 50 BOXQUANTITY, REMAINQUANTITY % 50 ITEMQUANTITY,
                                         CASE C.CHANNELGROUP WHEN '1' THEN 'A线' ELSE 'B线' END CHANNELGROUP
                                          FROM (SELECT A.CHANNELCODE,A.CHANNELNAME,A.LINECODE,    
                                                  CASE CHANNELTYPE WHEN '2' THEN '立式机' WHEN '5' THEN '立式机' ELSE '卧式机' END CHANNELTYPE, 
                                                  CASE STATUS WHEN '0' THEN '未启用' ELSE '已启用' END STATUS,  
                                                  A.CIGARETTECODE, A.CIGARETTENAME, A.QUANTITY,ISNULL(B.QUANTITY,0) SORTQUANTITY,   
                                                  A.QUANTITY - ISNULL(B.QUANTITY,0) REMAINQUANTITY,   
                                                  A.CHANNELADDRESS, A.CHANNELGROUP
                                                  FROM AS_SC_CHANNELUSED A    
                                                  LEFT JOIN(SELECT CHANNELCODE, SUM(QUANTITY) QUANTITY    
                                                              FROM AS_SC_ORDER WHERE SORTNO <= '{0}' GROUP BY CHANNELCODE) B    
                                                              ON A.CHANNELCODE = B.CHANNELCODE) C     
                                          WHERE CHANNELGROUP =1
                                       union all
                                        SELECT CHANNELCODE,CHANNELNAME,LINECODE,CHANNELTYPE,STATUS,CIGARETTECODE,
                                        CIGARETTENAME,QUANTITY,REMAINQUANTITY,CHANNELADDRESS,SORTQUANTITY,
                                        REMAINQUANTITY / 50 BOXQUANTITY, REMAINQUANTITY % 50 ITEMQUANTITY,
                                        CASE C.CHANNELGROUP WHEN '1' THEN 'A线' ELSE 'B线' END CHANNELGROUP  
                                          FROM (SELECT A.CHANNELCODE,A.CHANNELNAME, A.LINECODE,    
                                                  CASE CHANNELTYPE WHEN '2' THEN '立式机' WHEN '5' THEN '立式机' ELSE '卧式机' END CHANNELTYPE,   
                                                  CASE STATUS WHEN '0' THEN '未启用' ELSE '已启用' END STATUS,  
                                                  A.CIGARETTECODE, A.CIGARETTENAME, A.QUANTITY,ISNULL(B.QUANTITY,0) SORTQUANTITY,   
                                                  A.QUANTITY - ISNULL(B.QUANTITY,0) REMAINQUANTITY,   
                                                  A.CHANNELADDRESS, A.CHANNELGROUP
                                                  FROM AS_SC_CHANNELUSED A    
                                                  LEFT JOIN(SELECT CHANNELCODE, SUM(QUANTITY) QUANTITY    
                                                              FROM AS_SC_ORDER WHERE SORTNO <= '{1}' GROUP BY CHANNELCODE) B    
                                                              ON A.CHANNELCODE = B.CHANNELCODE) C     
                                          WHERE CHANNELGROUP =2 ORDER BY CHANNELNAME", sortNo_A, sortNo_B);
            return ra.DoQuery(sql).Tables[0];
        }

        /// <summary>
        /// 根据烟道代码查询烟道类型和烟道组号
        /// </summary>
        /// <param name="channelcode">烟道代码</param>
        /// <returns>返回烟道类型和烟道组号</returns>
        public DataTable FindSortChannel(string lineCode,string channelType,string channelGroup,string channelCode)
        {
            var ra = TransactionScopeManager[Global.THOK_Sorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"SELECT CHANNELCODE AS CODE, LINECODE + '-'+CASE CHANNELGROUP WHEN '1' THEN 'A线' ELSE 'B线' END +'-'+
                                         CASE CHANNELTYPE WHEN '2' THEN '立式机' WHEN '5' THEN '立式机'  ELSE '卧式机' END 
                                         +'-'+CHANNELNAME AS CHANNEL 
                                        FROM AS_SC_CHANNELUSED 
                                        WHERE LINECODE='{0}' AND CHANNELTYPE IN ({1}) AND CHANNELGROUP = {2} AND CHANNELCODE != {3} 
                                        ORDER BY CHANNELNAME", lineCode, channelType == "卧式机" ? "'3'" : "'2','5'", channelGroup == "A线" ? "1" : "2", channelCode);
            return ra.DoQuery(sql).Tables[0];
        }

        public void UpdateSortChannelByChannelCode(string channelCode, string cigaretteCode, string cigaretteName, string quantity, string sortNo, string status)
        {
            var ra = TransactionScopeManager[Global.THOK_Sorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"UPDATE AS_SC_CHANNELUSED
                                        SET CIGARETTECODE = '{0}',CIGARETTENAME = '{1}',QUANTITY = {2}, SORTNO={3},STATUS='{4}'
                                        WHERE CHANNELCODE='{5}'", cigaretteCode, cigaretteName, quantity, sortNo,status, channelCode);
            ra.DoCommand(sql);
        }

        public DataRow FindSortChannelByCode(string channelCode)
        {
            var ra = TransactionScopeManager[Global.THOK_Sorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format("SELECT * FROM AS_SC_CHANNELUSED WHERE CHANNELCODE='{0}'", channelCode);
            return ra.DoQuery(sql).Tables[0].Rows[0];
        }

        public List<string> FindMixChannelToList()
        {
            var ra = TransactionScopeManager[Global.THOK_Sorting_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"SELECT CHANNELCODE+'-'+CHANNELNAME+ '-' + '混合烟道' CHANNELNAME
                                        FROM AS_SC_CHANNELUSED
                                        WHERE CHANNELTYPE ='5' AND STATUS ='1'");
            DataTable table = ra.DoQuery(sql).Tables[0];
            List<string> list = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(row["CHANNELNAME"].ToString());
            }
            return list;
        }
    }
}
