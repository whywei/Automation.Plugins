using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Automation.Plugins.YZ.ManualSupply.View.Controls
{
    public partial class CurrentTaskControl : DevExpress.XtraEditors.XtraUserControl
    {
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        
        public CurrentTaskControl()
        {
            InitializeComponent();
            this.CreateColumns();
            this.CreateStyle();
        }

        private void CreateColumns()
        {
            gridColumn1 = gridView1.Columns.AddVisible("status", "状态");
            gridColumn1 = gridView1.Columns.AddVisible("supply_id", "补货编号");
            gridColumn1 = gridView1.Columns.AddVisible("supply_batch", "批次");
            gridColumn1 = gridView1.Columns.AddVisible("pack_no", "包号");
            gridColumn1 = gridView1.Columns.AddVisible("channel_code", "烟道编码");
            gridColumn1 = gridView1.Columns.AddVisible("product_code", "商品编码");
            gridColumn1 = gridView1.Columns.AddVisible("product_name", "商品名称");
            gridColumn1 = gridView1.Columns.AddVisible("quantity", "数量");
        }

        private void CreateStyle()
        {
            gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ColumnAutoWidth = false;

            for (int i = 0; i < 8; i++)
            {
                gridView1.Columns[i].OptionsColumn.AllowFocus = false;
                gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                gridView1.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            }
        }
    }
}
