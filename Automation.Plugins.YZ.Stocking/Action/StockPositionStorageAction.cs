﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DotSpatial.Controls.Header;
using Automation.Plugins.YZ.Stocking.Properties;
using Automation.Plugins.YZ.Stocking.View;

namespace Automation.Plugins.YZ.Stocking.Action
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
            this.Add(new SimpleActionItem(rootKey, "刷新", Refresh_Click) { ToolTipText = "刷新位置库存信息", LargeImage = Resources.refresh_32x32 });
            this.Add(new SimpleActionItem(rootKey, "打印", Print_Click) { ToolTipText = "打印位置库存信息", LargeImage = Resources.Print_32 });
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
