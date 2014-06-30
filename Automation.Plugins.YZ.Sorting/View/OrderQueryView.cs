using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Automation.Plugins.YZ.Sorting.View.Controls;
using System.Windows.Forms;
using Automation.Plugins.YZ.Sorting.Properties;
using Automation.Plugins.YZ.Sorting.Dal;

namespace Automation.Plugins.YZ.Sorting.View
{
    public class OrderQueryView : AbstractView
    {
        private GridControl gridMasterControl = null;
        private GridView gridMasterView = null;
        private GridControl gridDetailControl = null;
        private OrderDal orderDal = new OrderDal();

        public override void Initialize()
        {
            DefaultSortOrder = 200;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "yzOrderQuery";
            this.Caption = "订单查询";
            this.InnerControl = new OrderQueryControl();
            this.Dock = DockStyle.Fill;
            this.SmallImage = Resources.Sorting_Query_32;
            gridMasterControl = ((OrderQueryControl)this.InnerControl).gridMaster;
            gridMasterView = ((OrderQueryControl)this.InnerControl).viewMaster;
            gridDetailControl = ((OrderQueryControl)this.InnerControl).gridDetail;

            gridMasterView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(GridMasterView_RowClick);
        }

        private void GridMasterView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            gridDetailControl.DataSource = orderDal.FindDetailBySortNo(gridMasterView.GetRowCellValue(gridMasterView.GetSelectedRows()[0], "pack_no").ToString());
        }

        public void Refresh()
        {
            gridMasterControl.DataSource = orderDal.FindMaster();
        }
    }
}

