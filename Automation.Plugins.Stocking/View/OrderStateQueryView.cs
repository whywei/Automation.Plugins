using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Plugins.Stocking.View.Controls;
using Automation.Plugins.Stocking.Properties;
using System.Windows.Forms;
using Automation.Plugins.Stocking.Dal;
using System.Data;
using DevExpress.XtraGrid;

namespace Automation.Plugins.Stocking.View
{
    public class OrderStateQueryView:AbstractView
    {
        private GridControl gridControl = null;

        public override void Initialize()
        {
            DefaultSortOrder = 303;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kOrderStateQuery";
            this.InnerControl = new OrderStateQueryControl();
            this.SmallImage = Resources.ScanQuery_16;
            this.Dock = DockStyle.Fill;
            this.Caption = "订单状态";
            gridControl = ((OrderStateQueryControl)this.InnerControl).gridOrderStateQuery;
        }

        public void Refresh(string index)
        {
            StateManagerDal stateManagerDal = new StateManagerDal();
            DataRow rowIndex = stateManagerDal.FindOrderIndexNoByStateCode(index);
            gridControl.DataSource = stateManagerDal.FindOrderStateByIndexNo(rowIndex["ROW_INDEX"].ToString(), rowIndex["VIEWNAME"].ToString());
        }

        public List<string> FindOrderStateList()
        {
            StateManagerDal stateManagerDal = new StateManagerDal();
            return stateManagerDal.FindOrderStateList();
        }
    }
}
