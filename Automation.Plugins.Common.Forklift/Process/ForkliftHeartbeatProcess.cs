using Automation.Core;
using System.ComponentModel.Composition;

namespace Automation.Plugins.Common.Forklift.Process
{
    public class ForkliftHeartbeatProcess : AbstractProcess
    {
        [Import]
        public ForkliftManager ForkliftManager { get; set; }

        public override void Initialize()
        {
            Description = "叉车心跳";
            base.Initialize();
        }

        public override void Execute()
        {
            ForkliftManager.FireHeartbeat();
        }
    }
}
