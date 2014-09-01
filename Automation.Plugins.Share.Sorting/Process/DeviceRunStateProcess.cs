using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;

namespace Automation.Plugins.YZ.Sorting.Process
{
    public class DeviceRunStateProcess : AbstractProcess
    {
        public override void Initialize()
        {
            Description = "设备运行状态处理线程";
            base.Initialize();
        }

        public override void Execute()
        {
        }
    }
}
