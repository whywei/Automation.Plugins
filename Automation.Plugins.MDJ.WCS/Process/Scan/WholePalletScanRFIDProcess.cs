using System;
using Automation.Plugins.MDJ.WCS.Dal;
using Automation.Core;
using DBRabbit;
using System.Data;
using System.Threading;

namespace Automation.Plugins.MDJ.WCS.Process.Scan
{
    public class WholePalletScanRFIDProcess : AbstractProcess
    {
        private const string memoryServiceName1 = "MemoryTemporarilySingleDataService";
        private const string memoryItemName1 = "Handheld barcode scanning mode";

        private const string memoryServiceName2 = "MemoryTemporarilyDataService";
        private const string memoryItemName2 = "Handheld barcode scanning data";

        private const string plcServiceName = "THOKPLC";
        private const string I_Whole_Pallet_StockIn_Scan_Request = "I_Whole_Pallet_StockIn_Scan_Request";

        private const string scanServiceName = "ScanRFID";
        private const string scanItemName = "00";

        private ProductDal productDal = new ProductDal();

        public override void Initialize()
        {
            Description = "整托盘入库RFID扫码";
            base.Initialize();
        }

        //整托盘入库请求
        public override void Execute()
        {
            try
            {
                object state = AutomationContext.Read(memoryServiceName1, memoryItemName1);
                if (state == null || state.ToString() != "WholePalletScanRFID") return;

                state = AutomationContext.Read(plcServiceName, I_Whole_Pallet_StockIn_Scan_Request);
                state = ObjectUtil.GetObject(state);
                if (state == null || !Convert.ToBoolean(state)) return;

                //读取RFID信息，获取产品条码及数量；
                int productID = 0,quantity = 0;
                state = AutomationContext.Read(scanServiceName, scanItemName);
                object obj = ObjectUtil.GetObjects(state);
                if (obj is Array)
                {
                    Array arrayObj = (Array)obj;
                    if (arrayObj.Length == 2)
                    {
                        productID = productDal.GetProductNo(Convert.ToString(arrayObj.GetValue(0))); 
                        quantity = Convert.ToInt32(arrayObj.GetValue(1));
                    }
                }
                if (productID == 0 || quantity == 0) return;           

                int[] data = new int[] { productID, quantity };
                AutomationContext.Write(memoryServiceName2, memoryItemName2, data);
            }
            catch (Exception ex)
            {
                Logger.Error("WholePalletScanRFIDProcess 出错，原因：" + ex.Message + "/n" + ex.StackTrace);
            }
        }
    }
}
