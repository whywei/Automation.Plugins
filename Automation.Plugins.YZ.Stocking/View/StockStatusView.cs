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
using Automation.Plugins.YZ.Stocking.Dal;
using Automation.Plugins.YZ.Sorting.View;

namespace Automation.Plugins.YZ.Stocking.View
{
    public class StockStatusView : AbstractView
    {
        private GridControl gridControl = null;
        GridView gridView = null;
        StockTaskDal stockTaskDal = new StockTaskDal();
        public override void Activate()
        {
            this.Key = "kStockStatus";
            this.Caption = "补货任务";
            this.InnerControl = new StockStatusControl();
            this.Dock = DockStyle.Fill;
            this.SmallImage = Resources.Task_16;
            gridControl = ((StockStatusControl)this.InnerControl).gridStockStatusQuery;
            gridView = ((StockStatusControl)this.InnerControl).viewStockStatusQuery;
        }

        public override void Initialize()
        {
            IsPreload = false;
        }
       
        public void Refresh()
        {
            gridControl.DataSource = stockTaskDal.FindStockTaskStorage();
        }
        public void Print()
        {
            PrintSettingView controller = new PrintSettingView(this.gridControl);
            controller.PrintHeader = "补货任务";
            controller.Preview();
        }
    }
}
