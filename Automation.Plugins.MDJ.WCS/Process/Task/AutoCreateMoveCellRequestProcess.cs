using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Plugins.MDJ.WCS.Dal;
using Automation.Plugins.MDJ.WCS.Rest;

namespace Automation.Plugins.MDJ.WCS.Process.Task
{
    class AutoCreateMoveCellRequestProcess : AbstractProcess
    {
        public override void Initialize()
        {
            Description = "自动生成同品牌货位调整移库单";
            base.Initialize();
        }

        public override void Execute()
        {
            try
            {
                RestClient rest = new RestClient();
                rest.CreateAutoMoveCell();
            }
            catch (Exception ex)
            {
                Logger.Error("AutoCreateMoveCellRequestProcess 出错，原因：" + ex.Message + "/n" + ex.StackTrace);
            }
        }
    }
}
