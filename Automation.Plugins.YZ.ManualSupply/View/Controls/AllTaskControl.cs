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
    public partial class AllTaskControl : DevExpress.XtraEditors.XtraUserControl
    {
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;

        public AllTaskControl()
        {
            InitializeComponent();
            this.CreateTable();
        }

        public void CreateTable()
        {
            gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.ShowGroupPanel = false;

            gridColumn1 = gridView1.Columns.AddVisible("supply_id", "补货编号");
            gridColumn1 = gridView1.Columns.AddVisible("supply_batch", "批次");
            gridColumn1 = gridView1.Columns.AddVisible("pack_no", "包号");
            gridColumn1 = gridView1.Columns.AddVisible("channel_code", "烟道编码");
            gridColumn1 = gridView1.Columns.AddVisible("product_code", "商品编码");
            gridColumn1 = gridView1.Columns.AddVisible("product_name", "商品名称");
            gridColumn1 = gridView1.Columns.AddVisible("quantity", "数量");
            gridColumn1 = gridView1.Columns.AddVisible("status", "状态");
        }
    }
}
