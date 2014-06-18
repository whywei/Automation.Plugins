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
    public class OrderQueryAction : AbstractAction
    {
        private const string rootKey = "yzOrderQuery";

        public override void Initialize()
        {
            DefaultSortOrder = 1;
            RootKey = rootKey;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Add(new RootItem(rootKey, "订单查询") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey, "刷新", OrderQueryRefresh_Click) { ToolTipText = "刷新分拣订单", GroupCaption = "分拣订单查询", LargeImage = Resources.refresh_32x32 });
            base.Activate();
        }

        private void OrderQueryRefresh_Click(object sender, EventArgs e)
        {
            (View as OrderQueryView).Refresh();
        }
    }
}

