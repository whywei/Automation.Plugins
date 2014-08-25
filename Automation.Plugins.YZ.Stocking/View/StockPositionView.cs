using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using System.Windows.Forms;
using Automation.Plugins.YZ.Stocking.Properties;
using Automation.Plugins.YZ.Stocking.View.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using Automation.Plugins.YZ.Stocking.Dal;
using Automation.Plugins.YZ.Stocking.Util;

namespace Automation.Plugins.YZ.Stocking.View
{
    public class StockPositionView : AbstractView
    {
        private GridControl gridControl = null;
        GridView gridView = null;
        StockPositionDal stockPositionDal = new StockPositionDal();
        public override void Initialize()
        {
            this.DefaultSortOrder = 101;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kStockPosition";
            this.Caption = "拆盘位置";
            this.InnerControl = new StockPositionControl();
            this.Dock = DockStyle.Fill;
            this.SmallImage = Resources.yandao_16x16;
            gridControl = ((StockPositionControl)this.InnerControl).gridStockPositionQuery;
            gridView = ((StockPositionControl)this.InnerControl).viewStockPositionQuery;
        }

        public void Refresh()
        {
            gridControl.DataSource = stockPositionDal.FindSupplyPosition();
        }
        public void Print()
        {
            PrintUtil controller = new PrintUtil(this.gridControl);
            controller.PrintHeader = "拆盘位置";
            controller.Preview();
        }
    }
}
