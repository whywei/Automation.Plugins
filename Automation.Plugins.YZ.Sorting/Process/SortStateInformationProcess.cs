using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;

namespace Automation.Plugins.YZ.Sorting.Process
{
    public class SortStateInformationProcess : AbstractProcess
    {
        public override void Initialize()
        {
            Description = "分拣状态信息处理线程";
            base.Initialize();
        }

        public override void Execute()
        {
        }
    }
}
