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
    public class StockStatusView : AbstractView
    {
        public override void Activate()
        {
            this.Key = "kStockStatus";
            this.Caption = "补货状态";
            this.InnerControl = new StockStatusControl();
            this.Dock = DockStyle.Fill;
            this.SmallImage = Resources.Task_16;
        }

        public override void Initialize()
        {
            IsPreload = false;
        }
    }
}
