using System;
using Automation.Plugins.MDJ.WCS.Dal;
using DBRabbit;
using System.Data;
using Automation.Core;
using Automation.Plugins.MDJ.WCS.Rest;
using System.Linq;

namespace Automation.Plugins.MDJ.WCS.Process.Task
{
    public class UpgradeTaskLevelProcess : AbstractProcess
    {
        private const int count = 2;
        private const string plcServiceName = "THOKPLC";
        private const string I_Upgrade_Task_Level_Request = "I_Upgrade_Task_Level_Request";

        private static TaskDal taskDal = new TaskDal();
        private static PositionDal positionDal = new PositionDal();

        public override void Initialize()
        {
            Description = "处理提升任务优化级，优先给缺烟拆盘位补货";
            base.Initialize();
        }

        public override void Execute()
        {
            try
            {
                for (int i = 1; i <= count; i++)
                {
                    object state = AutomationContext.Read(plcServiceName, I_Upgrade_Task_Level_Request + i);
                    state = ObjectUtil.GetObject(state);
                    if (state == null || state.ToString() == "0" || state.ToString() == string.Empty) continue;

                    int positionID = positionDal.GetPositionIDByPositionName(state.ToString());
                    taskDal.UpgradeTaskLevel(positionID);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("UpgradeTaskLevelProcess 出错，原因：" + ex.Message + "/n" + ex.StackTrace);
            }
        }
    }
}