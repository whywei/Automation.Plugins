using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Automation.Core;
using Automation.Plugins.YZ.ManualSupply.View;

namespace Automation.Plugins.YZ.ManualSupply.Action
{
    public class CurrentTaskAction : AbstractAction
    {
        private const string rootKey = "kManualSupply";

        public override void Initialize()
        {
            DefaultSortOrder = 1;
            RootKey = rootKey;
        }
    }
}
