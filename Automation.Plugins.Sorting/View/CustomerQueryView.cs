using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using System.Windows.Forms;
using Automation.Plugins.Sorting.View.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Automation.Plugins.Sorting.Dal;

namespace Automation.Plugins.Sorting.View
{
    public class CustomerQueryView : AbstractView
    {
        private GridControl gridMasterControl = null;
        private GridView gridMasterView = null;
        private GridControl gridDetailControl = null;
        OrderDal orderDal = new OrderDal();

        public override void Initialize()
        {
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kCustomerQuery";
            this.Caption = "客户订单";
            this.Dock = DockStyle.Fill;
            this.InnerControl = new CustomerQueryControl();
            gridMasterControl = ((CustomerQueryControl)this.InnerControl).gridMaster;
            gridMasterView = ((CustomerQueryControl)this.InnerControl).viewMaster;
            gridDetailControl = ((CustomerQueryControl)this.InnerControl).gridDetail;

            gridMasterView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(GridMasterView_RowClick);
        }

        private void GridMasterView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            gridDetailControl.DataSource = orderDal.FindDetailBySortNo(gridMasterView.GetRowCellValue(gridMasterView.GetSelectedRows()[0], "SORTNO").ToString());
        }

        public void Refresh(string cigaretteCode,int quantity)
        {
            if (cigaretteCode == "" || quantity == 0)
                gridMasterControl.DataSource = orderDal.FindCustomerMaster();
            else
                gridMasterControl.DataSource = orderDal.FindPackMaster(cigaretteCode, quantity);
        }

        public List<string> FindCigaretteList()
        {
            return orderDal.FindCigaretteList();
        }
    }
}
