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
    public class InventoryWholePalletScanProcess : AbstractProcess
    {
        private const string memoryServiceName = "MemoryTemporarilySingleDataService";
        private const string memoryItemName = "Handheld barcode scanning mode";

        private const string memoryServiceName1 = "MemoryPermanentSingleDataService";
        private const string memoryItemName1 = "InventoryTaskID";

        private const string memoryServiceName2 = "MemoryPermanentSingleDataService";
        private const string memoryItemName2 = "SkinName";

        private const string plcServiceName = "THOKPLC";
        private const string I_Whole_Pallet_StockIn_Scan_Request = "I_Whole_Pallet_StockIn_Scan_Request";
        private const string O_Whole_Pallet_StockIn_Task_Info = "O_Whole_Pallet_StockIn_Task_Info";
        private const string I_Whole_Pallet_StockIn_Task_Info = "I_Whole_Pallet_StockIn_Task_Info";
        private const string O_Whole_Pallet_StockIn_Task_Info_Complete = "O_Whole_Pallet_StockIn_Task_Info_Complete";

        private const int sleepTime = 1000;

        private TaskDal taskDal = new TaskDal();
        private PositionDal positionDal = new PositionDal();

        public override void Initialize()
        {
            Description = "盘点返库扫码";
            base.Initialize();
        }

        public override void Execute()
        {
            try
            {
                object state = AutomationContext.Read(memoryServiceName, memoryItemName);
                if (state == null || state.ToString() != "InventoryWholePalletScan") return;

                int taskID = 0, positionID = 0;
                state = AutomationContext.Read(memoryServiceName1, memoryItemName1);
                object obj = ObjectUtil.GetObjects(state);
                if (obj is Array)
                {
                    Array arrayObj = (Array)obj;
                    if (arrayObj.Length == 2)
                    {
                        taskID = Convert.ToInt32(arrayObj.GetValue(0));
                        positionID = Convert.ToInt32(arrayObj.GetValue(1));
                    }
                }
                if (taskID == 0 || positionID == 0) return;
                                
                //弹出输入窗，获取数量；
                state = AutomationContext.Read(memoryServiceName2, memoryItemName2);
                if (state != null)
                {
                    UserLookAndFeel.Default.SetSkinStyle(state.ToString());
                }

                InventoryDialog inventoryDialog = new InventoryDialog(taskID);
                if (inventoryDialog.ShowDialog() == DialogResult.OK)
                {
                    RestClient rest = new RestClient();
                    taskID = rest.FinishInventoryTask(taskID, inventoryDialog.RealQuantity);
                    if (taskID > 0)
                    {
                        string positionName = taskDal.GetTaskNextPosition(taskID);
                        if (positionName != string.Empty)
                        {
                            int[] data = new int[] { taskID, Convert.ToInt32(positionName), 1 };
                            AutomationContext.Write(plcServiceName, O_Whole_Pallet_StockIn_Task_Info, data);
                            Thread.Sleep(sleepTime);
                            obj = AutomationContext.Read(plcServiceName, I_Whole_Pallet_StockIn_Task_Info);
                            obj = ObjectUtil.GetObjects(obj);
                            if (obj is Array)
                            {
                                Array arrayObj = (Array)obj;
                                if (arrayObj.Length == 3
                                   && data[0] == Convert.ToInt32(arrayObj.GetValue(0))
                                   && data[1] == Convert.ToInt32(arrayObj.GetValue(1))
                                   && data[2] == Convert.ToInt32(arrayObj.GetValue(2)))
                                {
                                    AutomationContext.Write(plcServiceName, O_Whole_Pallet_StockIn_Task_Info_Complete, 1);
                                    AutomationContext.Write(memoryServiceName1, memoryItemName1, 0);
                                    positionDal.UpdateHasGoodsToFalse(positionID);
                                }
                            }
                        }
                    }
                    else if (taskID == -1)
                    {
                        positionDal.UpdateHasGoodsToFalse(positionID);
                        AutomationContext.Write(memoryServiceName1, memoryItemName1, 0);
                    }
                }
                inventoryDialog = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                Logger.Error("InventoryWholePalletScanProcess 出错，原因：" + ex.Message + "/n" + ex.StackTrace);
            }
        }
    }
}
