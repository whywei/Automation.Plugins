using System;
using System.Collections.Generic;
using Automation.Core;
using DBRabbit;
using System.Data;
using Automation.Plugins.MDJ.WCS.Dal;
using System.Threading;
using Automation.MainPlugin.View;
using System.Linq; 

namespace THOK.WCS.Process.Task
{
    public class WholePalletTaskRequestProcess : AbstractProcess
    {
        private const string memoryServiceName = "MemoryTemporarilyDataService";
        private const string memoryItemName = "Handheld barcode scanning data";

        private const string memoryServiceName1 = "MemoryPermanentSingleDataService";
        private const string memoryItemName1 = "CigaretteScanInfoStack";

        private const string plcServiceName = "THOKPLC";
        private const string I_Whole_Pallet_StockIn_Scan_Request = "I_Whole_Pallet_StockIn_Scan_Request";
        private const string O_Whole_Pallet_StockIn_Task_Info = "O_Whole_Pallet_StockIn_Task_Info";
        private const string I_Whole_Pallet_StockIn_Task_Info = "I_Whole_Pallet_StockIn_Task_Info";
        private const string O_Whole_Pallet_StockIn_Task_Info_Complete = "O_Whole_Pallet_StockIn_Task_Info_Complete";

        private const int sleepTime = 1000;

        private TaskDal taskDal = new TaskDal();

        public IDictionary<string, CigaretteScanInfo> CigaretteScanInfoStack
        {
            get
            {
                return ScanManagerView.cigaretteScanInfoStack;
            }
            set
            {
                ScanManagerView.cigaretteScanInfoStack = value;
            }
        }

        public override void Initialize()
        {
            Description = "整托盘入库任务请求";
            base.Initialize();
        }

        public override void Execute()
        {
            try
            {
                int productID = 0, quantity = 0;
                object state = AutomationContext.Read(memoryServiceName, memoryItemName);               
                object obj = ObjectUtil.GetObjects(state);
                if (obj is Array)
                {
                    Array arrayObj = (Array)obj;
                    if (arrayObj.Length == 2)
                    {
                        productID = Convert.ToInt32(arrayObj.GetValue(0));
                        quantity = Convert.ToInt32(arrayObj.GetValue(1));
                    }
                }
                if (productID == 0 || quantity == 0) return;

                state = AutomationContext.Read(plcServiceName, I_Whole_Pallet_StockIn_Scan_Request);
                state = ObjectUtil.GetObject(state);
                if (state == null || !Convert.ToBoolean(state)) return;

                if (!ScanManagerView.InitCigaretteScanInfoStack()) return;
                var scanInfo = CigaretteScanInfoStack
                    .Where(c => c.Value.ProductNo == productID
                            && c.Value.State == "0")
                    .Select(c=> c.Value)
                    .FirstOrDefault();
                if (scanInfo == null)
                {
                    Logger.Info("当前整托盘入库品牌已经由件烟扫码开始进行扫码或没有扫码任务！");
                    return;
                }

                using (TransactionScopeManager TM = new TransactionScopeManager(true, IsolationLevel.Serializable))
                {
                    taskDal.TransactionScopeManager = TM;
                    int taskID = taskDal.GetTask(productID, quantity);
                    if (taskID != 0)
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
                                    //更新任务状态为，到达当前位置；
                                    taskDal.UpdateTaskPositionStateToArrived(taskID);
                                    AutomationContext.Write(plcServiceName, O_Whole_Pallet_StockIn_Task_Info_Complete, 1);
                                    TM.Commit();
                                    scanInfo.ScanQuantity += quantity;
                                    AutomationContext.Write(memoryServiceName1, memoryItemName1, CigaretteScanInfoStack);
                                    Logger.Info(string.Format("任务号[{0}]整托盘入库成功！",taskID));
                                    return;
                                }
                            }
                        }
                    }
                    Logger.Info(string.Format("整托盘入库失败，简码：[{0}]，数量： [{0}]", productID, quantity));
                }
            }
            catch (Exception ex)
            {
                Logger.Error("WholePalletTaskRequestProcess 出错，原因：" + ex.Message + "/n" + ex.StackTrace);
            }
        }
    }
}