using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.YZ.Sorting.View;
using Automation.Plugins.YZ.Sorting.Properties;
using Automation.Plugins.YZ.Sorting.Dal;
using Automation.Plugins.YZ.Sorting.View.Dialogs;
using Automation.Plugins.YZ.Sorting.View.Controls;

namespace Automation.Plugins.YZ.Sorting.Action
{
    public class ChannelAction : AbstractAction
    {
        private const string rootKey = "kChannelQuery";
        ChannelDal channelDal = new ChannelDal();

        public override void Initialize()
        {
            DefaultSortOrder = 1;
            RootKey = rootKey;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Add(new RootItem(rootKey, "烟道查询") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey, "刷新", ChannelQueryRefresh_Click) { ToolTipText = "刷新烟道查询", GroupCaption = "烟道查询", LargeImage = Resources.refresh_32x32 });
            this.Add(new SimpleActionItem(rootKey, "烟道交换", ChannelExchange_Click) { ToolTipText = "", GroupCaption = "烟道交换", LargeImage = Resources.SortChannelSwap_32 });
            base.Activate();
        }

        private void ChannelQueryRefresh_Click(object sender, EventArgs e)
        {
            (View as ChannelQueryView).Refresh();
        }

        public void ChannelExchange_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("你来写吧！");
        }
    }
}
