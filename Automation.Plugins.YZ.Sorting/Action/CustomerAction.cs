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
  public class CustomerAction : AbstractAction
    {
        private const string rootKey = "kCustomerQuery";

        public override void Initialize()
        {
            DefaultSortOrder = 1;
            RootKey = rootKey;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Add(new RootItem(rootKey, "客户查询") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey, "刷新", CustomerQueryRefresh_Click) { ToolTipText = "刷新客户查询", GroupCaption = "客户查询", LargeImage = Resources.refresh_32x32 });
            base.Activate();
        }

        private void CustomerQueryRefresh_Click(object sender, EventArgs e)
        {
            (View as CustomerQueryView).Refresh();
        }
    }
}