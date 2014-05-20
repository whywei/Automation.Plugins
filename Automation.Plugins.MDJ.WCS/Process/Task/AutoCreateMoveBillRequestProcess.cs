using System;
using Automation.Plugins.MDJ.WCS.Dal;
using DBRabbit;
using System.Data;
using Automation.Core;
using Automation.Plugins.MDJ.WCS.Rest;
using System.Linq;

namespace Automation.Plugins.MDJ.WCS.Process.Task
{
    public class AutoCreateMoveBillRequestProcess : AbstractProcess
    {
        private static TaskDal taskDal = new TaskDal();
        private static PositionDal positionDal = new PositionDal();

        public override void Initialize()
        {
            Description = "自动生成补大品种拆盘位移库单";
            base.Initialize();
        }

        public override void Execute()
        {
            try
            {
                if (positionDal.HasEmptyAutomaticDemolitionPlatePosition())
                {
                    RestClient rest = new RestClient();
                    rest.AutoCreateMoveBill();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("AutoCreateMoveBillRequestProcess 出错，原因：" + ex.Message + "/n" + ex.StackTrace);
            }
        }
    }
}