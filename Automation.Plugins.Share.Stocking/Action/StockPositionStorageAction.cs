using System;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.Share.Stocking.Properties;
using Automation.Plugins.Share.Stocking.View;

namespace Automation.Plugins.Share.Stocking.Action
{
    public class StockPositionStorageAction : AbstractAction
    {
        private const string rootKey = "kStockPositionStorage";

        public override void Initialize()
        {
            RootKey = rootKey;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Add(new RootItem(rootKey, "位置库存") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey, "刷新", Refresh_Click) { LargeImage = Resources.refresh_32x32 });
            this.Add(new SimpleActionItem(rootKey, "打印", Print_Click) { LargeImage = Resources.Print_32 });
            base.Activate();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            (View as StockPositionStorageView).Refresh();
        }

        private void Print_Click(object sender, EventArgs e)
        {
            (View as StockPositionStorageView).Print();
        }
    }
}
