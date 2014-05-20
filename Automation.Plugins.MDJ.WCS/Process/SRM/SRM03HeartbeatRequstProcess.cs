using Automation.Core;
using Automation.Plugins.MDJ.WCS.Device.TaskFactory;

namespace Automation.Plugins.MDJ.WCS.Process.SRM
{
    public class SRM03HeartbeatRequstProcess : AbstractProcess
    {
        private const string memoryServiceName = "MemoryPermanentSingleDataService";
        private const string memoryItemName = "SRM03";

        private Device.SRM srm = null;

        public override void Initialize()
        {
            Description = "3号堆垛机心跳";
            base.Initialize();
        }

        public override void Stop()
        {
            if (srm != null)
            {
                srm.SetAuto(false);
            }
            base.Stop();
        }

        public override void Execute()
        {
            if (srm == null)
            {
                srm = AutomationContext.Read(memoryServiceName, memoryItemName) as Device.SRM;
                if (srm == null)
                {
                    srm = new Device.SRM() { Name = "SRM03" };
                    //srm.TaskFactories.Add(new AbnormityTaskFactory());
                    srm.TaskFactories.Add(new DefaultTaskFactory());
                    AutomationContext.Write(memoryServiceName, memoryItemName, srm);
                }
            }

            if (srm != null)
            {
                srm.Scan();
                AutomationContext.Write(memoryServiceName, memoryItemName, srm);
            }
        }
    }
}
