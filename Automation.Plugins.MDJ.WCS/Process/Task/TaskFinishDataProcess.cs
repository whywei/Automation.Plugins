using System;
using Automation.Plugins.MDJ.WCS.Dal;
using System.Threading;
using DBRabbit;
using System.Data;
using Automation.Core;
using Automation.Plugins.MDJ.WCS.Rest;

namespace Automation.Plugins.MDJ.WCS.Process.Task
{
    public class TaskFinishDataProcess : AbstractProcess
    {
        private const string memoryServiceName = "MemoryPermanentDataService";
        private const string memoryItemName = "TaskFinishData";

        private TaskDal taskDal = new TaskDal();

        public override void Initialize()
        {
            Description = "任务完成数据处理";
            base.Initialize();
        }        

        public override void Execute()
        {
            int taskID = 0;
            try
            {
                object state = AutomationContext.Read(memoryServiceName, memoryItemName);
                if (state == null) return;

                taskID = Convert.ToInt32(state);
                if (taskID <= 0) return;

                string orderType = taskDal.GetOrderType(taskID);
                string orderID = taskDal.GetOrderID(taskID);
                int allotID = taskDal.GetAllotID(taskID);
                string originCellCode = taskDal.GetOriginCellCode(taskID);
                string targetCellCode = taskDal.GetTargetCellCode(taskID);
                string originStorageCode = taskDal.GetOriginStorageCode(taskID);
                string targetStorageCode = taskDal.GetTargetStorageCode(taskID);
                
                RestClient rest = new RestClient();
                if (!rest.FinishTask(taskID, orderType, orderID, allotID, originCellCode, targetCellCode,originStorageCode, targetStorageCode))
                {
                    AutomationContext.Write(memoryServiceName, memoryItemName, taskID);
                    Logger.Error(string.Format("{0} 完成[{1}]任务失败！", Name, taskID));
                }
                else
                {
                    taskDal.UpdateTaskStateToExecuted(taskID);
                    taskID = 0;
                }
            }
            catch (Exception ex)
            {
                if (taskID >= 0)
                {
                    AutomationContext.Write(memoryServiceName, memoryItemName, taskID);
                }
                Logger.Error("TaskFinishDataProcess 出错，原因：" + ex.Message + "/n" + ex.StackTrace);
            }
        }
    }
}
