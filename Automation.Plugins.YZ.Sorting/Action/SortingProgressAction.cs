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
            this.Add(new RootItem(rootKey, "分拣进度") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey, "刷新", SortingProgressRefresh_Click) { ToolTipText = "分拣进度查询", GroupCaption = "分拣进度", LargeImage = Resources.refresh_32x32 });
            base.Activate();
        }

        private void SortingProgressRefresh_Click(object sender, EventArgs e)
        {
            (View as SortingProgressView).Refresh();
        }
    }
}
