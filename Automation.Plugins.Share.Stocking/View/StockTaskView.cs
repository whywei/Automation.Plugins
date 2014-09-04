using System;
using System.Linq;
using Automation.Core;
using System.Windows.Forms;
using Automation.Plugins.Share.Stocking.Properties;
using Automation.Plugins.Share.Stocking.View.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Automation.Plugins.Share.Stocking.Dal;
using Automation.Plugins.Share.Stocking.Util;
using System.Data;

namespace Automation.Plugins.Share.Stocking.View
{
    public class StockTaskView : AbstractView
    {
        private GridControl gridControl = null;
        private GridView gridView = null;

        public override void Initialize()
        {
            this.DefaultSortOrder = 103;
            IsPreload = false;
        }

        public override void Activate()
        {
            this.Key = "kStockTask";
            this.Caption = "补货任务";
            this.InnerControl = new StockTaskControl();
            this.Dock = DockStyle.Fill;
            this.SmallImage = Resources.Task_16;

            gridControl = ((StockTaskControl)this.InnerControl).gridStockStatusQuery;
            gridView = ((StockTaskControl)this.InnerControl).viewStockStatusQuery;
        }

        public void Refresh(int ledNo, string sql)
        {
            StockTaskDal stockTaskDal = new StockTaskDal();
            DataTable table = stockTaskDal.FindStockTask(sql);

            var ledPositionInfo = Ops.ReadArray<int>(Global.PLC_SERVICE_NAME, "Supply_Led_Position_Information")
                .ConvertToNewArray(2);

            int quantity = ledPositionInfo.Where(p => p[0] == ledNo)
                .Select(p => p[1])
                .Single();

            if (quantity > 0)
            {
                DataRow[] rows = table.Select("", "id desc");
                for (int j = 0; j < quantity && j < rows.Count(); j++)
                {
                    rows[j]["ledStatus"] = "未经过";
                }
            }

            gridControl.DataSource = table;
        }

        public void Print()
        {
            PrintUtil controller = new PrintUtil(this.gridControl);
            controller.PrintHeader = "补货任务";
            controller.Preview();
        }
    }
}
