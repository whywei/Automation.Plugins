using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DevExpress.XtraGrid;
using System.Windows.Forms;
using Automation.Plugins.YZ.Sorting.View.Controls;

namespace Automation.Plugins.YZ.Sorting.View
{
    public class SortingRecordView : AbstractView
    {
        private GridControl gridControl = null;

        public override void Initialize()
        {
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kSortingRecordQuery";
            this.Caption = "下单记录";
            this.InnerControl = new SortingRecordControl();
            this.Dock = DockStyle.Fill;
        }

        public void Refresh()
        { }
    }
}
