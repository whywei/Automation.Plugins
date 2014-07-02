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
    class ChannelAllotAction:AbstractAction
    {

        private const string rootKey = "yzchannelallotQuery";

        public override void Initialize()
        {
            DefaultSortOrder = 1;
            RootKey = rootKey;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Add(new RootItem(rootKey, "烟道盘点") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey, "刷新", SRM_Click) { ToolTipText = "烟道盘点", LargeImage = Resources.refresh_32x32 });
            base.Activate();         
        }
        private void SRM_Click(object sender, EventArgs e)
        {
            (View as SortChannelCheckView).Refresh();
        }
    }
}