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
using Automation.Plugins.YZ.Stocking.Util;
using System.Data;

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
       
        public void Refresh(string ledNo,string sql)
        {
            DataTable table = stockTaskDal.FindStockTaskStorage(sql);
            object obj = AutomationContext.Read(Global.plcServiceName, "Supply_Led_Position_Information");
            Array array = (Array)obj;
            for (int i = 0; i < array.Length / 2; i++)
            {
                string ledCode = array.GetValue(i * 2).ToString();
                if (ledCode == ledNo)
                {
                    int quantity = Convert.ToInt32(array.GetValue(i * 2 + 1));
                    if (quantity > 0)
                    {
                        DataRow[] rows = table.Select("", "id desc");
                        for (int j = 0; j < quantity && j < rows.Count(); j++)
                        {
                            rows[j]["ledStatus"] = "未经过";
                        }
                    }
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
