using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using System.Windows.Forms;
using Automation.Plugins.YZ.ManualSupply.View.Controls;

namespace Automation.Plugins.YZ.ManualSupply.View
{
    public class MixedChannelView : AbstractView
    {
        public override void Initialize()
        {
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kMixedChannel";
            this.Caption = "混合烟道";
            this.InnerControl = new MixedChannelControl();
            this.Dock = DockStyle.Fill;
        }

        public void Refresh()
        { }

        public void Print()
        { }
    }
}
