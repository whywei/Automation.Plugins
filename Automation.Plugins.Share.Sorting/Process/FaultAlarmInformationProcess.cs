using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;

namespace Automation.Plugins.Share.Sorting.Process
{
    public class FaultAlarmInformationProcess : AbstractProcess
    {
        public override void Initialize()
        {
            Description = "故障报警信息处理线程";
            base.Initialize();
        }

        public override void Execute()
        {
        }
    }
}
