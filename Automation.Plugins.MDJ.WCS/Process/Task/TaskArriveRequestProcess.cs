using System;
using Automation.Plugins.MDJ.WCS.Dal;
using DBRabbit;
using System.Data;
using Automation.Core;
using Automation.Plugins.MDJ.WCS.Rest;
using System.Linq;

namespace Automation.Plugins.MDJ.WCS.Process.Task
{
    public class TaskArriveRequestProcess : AbstractProcess
    {
        private const int count = 8;
        private const string plcServiceName = "THOKPLC";
        private const string I_Task_Arrive_Process_Request = "I_Task_Arrive_Process_Request";
        private const string O_Task_Arrive_Process_Complete = "O_Task_Arrive_Process_Complete";

        private const string memoryServiceName = "MemoryPermanentDataService";
        private const string memoryItemName = "TaskArriveData";

        public override void Initialize()
        {
            Description = "处理任务到达请求";
            base.Initialize();
        }

        //任务输送到某一位置后，通知更新状态。【入库口任务到位，密集存储道穿过到位】
        public override void Execute()
        {
            try
            {
                for (int i = 1; i <= count; i++)
                {
                    string positionName = string.Empty;
                    int taskID = 0;

                    object state = AutomationContext.Read(plcServiceName, I_Task_Arrive_Process_Request + i);
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

                    if (positionName == string.Empty || positionName == "0" || taskID == 0)
                    {
                        continue;
                    }

                    int[] data = new int[] { Convert.ToInt32(positionName), taskID };
                    AutomationContext.Write(memoryServiceName, memoryItemName, data);
                    AutomationContext.Write(plcServiceName, O_Task_Arrive_Process_Complete + i, data);
                    Logger.Info(string.Format("TaskArriveRequest : {0}", data.ConvertToString()));
                }
            }
            catch (Exception ex)
            {
                Logger.Error("TaskArriveRequestProcess 出错，原因：" + ex.Message + "/n" + ex.StackTrace);
            }
        }
    }
}