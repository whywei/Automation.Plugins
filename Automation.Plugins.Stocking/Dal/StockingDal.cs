using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;

namespace Automation.Plugins.Stocking.Dal
{
    public class StockingDal:AbstractBaseDal
    {
        /// <summary>
        ///更新烟道信息（用于交换烟道）
        /// </summary>
        /// <param name="lineCode">生产线</param>
        /// <param name="sourceChannel">来源烟道</param>
        /// <param name="targetChannel">目标烟道</param>
        /// <param name="targetChannelGroupNo">目标烟道组号</param>
        public void UpdateSortChannelUSED(string lineCode, string sourceChannel, string targetChannel, string targetChannelGroupNo)
        {
            var ra = TransactionScopeManager[Global.THOK_Stock_DB_NAME].NewRelationAccesser();
            string sql = "UPDATE AS_SC_SUPPLY SET CHANNELCODE='{0}',GROUPNO = '{1}' WHERE CHANNELCODE='{2}' AND LINECODE = '{3}' ";
            ra.DoCommand(string.Format(sql, targetChannel, targetChannelGroupNo, sourceChannel, lineCode));

            sql = "UPDATE AS_STOCK_OUT SET CHANNELCODE='{0}' WHERE CHANNELCODE='{2}' AND LINECODE = '{3}' ";
            ra.DoCommand(string.Format(sql, targetChannel, targetChannelGroupNo, sourceChannel, lineCode));
        }
    }
}
