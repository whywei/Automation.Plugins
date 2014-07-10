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
    public class HandSuppyAction : AbstractAction
    {
        private const string rootKey = "kHandSuppyQuery";

        public override void Initialize()
        {
            RootKey = rootKey;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Add(new RootItem(rootKey, "手工补货") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey, "刷新", HandSuppyRefresh_Click) { ToolTipText = "手工补货查询", GroupCaption = "手工补货", LargeImage = Resources.refresh_32x32 });
            base.Activate();
        }

        private void HandSuppyRefresh_Click(object sender, EventArgs e)
        {
            (View as HandSuppyView).Refresh();
        }
    }
}
