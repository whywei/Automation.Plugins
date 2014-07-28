using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DevExpress.XtraGrid;
using Automation.Plugins.YZ.Sorting.View.Controls;
using System.Windows.Forms;
using Automation.Plugins.YZ.Sorting.Properties;
using DevExpress.XtraGrid.Views.Grid;
using Automation.Plugins.YZ.Sorting.Dal;

namespace Automation.Plugins.YZ.Sorting.View
{
    public class PackNoView:AbstractView
    {
        private GridControl gridControl = null;
        private GridView gridMasterView = null;
        private GridControl gridDetailControl = null;
        private PackNoDal packNoDal = new PackNoDal();

        public override void Initialize()
        {
            this.DefaultSortOrder = 104;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kPackNoQuery";
            this.Caption = "烟包查询";
            this.InnerControl = new PackNoControl();
            this.Dock = DockStyle.Fill;
            this.SmallImage = Resources.refresh_32x32;

            gridControl = ((PackNoControl)this.InnerControl).gridMaster;
            gridMasterView = ((PackNoControl)this.InnerControl).viewMaster;
            gridDetailControl = ((PackNoControl)this.InnerControl).gridDetail;
            gridMasterView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(GridMasterView_RowClick);
        }

        public void Refresh()
        {
            gridControl.DataSource = packNoDal.FindMaster();
            gridDetailControl.DataSource = null;          
        }
        private void GridMasterView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            gridDetailControl.DataSource = packNoDal.FindDetail(gridMasterView.GetRowCellValue(gridMasterView.GetSelectedRows()[0], "pack_no").ToString());
        }
    }
}
