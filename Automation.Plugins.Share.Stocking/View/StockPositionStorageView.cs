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
    public class StockPositionStorageView : AbstractView
    {
        private GridControl gridControl = null;
        GridView gridView = null;
        StockPositionStorageDal stockPositionStorageDal = new StockPositionStorageDal();

        public override void Initialize()
        {
            this.DefaultSortOrder = 102;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kStockPositionStorage";
            this.Caption = "位置库存";
            this.InnerControl = new StockPositionStorageControl();
            this.Dock = DockStyle.Fill;
            this.SmallImage = Resources.yandao_16x16;
            gridControl = ((StockPositionStorageControl)this.InnerControl).gridStockPositionStorageQuery;
            gridView = ((StockPositionStorageControl)this.InnerControl).viewStockPositionStorageQuery;
        }

        public void Refresh()
        {
            gridControl.DataSource = stockPositionStorageDal.FindStockPositionStorage();
        }
        public void Print()
        {
            PrintUtil controller = new PrintUtil(this.gridControl);
            controller.PrintHeader = "拆盘位置库存";
            controller.Preview();
        }
    }
}
