using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Automation.Plugins.YZ.Sorting.Dal;
using Automation.Plugins.YZ.Sorting.View.Controls;
using System.Windows.Forms;
using Automation.Plugins.YZ.Sorting.Properties;

namespace Automation.Plugins.YZ.Sorting.View
{
   public class CustomerQueryView:AbstractView
    {
       private GridControl gridControl = null;
       private GridView gridMasterView = null;
       private GridControl gridDetailControl = null;
       private CustomerDal customerDal = new CustomerDal();

        public override void Initialize()
        {
            this.DefaultSortOrder = 103;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kCustomerQuery";
            this.Caption = "订单查询";
            this.InnerControl = new CustomerQueryControl();
            this.Dock = DockStyle.Fill;
            this.SmallImage = Resources.refresh_32x32;

            gridControl = ((CustomerQueryControl)this.InnerControl).gridMaster;
            gridMasterView = ((CustomerQueryControl)this.InnerControl).viewMaster;
            gridDetailControl = ((CustomerQueryControl)this.InnerControl).gridDetail;
            gridMasterView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(GridMasterView_RowClick);
        }

        public void Refresh(string product_name)
        {
            gridControl.DataSource = customerDal.FindMaster(product_name);
            gridDetailControl.DataSource = null;
        }
        private void GridMasterView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            gridDetailControl.DataSource = customerDal.FindDetail(gridMasterView.GetRowCellValue(gridMasterView.GetSelectedRows()[0], "customer_code").ToString());
        }

        public void Select(string product_name, string quantity)
        {
            gridControl.DataSource = customerDal.FindProduct(product_name,quantity);
            gridDetailControl.DataSource = null;
        }
    }
}
