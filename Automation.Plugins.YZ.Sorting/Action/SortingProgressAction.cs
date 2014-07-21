using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.YZ.Sorting.Properties;
using Automation.Plugins.YZ.Sorting.View;

namespace Automation.Plugins.YZ.Sorting.Action
{
    public class SortingProgressAction : AbstractAction
    {
        private const string rootKey = "kSortingProgressQuery";

        public override void Initialize()
        {
            RootKey = rootKey;
            IsPreload = false;
        }

        public override void Activate()
        {
            base.Activate();
        }
    }
}
