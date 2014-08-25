using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.YZ.Stocking.Properties;
using Automation.Plugins.YZ.Stocking.View;

namespace Automation.Plugins.YZ.Stocking.Action
{
    public class StockStatusAction:AbstractAction
    {
        private const string rootKey = "kStockStatus";

        public override void Initialize()
        {
            RootKey = rootKey;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Add(new RootItem(rootKey, "补货状态") { SortOrder = 10001 });
            this.Add(new SimpleActionItem(rootKey, "下单状态", OrderStatus_Click) { ToolTipText = "刷新烟道信息", LargeImage = Resources.OrderStatus_32 });
            this.Add(new SimpleActionItem(rootKey, "扫码状态", ScanStatus_Click) { ToolTipText = "将卷烟信息发送到PLC", LargeImage = Resources.ScanStatus_32 });
            this.Add(new SimpleActionItem(rootKey, "打印", Print_Click) { ToolTipText = "打印烟道信息", LargeImage = Resources.Print_32 });
            base.Activate();
        }

        private void OrderStatus_Click(object sender, EventArgs e)
        {
            (View as StockStatusView).Refresh();
        }

        private void ScanStatus_Click(object sender, EventArgs e)
        { }

        private void Print_Click(object sender, EventArgs e)
        {
            (View as StockStatusView).Print();
        }
    }
}
