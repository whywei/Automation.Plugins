namespace Automation.Plugins.YZ.ManualSupply.View.Controls
{
    partial class ProductCheckControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.supply_batch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.product_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.product_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.stockquantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.remainquantity = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(917, 485);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.supply_batch,
            this.product_code,
            this.product_name,
            this.quantity,
            this.stockquantity,
            this.remainquantity});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // supply_batch
            // 
            this.supply_batch.AppearanceCell.Options.UseTextOptions = true;
            this.supply_batch.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.supply_batch.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.supply_batch.Caption = "补货批次号";
            this.supply_batch.FieldName = "supply_batch";
            this.supply_batch.Name = "supply_batch";
            this.supply_batch.OptionsColumn.AllowEdit = false;
            this.supply_batch.OptionsColumn.AllowFocus = false;
            this.supply_batch.Visible = true;
            this.supply_batch.VisibleIndex = 0;
            // 
            // product_code
            // 
            this.product_code.AppearanceCell.Options.UseTextOptions = true;
            this.product_code.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.product_code.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.product_code.Caption = "卷烟代码";
            this.product_code.FieldName = "product_code";
            this.product_code.Name = "product_code";
            this.product_code.OptionsColumn.AllowEdit = false;
            this.product_code.OptionsColumn.AllowFocus = false;
            this.product_code.Visible = true;
            this.product_code.VisibleIndex = 1;
            // 
            // product_name
            // 
            this.product_name.AppearanceCell.Options.UseTextOptions = true;
            this.product_name.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.product_name.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.product_name.Caption = "卷烟名称";
            this.product_name.FieldName = "product_name";
            this.product_name.Name = "product_name";
            this.product_name.OptionsColumn.AllowEdit = false;
            this.product_name.OptionsColumn.AllowFocus = false;
            this.product_name.Visible = true;
            this.product_name.VisibleIndex = 2;
            // 
            // quantity
            // 
            this.quantity.AppearanceCell.Options.UseTextOptions = true;
            this.quantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.quantity.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.quantity.Caption = "总数量";
            this.quantity.FieldName = "quantity";
            this.quantity.Name = "quantity";
            this.quantity.OptionsColumn.AllowEdit = false;
            this.quantity.OptionsColumn.AllowFocus = false;
            this.quantity.Visible = true;
            this.quantity.VisibleIndex = 3;
            // 
            // stockquantity
            // 
            this.stockquantity.AppearanceCell.Options.UseTextOptions = true;
            this.stockquantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.stockquantity.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.stockquantity.Caption = "已补数量";
            this.stockquantity.FieldName = "stockquantity";
            this.stockquantity.Name = "stockquantity";
            this.stockquantity.OptionsColumn.AllowEdit = false;
            this.stockquantity.OptionsColumn.AllowFocus = false;
            this.stockquantity.Visible = true;
            this.stockquantity.VisibleIndex = 4;
            // 
            // remainquantity
            // 
            this.remainquantity.AppearanceCell.Options.UseTextOptions = true;
            this.remainquantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.remainquantity.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.remainquantity.Caption = "未补数量";
            this.remainquantity.FieldName = "remainquantity";
            this.remainquantity.Name = "remainquantity";
            this.remainquantity.OptionsColumn.AllowEdit = false;
            this.remainquantity.OptionsColumn.AllowFocus = false;
            this.remainquantity.Visible = true;
            this.remainquantity.VisibleIndex = 5;
            // 
            // ProductCheckControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "ProductCheckControl";
            this.Size = new System.Drawing.Size(917, 485);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridControl1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn supply_batch;
        private DevExpress.XtraGrid.Columns.GridColumn product_code;
        private DevExpress.XtraGrid.Columns.GridColumn product_name;
        private DevExpress.XtraGrid.Columns.GridColumn quantity;
        private DevExpress.XtraGrid.Columns.GridColumn stockquantity;
        private DevExpress.XtraGrid.Columns.GridColumn remainquantity;

    }
}
