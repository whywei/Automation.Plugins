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
    public class SortingRecordAction : AbstractAction
    {
        private const string rootKey = "kSortingRecordQuery";

        public override void Initialize()
        {
            RootKey = rootKey;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Add(new RootItem(rootKey, "下单记录") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey, "刷新", SortingRecordRefresh_Click) { ToolTipText = "下单记录查询", GroupCaption = "下单记录", LargeImage = Resources.refresh_32x32 });
            base.Activate();
        }

        private void SortingRecordRefresh_Click(object sender, EventArgs e)
        {
            (View as SortingRecordView).Refresh();
        }
    }
}
