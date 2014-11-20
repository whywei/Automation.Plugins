using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;

namespace Automation.Plugins.Share.ManualSupply.View.Controls
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
            gridColumn1 = gridView1.Columns.AddVisible("supply_id", "补货编号");
            gridColumn1 = gridView1.Columns.AddVisible("supply_batch", "批次");
            gridColumn1 = gridView1.Columns.AddVisible("pack_no", "包号");
            gridColumn1 = gridView1.Columns.AddVisible("channel_code", "烟道编码");
            gridColumn1 = gridView1.Columns.AddVisible("channel_name", "烟道名称");
            gridColumn1 = gridView1.Columns.AddVisible("product_code", "商品编码");
            gridColumn1 = gridView1.Columns.AddVisible("product_name", "商品名称");
            gridColumn1 = gridView1.Columns.AddVisible("quantity", "数量");
            gridColumn1 = gridView1.Columns.AddVisible("status", "状态");
        }

        private void CreateStyle()
        {
            #region Set columns width
            gridView1.Columns["supply_id"].Width = 80;
            gridView1.Columns["supply_batch"].Width = 50;
            gridView1.Columns["pack_no"].Width = 80;
            gridView1.Columns["channel_code"].Width = 80;
            gridView1.Columns["channel_name"].Width = 80;
            gridView1.Columns["product_name"].Width = 200;
            gridView1.Columns["quantity"].Width = 50;
            gridView1.Columns["status"].Width = 120;
            #endregion

            #region HAlignment for header
            gridView1.Columns["status"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            gridView1.Columns["supply_id"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            gridView1.Columns["supply_batch"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            gridView1.Columns["pack_no"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            gridView1.Columns["quantity"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center; 
            #endregion

            #region HAlignment for cell
            gridView1.Columns["supply_id"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gridView1.Columns["supply_batch"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gridView1.Columns["pack_no"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gridView1.Columns["quantity"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center; 
            #endregion

            #region Basic
            gridControl1.Dock = DockStyle.Fill;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            for (int i = 0; i < 9; i++)
            {
                gridView1.Columns[i].OptionsColumn.AllowFocus = false;
                gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                gridView1.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            }
            gridView1.Columns["status"].OptionsColumn.AllowFocus = true;
            #endregion

            #region Alone
            gridView1.OptionsView.RowAutoHeight = true;
            gridView1.RowHeight = 30;
            gridView1.OptionsCustomization.AllowFilter = false;
            if (gridView1.IsFocusedRowLoaded)
            {
                gridView1.Appearance.FocusedRow.BackColor = Color.Transparent;
            }
            #endregion
        }
    }
}
