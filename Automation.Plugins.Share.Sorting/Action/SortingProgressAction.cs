using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.Share.Sorting.Properties;
using Automation.Plugins.Share.Sorting.View;

namespace Automation.Plugins.Share.Sorting.Action
{
    public class SortingProgressAction : AbstractAction
    {
        private const string rootKey = "yzSorting";

        public override void Initialize()
        {
            RootKey = rootKey;
            IsPreload = true;
        }

        public override void Activate()
        {
            base.Activate();
        }
    }
}
