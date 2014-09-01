namespace Automation.Plugins.YZ.Stocking.View.Controls
{
    partial class StockPositionStorageControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.gridStockPositionStorageQuery = new DevExpress.XtraGrid.GridControl();
            this.viewStockPositionStorageQuery = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.position_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.product_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.product_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.wait_quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridStockPositionStorageQuery)).BeginInit();
            this.SuspendLayout();
            // 
            // gridStockPositionStorageQuery
            // 
            this.gridStockPositionStorageQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStockPositionStorageQuery.Location = new System.Drawing.Point(0, 0);
            this.gridStockPositionStorageQuery.MainView = this.viewStockPositionStorageQuery;
            this.gridStockPositionStorageQuery.Name = "gridStockPositionStorageQuery";
            this.gridStockPositionStorageQuery.Size = new System.Drawing.Size(917, 403);
            this.gridStockPositionStorageQuery.TabIndex = 2;
            this.gridStockPositionStorageQuery.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewStockPositionStorageQuery});
            // 
            // viewStockPositionStorageQuery
            // 
            this.viewStockPositionStorageQuery.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.position_id,
            this.product_code,
            this.product_name,
            this.quantity,
            this.wait_quantity});
            this.viewStockPositionStorageQuery.GridControl = this.gridStockPositionStorageQuery;
            this.viewStockPositionStorageQuery.Name = "viewStockPositionStorageQuery";
            this.viewStockPositionStorageQuery.OptionsView.ColumnAutoWidth = false;
            this.viewStockPositionStorageQuery.OptionsView.ShowGroupPanel = false;
            // 
            // position_id
            // 
            this.position_id.Caption = "位置名称";
            this.position_id.FieldName = "position_id";
            this.position_id.Name = "position_id";
            this.position_id.OptionsColumn.AllowEdit = false;
            this.position_id.OptionsColumn.AllowFocus = false;
            this.position_id.Visible = true;
            this.position_id.VisibleIndex = 0;
            // 
            // product_code
            // 
            this.product_code.Caption = "商品编码";
            this.product_code.FieldName = "product_code";
            this.product_code.Name = "product_code";
            this.product_code.OptionsColumn.AllowEdit = false;
            this.product_code.OptionsColumn.AllowFocus = false;
            this.product_code.Visible = true;
            this.product_code.VisibleIndex = 3;
            // 
            // product_name
            // 
            this.product_name.Caption = "商品名称";
            this.product_name.FieldName = "product_name";
            this.product_name.Name = "product_name";
            this.product_name.OptionsColumn.AllowEdit = false;
            this.product_name.OptionsColumn.AllowFocus = false;
            this.product_name.Visible = true;
            this.product_name.VisibleIndex = 4;
            this.product_name.Width = 200;
            // 
            // quantity
            // 
            this.quantity.Caption = "库存数量";
            this.quantity.FieldName = "quantity";
            this.quantity.Name = "quantity";
            this.quantity.OptionsColumn.AllowEdit = false;
            this.quantity.OptionsColumn.AllowFocus = false;
            this.quantity.Visible = true;
            this.quantity.VisibleIndex = 5;
            // 
            // wait_quantity
            // 
            this.wait_quantity.Caption = "待入数量";
            this.wait_quantity.FieldName = "wait_quantity";
            this.wait_quantity.Name = "wait_quantity";
            this.wait_quantity.OptionsColumn.AllowEdit = false;
            this.wait_quantity.OptionsColumn.AllowFocus = false;
            this.wait_quantity.Visible = true;
            this.wait_quantity.VisibleIndex = 6;

            // 
            // StockPositionStorageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridStockPositionStorageQuery);
            this.Name = "StockPositionStorageControl";
            this.Size = new System.Drawing.Size(917, 403);
            ((System.ComponentModel.ISupportInitialize)(this.gridStockPositionStorageQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewStockPositionStorageQuery)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridStockPositionStorageQuery;
        public DevExpress.XtraGrid.Views.Grid.GridView viewStockPositionStorageQuery;
        private DevExpress.XtraGrid.Columns.GridColumn position_id;
        private DevExpress.XtraGrid.Columns.GridColumn product_code;
        private DevExpress.XtraGrid.Columns.GridColumn product_name;
        private DevExpress.XtraGrid.Columns.GridColumn quantity;
        private DevExpress.XtraGrid.Columns.GridColumn wait_quantity;
    }
}
