using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using System.Windows.Forms;
using Automation.Plugins.YZ.Sorting.View.Controls;

namespace Automation.Plugins.YZ.Sorting.View
{
    public class PackDataView : AbstractView
    {
        public override void Initialize()
        {
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kPackDataQuery";
            this.Caption = "包装机数据";
            this.InnerControl = new PackDataControl();
            this.Dock = DockStyle.Fill;
        }

        public void Refresh()
        { }
    }
}
