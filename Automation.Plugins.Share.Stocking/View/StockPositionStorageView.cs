using Automation.Core;
using System.Windows.Forms;
using Automation.Plugins.Share.Stocking.Properties;
using Automation.Plugins.Share.Stocking.View.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Automation.Plugins.Share.Stocking.Dal;
using Automation.Plugins.Share.Stocking.Util;

namespace Automation.Plugins.Share.Stocking.View
{
    public class StockPositionStorageView : AbstractView
    {
        private GridControl gridControl = null;
        private GridView gridView = null;

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
            StockPositionStorageDal stockPositionStorageDal = new StockPositionStorageDal();
            gridControl.DataSource = stockPositionStorageDal.FindStockPositionStorage();
        }

        public void Print()
        {
            PrintUtil controller = new PrintUtil(this.gridControl);
            controller.PrintHeader = "位置库存";
            controller.Preview();
        }
    }
}
