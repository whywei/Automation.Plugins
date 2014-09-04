using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using System.Windows.Forms;
using Automation.Plugins.Share.Stocking.Properties;
using Automation.Plugins.Share.Stocking.View.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using Automation.Plugins.Share.Stocking.Dal;
using Automation.Plugins.Share.Stocking.Util;

namespace Automation.Plugins.Share.Stocking.View
{
    public class StockPositionView : AbstractView
    {
        private GridControl gridControl = null;
        private GridView gridView = null;
        
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
            StockPositionDal stockPositionDal = new StockPositionDal();
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
