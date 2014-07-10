using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Plugins.YZ.Sorting.View.Controls;
using System.Windows.Forms;

namespace Automation.Plugins.YZ.Sorting.View
{
    public class SortingProgressView : AbstractView
    {
        public override void Initialize()
        {
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kSortingProgressQuery";
            this.Caption = "分拣进度";
            this.InnerControl = new SortingProgressControl();
            this.Dock = DockStyle.Fill;
        }

        public void Refresh()
        { }
    }
}
