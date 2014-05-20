using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Plugins.MDJ.WCS.Model;
using DBRabbit;

namespace Automation.Plugins.MDJ.WCS.Dal
{
    [Serializable]
    class SRMDal : AbstractBaseDal
    {
        public SRMInfo GetSrmInfo(string Name)
        {
            var ra = TransactionScopeManager[Global.THOK_WCS_DB_NAME].NewRelationAccesser();
            string sql = string.Format(@"select * from wcs_srm where srmname = '{0}'", Name);
            var set = ra.DoQuery(sql);

            if (set.Tables.Count == 1 && set.Tables[0].Rows.Count == 1)
            {
                var table = set.Tables[0];
                SRMInfo srmInfo = new SRMInfo();
                var row = table.Rows[0];
                srmInfo.PlcServiceName = row["opcservice_name"].ToString();
                srmInfo.GetRequestName = row["get_request"].ToString();
                srmInfo.GetAllowName = row["get_allow"].ToString();
                srmInfo.GetCompleteName = row["get_complete"].ToString();
                srmInfo.PutRequestName = row["put_request"].ToString();
                srmInfo.PutAllowName = row["put_allow"].ToString();
                srmInfo.PutCompleteName = row["put_complete"].ToString();
                srmInfo.CancelTaskName = row["cancel_task"].ToString();
                return srmInfo;
            }
            return null;
        }
    }
}
