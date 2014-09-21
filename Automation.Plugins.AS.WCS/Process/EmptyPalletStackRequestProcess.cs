using System;
using Automation.Core;
using Automation.Plugins.AS.WCS.Rest;
using System.Collections.Generic;
using System.Linq;

namespace Automation.Plugins.AS.WCS.Proces
{
    public class EmptyPalletStackRequestProcess : AbstractProcess
    {
        public override void Initialize()
        {
            Description = "处理空托盘叠垛请求";
            base.Initialize();
        }

        private IList<int[]> processedTasks = new List<int[]>();

        public override void Execute()
        {
            try
            {
                RestClient rest = new RestClient();

                var tasks = Ops.ReadArray<int>(Global.PLC_SERVICE_NAME, "n_I_Disassemble_Complete_Request")
                        .ConvertToNewArray(1).Where(a => a[0] != 0);

                foreach (var processedTask in processedTasks)
                {
                    if (!tasks.Any(t => t[0] == processedTask[0]))
                    {
                        processedTask[0] = 0;
                    }
                }

                processedTasks = processedTasks.Where(a => a[0] != 0).ToList();

                foreach (var task in tasks)
                {
                    if (!processedTasks.Any(t => t[0] == task[0]) && rest.CreateNewTaskForEmptyPalletStack(task[0]))
                    {
                        processedTasks.Add(task);
                        Logger.Info(string.Format("EmptyPalletStackRequest : 位置[{0}]生成叠托盘任务成功！", task[0]));
                    }
                } 
            }
            catch (Exception ex)
            {
                Logger.Error("EmptyPalletStackRequestProcess 出错，原因：" + ex.Message + "/n" + ex.StackTrace);
            }
        }
    }
}