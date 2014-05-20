using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;

namespace Automation.Plugins.Stocking.Dal
{
    public class ChannelDal:AbstractBaseDal
    {
        /// <summary>
        /// 查询补货烟道信息
        /// </summary>
        /// <returns>补货烟道信息表</returns>
        public DataTable FindScokChannel(string indexNo)
        {
            var ra = TransactionScopeManager[Global.THOK_Stock_DB_NAME].NewRelationAccesser();
            string sql = @"SELECT CHANNELCODE,CHANNELNAME,
                            CASE 
                                WHEN CHANNELTYPE='1' THEN '拆叠垛缓存烟道'
                                WHEN CHANNELTYPE='2' THEN '普通单一烟道（补卧式机）' 
                                WHEN CHANNELTYPE='3' THEN '普通单一烟道（补立式机）' 
                                WHEN CHANNELTYPE='4' THEN '普通混合烟道' 
                                WHEN CHANNELTYPE='5' THEN '整件混合烟道' 
                                ELSE '无' 
                            END CHANNELTYPE,
                            A.CIGARETTECODE, CIGARETTENAME ,ISNULL(SUMQUANTITY,0) AS SUMQUANTITY,ISNULL(SCANNERQUANTITY,0) AS SCANNERQUANTITY
                            FROM AS_SC_STOCKCHANNELUSED A
                            LEFT JOIN (SELECT CIGARETTECODE,COUNT(CIGARETTECODE) AS SUMQUANTITY FROM AS_SC_SUPPLY GROUP BY CIGARETTECODE) B
                            ON A.CIGARETTECODE=B.CIGARETTECODE
                            LEFT JOIN (SELECT CIGARETTECODE,COUNT(CIGARETTECODE) AS SCANNERQUANTITY FROM V_STATE_SCANNER01 
                            WHERE ROW_INDEX <={0} GROUP BY CIGARETTECODE) C
                            ON A.CIGARETTECODE=C.CIGARETTECODE";
            return ra.DoQuery(string.Format(sql, indexNo)).Tables[0];
        }

        /// <summary>
        /// 查询分拣烟道表
        /// </summary>
        /// <returns>分拣烟道表</returns>
        public DataTable FindAllSortChannel()
        {
            var ra = TransactionScopeManager[Global.THOK_Stock_DB_NAME].NewRelationAccesser();
            string sql = @"SELECT CHANNELCODE, CHANNELNAME,CASE CHANNELGROUP WHEN '1' THEN 'A线' ELSE 'B线' END CHANNELGROUP,
                           CASE CHANNELTYPE WHEN '2' THEN '立式机' WHEN '5' THEN '混合烟道' ELSE '卧式机' END CHANNELTYPE, 
                           LINECODE, CIGARETTECODE, CIGARETTENAME,
                           CASE STATUS WHEN '0' THEN '未启用' ELSE '已启用' END STATUS, QUANTITY 
                           FROM AS_SC_CHANNELUSED ORDER BY LINECODE, CHANNELNAME";
            return ra.DoQuery(sql).Tables[0];
        }

        public DataTable FindSortChannelList()
        {
            var ra = TransactionScopeManager[Global.THOK_Stock_DB_NAME].NewRelationAccesser();
            string sql = @"SELECT LINECODE + '-'+CHANNELCODE+'-' + CHANNELNAME + '-' + 
                            CASE CHANNELTYPE WHEN '2' THEN '立式机' ELSE '卧式机' END CHANNELITEM,
                            CHANNELTYPE,CHANNELGROUP, CHANNELCODE,LINECODE
                            FROM AS_SC_CHANNELUSED 
                            WHERE CHANNELTYPE != '5'
                            ORDER BY CHANNELNAME";
            return ra.DoQuery(sql).Tables[0];
        }

        /// <summary>
        /// 根据烟道代码查询烟道类型和烟道组号
        /// </summary>
        /// <param name="channelcode">烟道代码</param>
        /// <returns>返回烟道类型和烟道组号</returns>
        public DataTable FindSortChannel(string lineCode, string channelType, string channelGroup, string channelCode)
        {
            var ra = TransactionScopeManager[Global.THOK_Stock_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"SELECT CHANNELCODE AS CODE, LINECODE + '-'+CASE CHANNELGROUP WHEN '1' THEN 'A线' ELSE 'B线' END +'-'+
                                         CASE CHANNELTYPE WHEN '2' THEN '立式机' WHEN '5' THEN '立式机'  ELSE '卧式机' END 
                                         +'-'+CHANNELNAME AS CHANNEL 
                                        FROM AS_SC_CHANNELUSED 
                                        WHERE LINECODE='{0}' AND CHANNELTYPE IN ({1}) AND CHANNELGROUP = {2} AND CHANNELCODE != {3} 
                                        ORDER BY CHANNELNAME", lineCode, channelType == "卧式机" ? "'3'" : "'2','5'", channelGroup == "A线" ? "1" : "2", channelCode);
            return ra.DoQuery(sql).Tables[0];
        }

        /// <summary>
        /// 烟道信息定位
        /// </summary>
        /// <param name="lineCode">生产线</param>
        /// <param name="channelCode">烟道编码</param>
        /// <returns></returns>
        public DataRow FindSortChannelUSED(string lineCode, string channelCode)
        {
            var ra = TransactionScopeManager[Global.THOK_Stock_DB_NAME].NewRelationAccesser();
            string sql = "SELECT * FROM AS_SC_CHANNELUSED WHERE CHANNELCODE='{0}' AND LINECODE = '{1}' ";
            return ra.DoQuery(string.Format(sql, channelCode, lineCode)).Tables[0].Rows[0];
        }

        public void UpdateSortChannelUSED(string lineCode, string channelCode, string cigaretteCode, string cigaretteName, string quantity, string sortNo)
        {
            var ra = TransactionScopeManager[Global.THOK_Stock_DB_NAME].NewRelationAccesser();
            string sql = "UPDATE AS_SC_CHANNELUSED SET CIGARETTECODE='{0}', CIGARETTENAME='{1}', QUANTITY={2}, SORTNO={3} " +
                            " WHERE CHANNELCODE='{4}' AND LINECODE = '{5}'";
            ra.DoCommand(string.Format(sql, cigaretteCode, cigaretteName, quantity, sortNo, channelCode, lineCode));
        }
    }
}
