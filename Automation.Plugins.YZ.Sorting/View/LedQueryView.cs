using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
using Automation.Core;
using Automation.Plugins.YZ.Sorting.View.Controls;
using System.Windows.Forms;
using Automation.Plugins.YZ.Sorting.Properties;
using DevExpress.XtraGrid;
using Automation.Plugins.YZ.Sorting.Dal;

namespace Automation.Plugins.YZ.Sorting.View
{
    public class LedQueryView : AbstractView
    {
        private GridControl gridMasterControl = null;
        private GridView gridMasterView = null;
        private GridControl gridDetailControl = null;
        private LedDal ledDal = new LedDal();
        public override void Initialize()
        {
            this.DefaultSortOrder = 102;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "yzledQuery";
            this.Caption = "LED";
            this.InnerControl = new LedQueryControl();
            this.Dock = DockStyle.Fill;
            this.SmallImage = Resources.refresh_32x32;

            gridMasterControl = ((LedQueryControl)this.InnerControl).gridControl1;
            gridMasterView = ((LedQueryControl)this.InnerControl).gridView1;
            gridDetailControl = ((LedQueryControl)this.InnerControl).gridControl2;

            gridMasterView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(GridMasterView_RowClick);
       
      
        }

        private void GridMasterView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            gridDetailControl.DataSource = ledDal.FindDetailByLedGroupNo(gridMasterView.GetRowCellValue(gridMasterView.GetSelectedRows()[0], "led_code").ToString());
        }
       

        public void Refresh()
        {
            gridMasterControl.DataSource = ledDal.FindMaster();                       
        }

    }
}
