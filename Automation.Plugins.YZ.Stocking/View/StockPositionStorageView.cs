using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using System.Windows.Forms;
using Automation.Plugins.YZ.Stocking.Properties;
using Automation.Plugins.YZ.Stocking.View.Controls;

namespace Automation.Plugins.YZ.Stocking.View
{
    public class StockPositionStorageView : AbstractView
    {
        public override void Activate()
        {
            this.Key = "kStockPositionStorage";
            this.Caption = "位置库存";
            this.InnerControl = new StockPositionStorageControl();
            this.Dock = DockStyle.Fill;
            this.SmallImage = Resources.yandao_16x16;
        }

        public override void Initialize()
        {
            IsPreload = false;
        }
    }
}
