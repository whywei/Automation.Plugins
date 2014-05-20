using System;
using System.Collections.Generic;
using Automation.Core;
using DBRabbit;
using System.Data;
using Automation.Plugins.MDJ.WCS.Dal;
using System.Threading;
using Automation.Plugins.MDJ.WCS.View.Dialogs;
using System.Windows.Forms;
using DevExpress.LookAndFeel;

namespace Automation.Plugins.MDJ.WCS.Process.Scan
{
    public class WholePalletScanProcess : AbstractProcess
    {
        private const string memoryServiceName1 = "MemoryTemporarilySingleDataService";
        private const string memoryItemName1 = "Handheld barcode scanning mode";

        private const string memoryServiceName2 = "MemoryTemporarilyDataService";
        private const string memoryItemName2 = "Handheld barcode scanning data";

        private const string memoryServiceName3 = "MemoryPermanentSingleDataService";
        private const string memoryItemName3 = "SkinName";

        private const string scanServiceName = "Scanner02";
        private const string scanItemName = "00";

        private const string plcServiceName = "THOKPLC";
        private const string I_Whole_Pallet_StockIn_Scan_Request = "I_Whole_Pallet_StockIn_Scan_Request";

        public override void Initialize()
        {
            Description = "整托盘入库扫码";
            base.Initialize();
        }

        public override void Execute()
        {
            try
            {
                object state = AutomationContext.Read(memoryServiceName1, memoryItemName1);
                if (state == null || state.ToString() != "WholePalletScan") return;

                state = AutomationContext.Read(scanServiceName, scanItemName);
                if (state == null || state.ToString() == string.Empty) return;

                string barcode = state.ToString();

                state = AutomationContext.Read(plcServiceName, I_Whole_Pallet_StockIn_Scan_Request);
                state = ObjectUtil.GetObject(state);
                if (state == null || !Convert.ToBoolean(state))
                {
                    Logger.Info("当前PLC未请求扫码！");
                    return;
                }

                if (barcode == "NOREAD")
                {
                    string text = scanItemName + "号条码扫描器处理失败！详情：NOREAD！";
                    Logger.Error(text);
                    return;
                }

                if (barcode.Length == 32)
                {
                    barcode = barcode.Substring(2, 6);
                }

                if (barcode.Length != 6)
                {
                    string text = scanItemName + "号条码扫描器处理失败！详情：条码格式不正确！【" + barcode + "】";
                    Logger.Error(text);
                    return;
                }

                //弹出输入窗，获取数量；
                state = AutomationContext.Read(memoryServiceName3, memoryItemName3);
                if (state != null)
                {
                    UserLookAndFeel.Default.SetSkinStyle(state.ToString());
                }

                ScanDialog scanDialog = new ScanDialog();
                scanDialog.Text = "整盘入库手工扫码！";
                scanDialog.SetBarcode(barcode);
                if (scanDialog.ShowDialog() == DialogResult.OK)
                {
                    int[] data = new int[] { scanDialog.ProductNo, scanDialog.Quantity };
                    AutomationContext.Write(memoryServiceName2, memoryItemName2, data);
                }
                scanDialog = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                Logger.Error("WholePalletScanProcess 出错，原因：" + ex.Message + "/n" + ex.StackTrace);
            }
        }
    }
}
