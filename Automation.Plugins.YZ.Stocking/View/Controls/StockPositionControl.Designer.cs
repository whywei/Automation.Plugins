namespace Automation.Plugins.YZ.Stocking.View.Controls
{
    partial class StockPositionControl
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
            this.gridStockPositionQuery = new DevExpress.XtraGrid.GridControl();
            this.viewStockPositionQuery = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.position_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.position_type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.product_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.product_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.position_address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.position_capacity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sorting_line_codes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.target_supply_addresses = new DevExpress.XtraGrid.Columns.GridColumn();
            this.description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.is_active = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridStockPositionQuery)).BeginInit();
            this.SuspendLayout();
            // 
            // gridStockPositionQuery
            // 
            this.gridStockPositionQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStockPositionQuery.Location = new System.Drawing.Point(0, 0);
            this.gridStockPositionQuery.MainView = this.viewStockPositionQuery;
            this.gridStockPositionQuery.Name = "gridStockPositionQuery";
            this.gridStockPositionQuery.Size = new System.Drawing.Size(917, 403);
            this.gridStockPositionQuery.TabIndex = 2;
            this.gridStockPositionQuery.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewStockPositionQuery});
            // 
            // viewStockPositionQuery
            // 
            this.viewStockPositionQuery.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.position_name,
            this.position_type,
            this.product_code,
            this.product_name,
            this.position_address,
            this.position_capacity,
            this.sorting_line_codes,
            this.target_supply_addresses,
            this.description,
            this.is_active});
            this.viewStockPositionQuery.GridControl = this.gridStockPositionQuery;
            this.viewStockPositionQuery.Name = "viewStockPositionQuery";
            this.viewStockPositionQuery.OptionsView.ColumnAutoWidth = false;
            this.viewStockPositionQuery.OptionsView.ShowGroupPanel = false;
            // 
            // position_name
            // 
            this.position_name.Caption = "位置名称";
            this.position_name.FieldName = "position_name";
            this.position_name.Name = "position_name";
            this.position_name.OptionsColumn.AllowEdit = false;
            this.position_name.OptionsColumn.AllowFocus = false;
            this.position_name.Visible = true;
            this.position_name.VisibleIndex = 0;
            // 
            // position_type
            // 
            this.position_type.Caption = "位置类型";
            this.position_type.FieldName = "position_type";
            this.position_type.Name = "position_type";
            this.position_type.OptionsColumn.AllowEdit = false;
            this.position_type.OptionsColumn.AllowFocus = false;
            this.position_type.Visible = true;
            this.position_type.VisibleIndex = 1;
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
            // position_address
            // 
            this.position_address.Caption = "位置地址";
            this.position_address.FieldName = "position_address";
            this.position_address.Name = "position_address";
            this.position_address.OptionsColumn.AllowEdit = false;
            this.position_address.OptionsColumn.AllowFocus = false;
            this.position_address.Visible = true;
            this.position_address.VisibleIndex = 5;
            // 
            // position_capacity
            // 
            this.position_capacity.Caption = "位置容量";
            this.position_capacity.FieldName = "position_capacity";
            this.position_capacity.Name = "position_capacity";
            this.position_capacity.OptionsColumn.AllowEdit = false;
            this.position_capacity.OptionsColumn.AllowFocus = false;
            this.position_capacity.Visible = true;
            this.position_capacity.VisibleIndex = 6;
            // 
            // sorting_line_codes
            // 
            this.sorting_line_codes.Caption = "可补货分拣线";
            this.sorting_line_codes.FieldName = "sorting_line_codes";
            this.sorting_line_codes.Name = "sorting_line_codes";
            this.sorting_line_codes.OptionsColumn.AllowEdit = false;
            this.sorting_line_codes.OptionsColumn.AllowFocus = false;
            this.sorting_line_codes.Visible = true;
            this.sorting_line_codes.VisibleIndex = 7;
            this.sorting_line_codes.Width = 100;
            // 
            // target_supply_addresses
            // 
            this.target_supply_addresses.Caption = "可补货目标地址";
            this.target_supply_addresses.FieldName = "target_supply_addresses";
            this.target_supply_addresses.Name = "target_supply_addresses";
            this.target_supply_addresses.OptionsColumn.AllowEdit = false;
            this.target_supply_addresses.OptionsColumn.AllowFocus = false;
            this.target_supply_addresses.Visible = true;
            this.target_supply_addresses.VisibleIndex = 8;
            this.target_supply_addresses.Width = 100;
            // 
            // description
            // 
            this.description.Caption = "描述";
            this.description.FieldName = "description";
            this.description.Name = "description";
            this.description.OptionsColumn.AllowEdit = false;
            this.description.OptionsColumn.AllowFocus = false;
            this.description.Visible = true;
            this.description.VisibleIndex = 9;
            // 
            // is_active
            // 
            this.is_active.Caption = "是否可用";
            this.is_active.FieldName = "is_active";
            this.is_active.Name = "is_active";
            this.is_active.OptionsColumn.AllowEdit = false;
            this.is_active.OptionsColumn.AllowFocus = false;
            this.is_active.Visible = true;
            this.is_active.VisibleIndex = 10;
            // 
            // StockPositionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridStockPositionQuery);
            this.Name = "StockPositionControl";
            this.Size = new System.Drawing.Size(917, 403);
            ((System.ComponentModel.ISupportInitialize)(this.gridStockPositionQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewStockPositionQuery)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridStockPositionQuery;
        public DevExpress.XtraGrid.Views.Grid.GridView viewStockPositionQuery;
        private DevExpress.XtraGrid.Columns.GridColumn position_name;
        private DevExpress.XtraGrid.Columns.GridColumn position_type;
        private DevExpress.XtraGrid.Columns.GridColumn product_code;
        private DevExpress.XtraGrid.Columns.GridColumn product_name;
        private DevExpress.XtraGrid.Columns.GridColumn position_address;
        private DevExpress.XtraGrid.Columns.GridColumn position_capacity;
        private DevExpress.XtraGrid.Columns.GridColumn sorting_line_codes;
        private DevExpress.XtraGrid.Columns.GridColumn target_supply_addresses;
        private DevExpress.XtraGrid.Columns.GridColumn description;
        private DevExpress.XtraGrid.Columns.GridColumn is_active;
    }
}
