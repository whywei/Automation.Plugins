using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using System.Windows.Forms;
using Automation.Plugins.YZ.Sorting.View.Controls;

namespace Automation.Plugins.YZ.Sorting.View
{
    public class HandSuppyView : AbstractView
    {
        public override void Initialize()
        {
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kHandSuppyQuery";
            this.Caption = "手工补货";
            this.InnerControl = new HandSuppyControl();
            this.Dock = DockStyle.Fill;
        }

        public void Refresh()
        { }
    }
}
