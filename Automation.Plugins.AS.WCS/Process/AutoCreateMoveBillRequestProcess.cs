using System;
using Automation.Core;
using Automation.Plugins.AS.WCS.Rest;

namespace Automation.Plugins.AS.WCS.Process
{
    public class AutoCreateMoveBillRequestProcess : AbstractProcess
    {
        public override void Initialize()
        {
            Description = "自动生成补大品种拆盘位移库单";
            base.Initialize();
        }

        public override void Execute()
        {
            try
            {
                RestClient rest = new RestClient();
                rest.AutoCreateMoveBill();
            }
            catch (Exception ex)
            {
                Logger.Error("AutoCreateMoveBillRequestProcess 出错，原因：" + ex.Message + "/n" + ex.StackTrace);
            }
        }
    }
}