using System;
using Automation.Plugins.MDJ.WCS.Dal;
using DBRabbit;
using System.Data;
using Automation.Core;
using Automation.Plugins.MDJ.WCS.Rest;
using System.Linq;

namespace Automation.Plugins.MDJ.WCS.Process.Task
{
    public class TaskArriveDataProcess : AbstractProcess
    {
        private const string memoryServiceName = "MemoryPermanentDataService";
        private const string memoryItemName = "TaskArriveData";
        private const string memoryItemName3 = "TaskFinishData";

        private const string memoryServiceName1 = "MemoryPermanentSingleDataService";
        private const string memoryItemName1 = "StockOutTaskID";
        private const string memoryItemName2 = "InventoryTaskID";

        private static TaskDal taskDal = new TaskDal();
        private static PositionDal positionDal = new PositionDal();

        public override void Initialize()
        {
            Description = "任务到达数据处理";
            base.Initialize();
        }

        //任务输送到某一位置后，通知更新状态。【入库口任务到位，密集存储道穿过到位】
        public override void Execute()
        {
            int[] data = null; 
            try
            {
                string positionName = string.Empty;
                int taskID = 0;

                object state = AutomationContext.Read(memoryServiceName, memoryItemName);
                object obj = ObjectUtil.GetObjects(state);
                if (obj is Array)
                {
                    Array arrayObj = (Array)obj;
                    if (arrayObj.Length == 2)
                    {
                        positionName = arrayObj.GetValue(0).ToString();
                        taskID = Convert.ToInt32(arrayObj.GetValue(1));
                    }
                }

                if (positionName == string.Empty || positionName == "0" || taskID == 0) return;

                data = new int[] { Convert.ToInt32(positionName), taskID };

                using (TransactionScopeManager TM = new TransactionScopeManager(true, IsolationLevel.Serializable))
                {
                    positionDal.TransactionScopeManager = TM;
                    taskDal.TransactionScopeManager = TM;

                    int positionID = positionDal.GetPositionIDByPositionName(positionName);
                    int currentPositionID = taskDal.GetCurrentPositionID(taskID);
                    int nextPositionID = taskDal.GetNextPositionID(taskID);
                    int endPositionID = taskDal.GetEndPositionID(taskID);
                    if (positionID != 0 && currentPositionID != endPositionID && positionID == nextPositionID)
                    {
                        positionDal.UpdateHasGoodsToTrue(positionID);
                        taskDal.UpdateTaskPosition(taskID, positionID);
                        taskDal.UpdateTaskPositionStateToArrived(taskID);

                        if (positionID == endPositionID)
                        {
                            string orderType = taskDal.GetOrderType(taskID);
                            if (orderType == "03")//出库单
                            {
                                if (!AutomationContext.Write(memoryServiceName1, memoryItemName1, new int[] { taskID, positionID }))
                                {
                                    AutomationContext.Write(memoryServiceName, memoryItemName, data);
                                    Logger.Error(string.Format("{0} 完成[{1}]任务失败！", Name, taskID));
                                    return;
                                }
                            }
                            else if (orderType == "04")//盘点单
                            {
                                if (!AutomationContext.Write(memoryServiceName1, memoryItemName2, new int[] { taskID, positionID }))
                                {
                                    AutomationContext.Write(memoryServiceName, memoryItemName, data);
                                    Logger.Error(string.Format("{0} 完成[{1}]任务失败！", Name, taskID));
                                    return;
                                }
                            }
                            else
                            {
                                if (!AutomationContext.Write(memoryServiceName, memoryItemName3, taskID))
                                {
                                    AutomationContext.Write(memoryServiceName, memoryItemName, data);
                                    Logger.Error(string.Format("{0} 完成[{1}]任务失败！", Name, taskID));
                                    return;
                                }
                            }
                        }
                        TM.Commit();
                    }
                    else
                    {
                        Logger.Error(string.Format("{0} 处理[{1}]任务到达失败，到达位置{2}与任务不符！", Name, taskID,positionName));
                    }
                }
            }
            catch (Exception ex)
            {
                if (data != null)
                {
                    AutomationContext.Write(memoryServiceName, memoryItemName, data);
                }
                Logger.Error("TaskArriveDataProcess 出错，原因：" + ex.Message + "/n" + ex.StackTrace);
            }
        }
    }
}