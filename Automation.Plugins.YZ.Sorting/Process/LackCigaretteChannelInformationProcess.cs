using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;

namespace Automation.Plugins.YZ.Sorting.Process
{
    public class LackCigaretteChannelInformationProcess : AbstractProcess
    {
        public override void Initialize()
        {
            Description = "缺烟烟道信息处理线程";
            base.Initialize();
        }

        public override void Execute()
        {
        }
    }
}
