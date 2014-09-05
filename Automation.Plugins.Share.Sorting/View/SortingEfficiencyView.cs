using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Plugins.Share.Sorting.View.Controls;
using System.Windows.Forms;

namespace Automation.Plugins.Share.Sorting.View
{
    public class SortingEfficiencyView : AbstractView
    {
        public override void Initialize()
        {
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kSortingEfficiencyQuery";
            this.Caption = "分拣效率";
            this.InnerControl = new SortingEfficiencyControl();
            this.Dock = DockStyle.Fill;
        }

        public void Refresh()
        { }
    }
}
