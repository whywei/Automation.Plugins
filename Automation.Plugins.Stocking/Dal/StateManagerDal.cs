using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using System.Data;

namespace Automation.Plugins.Stocking.Dal
{
    public class StateManagerDal:AbstractBaseDal
    {
        /// <summary>
        /// 查询所有扫码状态管理器
        /// </summary>
        /// <returns></returns>
        public List<string> FindScannerListTable()
        {
            var ra = TransactionScopeManager[Global.THOK_Stock_DB_NAME].NewRelationAccesser();
            string sql = "SELECT STATECODE + '-' + REMARK AS STATENAME FROM AS_STATEMANAGER_SCANNER";
            DataTable table= ra.DoQuery(sql).Tables[0];
            List<string> list = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(row["STATENAME"].ToString());
            }
            return list;
        }

        /// <summary>
        /// 根据扫码状态管理器编号查找相应的ROW_INDEX
        /// </summary>
        /// <param name="stateCode">状态管理器编号</param>
        /// <returns></returns>
        public DataRow FindScannerIndexNoByStateCode(string stateCode)
        {
            var ra = TransactionScopeManager[Global.THOK_Stock_DB_NAME].NewRelationAccesser();
            string sql = string.Format("SELECT ROW_INDEX,VIEWNAME FROM AS_STATEMANAGER_SCANNER WHERE STATECODE='{0}'", stateCode);
            return ra.DoQuery(sql).Tables[0].Rows[0];
        }

        /// <summary>
        /// 根据订单状态管理器编号查找相应的ROW_INDEX
        /// </summary>
        /// <param name="stateCode">状态管理器编号</param>
        /// <returns></returns>
        public DataRow FindOrderIndexNoByStateCode(string stateCode)
        {
            var ra = TransactionScopeManager[Global.THOK_Stock_DB_NAME].NewRelationAccesser();
            string sql = string.Format("SELECT ROW_INDEX,VIEWNAME FROM AS_STATEMANAGER_ORDER WHERE STATECODE='{0}'", stateCode);
            return ra.DoQuery(sql).Tables[0].Rows[0];
        }

        /// <summary>
        /// 根据ROW_INDEX查询扫码器订单的信息
        /// </summary>
        /// <param name="indexNo">流水号</param>
        /// <returns></returns>
        public DataTable FindScannerStateByIndexNo(string indexNo, string viewName)
        {
            var ra = TransactionScopeManager[Global.THOK_Stock_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"SELECT ROW_INDEX,LINECODE,STOCKOUTID,CIGARETTECODE,CIGARETTENAME,CHANNELCODE,SORTCHANNELCODE,CHANNELNAME,
                            CASE CHANNELTYPE 
                                WHEN '5' THEN '混合立式机'
                                WHEN '4' THEN '混合卧式机'
                                WHEN '3' THEN '卧式机'
                                WHEN '2' THEN '立式机'
                                END CHANNELTYPENAME,
                            CASE 
                                WHEN ROW_INDEX < {0} THEN '已扫描'
                                WHEN ROW_INDEX = {0} THEN '等待扫描'
                                WHEN ROW_INDEX > {0} THEN '未扫描'
                                END STATE
                            FROM {1} ", indexNo, viewName);
            return ra.DoQuery(sql).Tables[0];
        }

        /// <summary>
        /// 查询所有订单状态管理器信息
        /// </summary>
        /// <returns></returns>
        public List<string> FindOrderStateList()
        {
            var ra = TransactionScopeManager[Global.THOK_Stock_DB_NAME].NewRelationAccesser();
            string sql = "SELECT STATECODE + '-' + REMARK AS STATENAME FROM AS_STATEMANAGER_ORDER";
            DataTable table= ra.DoQuery(sql).Tables[0];
            List<string> list = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(row["STATENAME"].ToString());
            }
            return list;
        }

        /// <summary>
        /// 根据ROW_INDEX查询订单的信息
        /// </summary>
        /// <param name="indexNo">流水号</param>
        /// <returns></returns>
        public DataTable FindOrderStateByIndexNo(string indexNo, string viewName)
        {
            var ra = TransactionScopeManager[Global.THOK_Stock_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"SELECT ROW_INDEX,LINECODE,STOCKOUTID,CIGARETTECODE,CIGARETTENAME,CHANNELCODE,SORTCHANNELCODE,CHANNELNAME,
                            CASE CHANNELTYPE 
                                WHEN '5' THEN '混合立式机'
                                WHEN '4' THEN '混合卧式机'
                                WHEN '3' THEN '卧式机'
                                WHEN '2' THEN '立式机'
                                END CHANNELTYPENAME,
                            CASE 
                                WHEN ROW_INDEX <= {0} THEN '已下单'
                                WHEN ROW_INDEX > {0} THEN '未下单'
                                END STATE
                            FROM {1} ", indexNo, viewName);
            return ra.DoQuery(sql).Tables[0];
        }
    }
}
