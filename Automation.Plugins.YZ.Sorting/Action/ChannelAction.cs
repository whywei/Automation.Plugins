using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.YZ.Sorting.View;
using Automation.Plugins.YZ.Sorting.Properties;

namespace Automation.Plugins.YZ.Sorting.Action
{
  public  class ChannelAction: AbstractAction
    {
        private const string rootKey = "kChannelQuery";

        public override void Initialize()
        {
            DefaultSortOrder = 1;
            RootKey = rootKey;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Add(new RootItem(rootKey, "烟道查询") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey,"刷新", ChannelQueryRefresh_Click) { ToolTipText = "刷新烟道查询", GroupCaption = "烟道查询", LargeImage = Resources.refresh_32x32 });
            base.Activate();
        }

        private void ChannelQueryRefresh_Click(object sender, EventArgs e)
        {
            (View as ChannelQueryView ).Refresh();
        }
    }
}