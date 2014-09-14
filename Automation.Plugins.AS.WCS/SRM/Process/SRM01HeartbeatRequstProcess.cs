using Automation.Core;
using System.ComponentModel.Composition;
using Automation.Common.SRM;

namespace Automation.Plugins.AS.WCS.SRM.Process
{
    public class SRM01HeartbeatRequstProcess : AbstractProcess
    {
        [Import]
        public SRMManager SRMManager { get; set; }

        public override void Initialize()
        {
            Description = "1号堆垛机心跳";
            base.Initialize();
        }

        public override void Execute()
        {
            SRMManager.FireHeartbeat("1号堆垛机");
        }
    }
}
