using System;
using System.Collections.Generic;
using Automation.Core;
using DBRabbit;
using System.Data;
using Automation.Plugins.MDJ.WCS.Dal;
using System.Threading;
using Automation.Plugins.MDJ.WCS.View.Dialogs;
using System.Windows.Forms;
using Automation.Plugins.MDJ.WCS.Rest;
using DevExpress.XtraBars.Helpers;
using DevExpress.LookAndFeel;

namespace Automation.Plugins.MDJ.WCS.Process.Scan
{
    public class ScanCodeFaultResetProcess : AbstractProcess
    {
        private const string memoryServiceName = "MemoryTemporarilySingleDataService";
        private const string memoryItemName = "Handheld barcode scanning mode";

        private const string scanServiceName1 = "Scanner01";
        private const string scanItemName1 = "01";

        private const string scanServiceName2 = "Scanner02";
        private const string scanItemName2 = "00";

        private const string plcServiceName = "THOKPLC";
        private const string O_Stockin_Scan_Alarm = "O_Stockin_Scan_Alarm";

        public override void Initialize()
        {
            Description = "件烟扫码故障复位";
            base.Initialize();
        }

        public override void Execute()
        {
            try
            {
                object state = AutomationContext.Read(memoryServiceName, memoryItemName);
                if (state == null || state.ToString() != "ScanCodeFaultReset") return;

                state = AutomationContext.Read(scanServiceName2, scanItemName2);
                if (state == null || state.ToString() == string.Empty) return;
                string barcode = state.ToString();

                state = AutomationContext.Read(plcServiceName, O_Stockin_Scan_Alarm);
                state = ObjectUtil.GetObject(state);
                if (state == null || state.ToString() != "1") return;

                AutomationContext.Write(scanServiceName1, scanItemName1, barcode);
            }
            catch (Exception ex)
            {
                Logger.Error("ScanCodeFaultResetProcess 出错，原因：" + ex.Message + "/n" + ex.StackTrace);
            }
        }
    }
}
