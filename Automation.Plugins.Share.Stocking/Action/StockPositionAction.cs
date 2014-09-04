using System;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.Share.Stocking.Properties;
using Automation.Plugins.Share.Stocking.View;

namespace Automation.Plugins.Share.Stocking.Action
{
    public class StockPositionAction : AbstractAction
    {
        private const string rootKey = "kStockPosition";

        public override void Initialize()
        {
            RootKey = rootKey;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Add(new RootItem(rootKey, "拆盘位置") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey, "刷新", Refresh_Click) { LargeImage = Resources.refresh_32x32 });
            this.Add(new SimpleActionItem(rootKey, "打印", Print_Click) { LargeImage = Resources.Print_32 });
            base.Activate();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            (View as StockPositionView).Refresh();
        }

        private void Print_Click(object sender, EventArgs e)
        {
            (View as StockPositionView).Print();
        }
    }
}
