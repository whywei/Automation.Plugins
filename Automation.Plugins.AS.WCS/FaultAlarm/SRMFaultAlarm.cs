using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Plugins.AS.WCS.Dal;
using System.ComponentModel.Composition;
using Automation.Plugins.Common.SRM;
using Automation.Plugins.AS.WCS.SRM;

namespace Automation.Plugins.AS.WCS.FaultAlarm
{
    public class SRMFaultAlarm : AbstractFaultAlarm
    {
        [Import(typeof(ISRM))]
        public SRM01 Srm01 { get; set; }

        public override void Refresh()
        {
            SRM01 srm = new SRM01();
            try
            {
                IList<int> alarmCodes = null;
                FaultAlarmInfo[] faultAlarmInfos = null;
                AlarmInfoDal alarmInfoDal = new AlarmInfoDal();
                alarmCodes = Srm01.AlarmCodes;
                faultAlarmInfos = alarmInfoDal.SelectAlarmInfoByAlarmCode(alarmCodes);
                AutomationContext.RefreshFaultAlarm("SRM01", faultAlarmInfos);
            }
            catch (Exception ex)
            {
                Logger.Error("FaultAlarmProcess 出错，原因：" + ex.Message + "/n" + ex.StackTrace);
            }
        }

        public override void Reset()
        {
        }
    }
}
