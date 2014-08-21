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
    public class StockPositionView : AbstractView
    {
        public override void Activate()
        {
            this.Key = "kStockPosition";
            this.Caption = "拆盘位置";
            this.InnerControl = new StockPositionControl();
            this.Dock = DockStyle.Fill;
            this.SmallImage = Resources.yandao_16x16;
        }

        public override void Initialize()
        {
            IsPreload = false;
        }
    }
}
