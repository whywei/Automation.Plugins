using Automation.Core;
using System.ComponentModel.Composition;
using Automation.Common.SRM;

namespace Automation.Plugins.YZ.WCS.SRM.Process
{
    public class SRM02HeartbeatRequstProcess : AbstractProcess
    {
        [Import]
        public SRMManager SRMManager { get; set; }

        public override void Initialize()
        {
            Description = "2号堆垛机心跳";
            base.Initialize();
        }

        public override void Execute()
        {
            SRMManager.FireHeartbeat("2号堆垛机");
        }
    }
}
