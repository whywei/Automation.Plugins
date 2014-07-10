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
  public class CacheOrderAction : AbstractAction
    {
        private const string rootKey = "kCacheOrderQuery";

        public override void Initialize()
        {
            DefaultSortOrder = 1;
            RootKey = rootKey;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Add(new RootItem(rootKey, "缓存订单") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey, "刷新", CacheOrderQueryRefresh_Click) { ToolTipText = "缓存订单查询", GroupCaption = "缓存订单", LargeImage = Resources.refresh_32x32 });
            base.Activate();
        }

        private void CacheOrderQueryRefresh_Click(object sender, EventArgs e)
        {
            (View as CacheOrderQueryView).Refresh();
        }
    }
}