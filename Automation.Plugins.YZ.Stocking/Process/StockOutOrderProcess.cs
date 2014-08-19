using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;

namespace Automation.Plugins.YZ.Stocking.Process
{
    public class StockOutOrderProcess : AbstractProcess
    {
        public override void Initialize()
        {
            Description = "写出库订单线程";
            base.Initialize();
        }

        public override void Execute()
        {
        }
    }
}
