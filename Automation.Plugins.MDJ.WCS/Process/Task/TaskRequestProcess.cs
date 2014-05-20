using System;
using Automation.Plugins.MDJ.WCS.Dal;
using System.Threading;
using DBRabbit;
using System.Data;
using Automation.Core;

namespace Automation.Plugins.MDJ.WCS.Process.Task
{
    public class TaskRequestProcess : AbstractProcess
    {
        private const string plcServiceName = "THOKPLC";
        private const string I_StockIn_Task_Info_Request = "I_StockIn_Task_Info_Request";
        private const string O_StockIn_Task_Info = "O_StockIn_Task_Info";
        private const string I_StockIn_Task_Info = "I_StockIn_Task_Info";
        private const string O_StockIn_Task_Info_Complete = "O_StockIn_Task_Info_Complete";

        private const int sleepTime = 1000;

        private TaskDal taskDal = new TaskDal();

        public override void Initialize()
        {
            Description = "处理入库任务申请";
            base.Initialize();
        }

        //码垛完成后申请分配入库任务；
        public override void Execute()
        {
            try
            {
                int productID = 0, quantity = 0, taskID = 0;
                object state = AutomationContext.Read(plcServiceName, I_StockIn_Task_Info_Request);
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

                if (productID == 0 || quantity == 0)
                {
                    return;
                }

                int[] data = new int[] { productID, quantity };
                string msg = "TaskRequest : ";
                for (int i = 0; i < data.Length; i++)
                    msg += string.Format("[{0}]", data[i]);
                Logger.Info(msg);

                using (TransactionScopeManager TM = new TransactionScopeManager(true, IsolationLevel.Serializable))
                {
                    taskDal.TransactionScopeManager = TM;
                    taskID = taskDal.GetTask(productID, quantity);
                    if (taskID != 0)
                    {
                        string positionName = taskDal.GetTaskNextPosition(taskID);
                        if (positionName != string.Empty)
                        {
                            data = new int[] { taskID, Convert.ToInt32(positionName), 1 };
                            AutomationContext.Write(plcServiceName, O_StockIn_Task_Info, data);
                            Thread.Sleep(sleepTime);
                            obj = AutomationContext.Read(plcServiceName, I_StockIn_Task_Info);
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
                                    AutomationContext.Write(plcServiceName, O_StockIn_Task_Info_Complete, 1);
                                    TM.Commit();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("TaskRequestProcess 出错，原因：" + ex.Message + "/n" + ex.StackTrace);
            }
        }
    }
}
