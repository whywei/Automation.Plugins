using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Plugins.YZ.Sorting.View;

namespace Automation.Plugins.YZ.Sorting.Process
{
    public class SortingInfoProgress : AbstractProcess
    {
        public override void Initialize()
        {
            Description = "分拣进度刷新控制";
            base.Initialize();
        }

        public override void Execute()
        {
            AutomationContext.GetView<SortingProgressView>().Refresh();
        }
    }
}
