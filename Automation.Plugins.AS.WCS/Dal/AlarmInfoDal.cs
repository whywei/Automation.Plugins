using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRabbit;
using Automation.Core;

namespace Automation.Plugins.AS.WCS.Dal
{
    public class AlarmInfoDal : AbstractBaseDal
    {
        public FaultAlarmInfo[] SelectAlarmInfoByAlarmCode(IList<int> AlarmCodes)
        {
            IList<FaultAlarmInfo> faultAlarmInfos = new List<FaultAlarmInfo>();
            if (AlarmCodes.Count > 0)
            {
                string AlarmCodeStr = "('";
                foreach (var a in AlarmCodes)
                {
                    AlarmCodeStr += a.ToString() + "','";
                }
                AlarmCodeStr = AlarmCodeStr.Remove(AlarmCodeStr.LastIndexOf("','"), 2);
                AlarmCodeStr += ")";
                var ra = TransactionScopeManager[Global.SERVER_DATABASE_NAME].NewRelationAccesser();
                string sql = string.Format(@"select * from wcs_alarm_info where alarm_code in {0}", AlarmCodeStr);
                var set = ra.DoQuery(sql);

                for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                {
                    FaultAlarmInfo FaultAlarmInfo = new FaultAlarmInfo();
                    FaultAlarmInfo.FaultCode = set.Tables[0].Rows[i]["alarm_code"].ToString();
                    FaultAlarmInfo.Description = set.Tables[0].Rows[i]["description"].ToString();
                    faultAlarmInfos.Add(FaultAlarmInfo);
                }
            }

            return faultAlarmInfos.ToArray();
        }
    }
}
