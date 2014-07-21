using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;

namespace Automation.Plugins.YZ.Sorting.Process
{
    public class PackageNumbersInformationProcess : AbstractProcess
    {
        public override void Initialize()
        {
            Description = "包号信息处理处理线程";
            base.Initialize();
        }

        public override void Execute()
        {
        }
    }
}
