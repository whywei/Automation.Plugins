using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.Share.ManualSupply.Properties;
using Automation.Plugins.Share.ManualSupply.View;

namespace Automation.Plugins.Share.ManualSupply.Action
{
    public class ProductCheckAction : AbstractAction
    {
        private const string rootKey = "kProductCheck";

        public override void Initialize()
        {
            RootKey = rootKey;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Add(new RootItem(rootKey, "卷烟查询") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey, "刷新", ProductCheckRefresh_Click) { ToolTipText = "刷新烟道信息", LargeImage = Resource.refresh_32x32 });
            this.Add(new SimpleActionItem(rootKey, "打印", Print_Click) { ToolTipText = "打印烟道信息", LargeImage = Resource.Print_32 });
            base.Activate();
        }

        private void ProductCheckRefresh_Click(object sender, EventArgs e)
        {
            (View as ProductCheckView).Refresh();
        }

        private void Print_Click(object sender, EventArgs e)
        {
            (View as ProductCheckView).Print();
        }
    }
}
