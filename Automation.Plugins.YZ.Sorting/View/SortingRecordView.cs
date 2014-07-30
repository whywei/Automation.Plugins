using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DevExpress.XtraGrid;
using System.Windows.Forms;
using Automation.Plugins.YZ.Sorting.View.Controls;
using Automation.Plugins.YZ.Sorting.Dal;
using DevExpress.XtraGrid.Views.Grid;


namespace Automation.Plugins.YZ.Sorting.View
{
    public class SortingRecordView : AbstractView
    {
        private GridControl gridControl = null;
        public override void Initialize()
        {
            this.DefaultSortOrder = 202;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kSortingRecordQuery";
            this.Caption = "下单记录";
            this.InnerControl = new SortingRecordControl();
            this.Dock = DockStyle.Fill;

            this.gridControl = ((SortingRecordControl)this.InnerControl).gridSortingRecord;
           
        }

        public void Refresh()
        {
            SortingRecordDal sortingDal = new SortingRecordDal();
            gridControl.DataSource = sortingDal.FindSortingRecordMaster();
        }

        public void PackNofresh(int pack)
        {
            SortingRecordDal sortingDal = new SortingRecordDal();
            gridControl.DataSource = sortingDal.FindSortingRecordByPackNo(pack);
        }
       
    }
}
