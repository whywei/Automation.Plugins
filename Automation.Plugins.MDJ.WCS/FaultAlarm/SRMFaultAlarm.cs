using System;
using Automation.Core;
using Automation.Plugins.MDJ.WCS.Dal;
using Automation.Plugins.MDJ.WCS.Rest;
using System.Collections.Generic;
using Automation.Plugins.MDJ.WCS.Model;
using System.Linq;

namespace Automation.Plugins.MDJ.WCS.FaultAlarm
{
    public class SRMFaultAlarm : AbstractFaultAlarm
    {
        private const string memoryServiceName = "MemoryPermanentSingleDataService";
        private IDictionary<string, Device.SRM> SRMS = new Dictionary<string, Device.SRM>();

        public override void Refresh()
        {
            try
            {
                IList<int> alarmCodes = null;
                FaultAlarmInfo[] faultAlarmInfos = null;
                AlarmInfoDal alarmInfoDal = new AlarmInfoDal();

                if (InitSRMS("SRM01"))
                {
                    alarmCodes = SRMS["SRM01"].AlarmCodes;
                    faultAlarmInfos = alarmInfoDal.SelectAlarmInfoByAlarmCode(alarmCodes);
                    AutomationContext.RefreshFaultAlarm("SRM01", faultAlarmInfos);
                }

                if (InitSRMS("SRM02"))
                {
                    alarmCodes = SRMS["SRM02"].AlarmCodes;
                    faultAlarmInfos = alarmInfoDal.SelectAlarmInfoByAlarmCode(alarmCodes);
                    AutomationContext.RefreshFaultAlarm("SRM02", faultAlarmInfos);
                }

                if (InitSRMS("SRM03"))
                {
                    alarmCodes = SRMS["SRM03"].AlarmCodes;
                    faultAlarmInfos = alarmInfoDal.SelectAlarmInfoByAlarmCode(alarmCodes);
                    AutomationContext.RefreshFaultAlarm("SRM03", faultAlarmInfos);
                }

                if (InitSRMS("SRM04"))
                {
                    alarmCodes = SRMS["SRM04"].AlarmCodes;
                    faultAlarmInfos = alarmInfoDal.SelectAlarmInfoByAlarmCode(alarmCodes);
                    AutomationContext.RefreshFaultAlarm("SRM04", faultAlarmInfos);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("FaultAlarmProcess 出错，原因：" + ex.Message + "/n" + ex.StackTrace);
            }
        }

        public override void Reset()
        {
            if (InitSRMS("SRM01")) SRMS["SRM01"].Reset();
            if (InitSRMS("SRM02")) SRMS["SRM02"].Reset();
            if (InitSRMS("SRM03")) SRMS["SRM03"].Reset();
            if (InitSRMS("SRM04")) SRMS["SRM04"].Reset();
        }

        private bool InitSRMS(string srmName)
        {
            if (!SRMS.ContainsKey(srmName))
            {
                var srm = AutomationContext.Read(memoryServiceName, srmName) as Device.SRM;

                if (srm != null)
                {
                    SRMS.Add(srmName, srm);
                    return true;
                }
                return false;
            }
            return true;
        }
    }
}