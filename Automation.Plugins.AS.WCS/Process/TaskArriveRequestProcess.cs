using System;
using Automation.Core;
using Automation.Plugins.AS.WCS.Rest;
using System.Linq;
using System.Collections.Generic;

namespace Automation.Plugins.AS.WCS.Process
{
    public class TaskArriveRequestProcess : AbstractProcess
    {
        public override void Initialize()
        {
            Description = "处理任务到达请求";
            base.Initialize();
        }

        private IList<int[]> processedTasks = new List<int[]>();

        public override void Execute()
        {
            try
            {
                RestClient rest = new RestClient();

                var tasks = Ops.ReadArray<int>(Global.PLC_SERVICE_NAME, "n_I_Task_Arrive_Request")
                    .ConvertToNewArray(2).Where(a => a[0] != 0 && a[1] != 0);

                foreach (var processedTask in processedTasks)
                {
                    if (!tasks.Any(t => t[0] == processedTask[0] && t[1] == processedTask[1]))
                    {
                        processedTask[0] = 0;
                        processedTask[1] = 0;
                    }
                }

                processedTasks = processedTasks.Where(a => a[0] != 0 && a[1] != 0).ToList();

                foreach (var task in tasks)
                {
                    if (!processedTasks.Any(t=>t[0] == task[0] && t[1] == task[1]) && rest.Arrive(task[1], task[0]))
                    {
                        processedTasks.Add(task);
                    }
                }                
            }
            catch (Exception ex)
            {
                Logger.Error("TaskArriveRequestProcess 出错，原因：" + ex.Message + "/n" + ex.StackTrace);
            }
        }
    }
}