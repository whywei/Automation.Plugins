using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;

namespace Automation.Plugins.YZ.Stocking.Process
{
    public class SupplyLedPositionInformationProcess : AbstractProcess
    {
        public override void Initialize()
        {
            Description = "出库LED线程";
            base.Initialize();
        }

        public override void Execute()
        {
        }
    }
}
