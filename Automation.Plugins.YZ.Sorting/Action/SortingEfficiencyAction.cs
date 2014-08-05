using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Plugins.YZ.Sorting.Properties;
using DotSpatial.Controls.Header;
using Automation.Plugins.YZ.Sorting.View;

namespace Automation.Plugins.YZ.Sorting.Action
{
    public class SortingEfficiencyAction : AbstractAction
    {
        private const string rootKey = "kSortingEfficiencyQuery";

        public override void Initialize()
        {
            RootKey = rootKey;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Add(new RootItem(rootKey, "分拣效率") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey, "刷新", SortingEfficiencyRefresh_Click) { ToolTipText = "分拣效率查询", LargeImage = Resources.refresh_32x32 });
            base.Activate();
        }

        private void SortingEfficiencyRefresh_Click(object sender, EventArgs e)
        {
            (View as SortingEfficiencyView).Refresh();
        }
    }
}
