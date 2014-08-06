using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using System.Windows.Forms;
using Automation.Plugins.YZ.ManualSupply.View.Controls;

namespace Automation.Plugins.YZ.ManualSupply.View
{
    public class ProductCheckView : AbstractView
    {
        public override void Initialize()
        {
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kProductCheck";
            this.Caption = "卷烟查询";
            this.InnerControl = new ProductCheckControl();
            this.Dock = DockStyle.Fill;
        }

        public void Refresh()
        { }

        public void Print()
        { }
    }
}
