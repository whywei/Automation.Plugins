using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Plugins.YZ.ManualSupply.Properties;
using DotSpatial.Controls.Header;
using Automation.Plugins.YZ.ManualSupply.View;

namespace Automation.Plugins.YZ.ManualSupply.Action
{
    public class MixedChannelAction : AbstractAction
    {
        private const string rootKey = "kMixedChannel";

        public override void Initialize()
        {
            DefaultSortOrder = 1;
            RootKey = rootKey;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Add(new RootItem(rootKey, "混合烟道") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey, "刷新", MixedChannelRefresh_Click) { ToolTipText = "刷新烟道信息", LargeImage = Resource.refresh_32x32 });
            this.Add(new SimpleActionItem(rootKey, "打印", Print_Click) { ToolTipText = "打印烟道信息", LargeImage = Resource.Print_32 });
            base.Activate();
        }

        private void MixedChannelRefresh_Click(object sender, EventArgs e)
        {
            (View as MixedChannelView).Refresh();
        }

        private void Print_Click(object sender, EventArgs e)
        {
            (View as MixedChannelView).Print();
        }
    }
}
