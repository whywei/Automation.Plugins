using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using System.Windows.Forms;
using Automation.Plugins.YZ.ManualSupply.View.Controls;

namespace Automation.Plugins.YZ.ManualSupply.View
{
    public class AllTaskView : AbstractView
    {
        public override void Initialize()
        {
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kAllTask";
            this.Caption = "全部作业";
            this.InnerControl = new AllTaskControl();
            this.Dock = DockStyle.Fill;
        }

        public void Refresh()
        { }

        public void BackPage()
        { }

        public void NextPage()
        { }

        public void Print()
        { }
    }
}
