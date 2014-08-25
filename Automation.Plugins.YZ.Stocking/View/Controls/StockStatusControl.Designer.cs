namespace Automation.Plugins.YZ.Stocking.View.Controls
{
    partial class StockStatusControl
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
            this.gridStockStatusQuery = new DevExpress.XtraGrid.GridControl();
            this.viewStockStatusQuery = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.supply_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pack_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sorting_line_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.group_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.channel_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.channel_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.product_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.product_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.product_barcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.origin_position_address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.target_supply_address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.status = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridStockStatusQuery)).BeginInit();
            this.SuspendLayout();
            // 
            // gridStockStatusQuery
            // 
            this.gridStockStatusQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStockStatusQuery.Location = new System.Drawing.Point(0, 0);
            this.gridStockStatusQuery.MainView = this.viewStockStatusQuery;
            this.gridStockStatusQuery.Name = "gridStockStatusQuery";
            this.gridStockStatusQuery.Size = new System.Drawing.Size(917, 403);
            this.gridStockStatusQuery.TabIndex = 2;
            this.gridStockStatusQuery.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewStockStatusQuery});
            // 
            // viewStockPositionQuery
            // 
            this.viewStockStatusQuery.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.supply_id,
            this.pack_no,
            this.sorting_line_code,
            this.group_no,
            this.channel_code,
            this.channel_name,
            this.product_code,
            this.product_name,
            this.product_barcode,
            this.origin_position_address,
            this.target_supply_address,
            this.status});
            this.viewStockStatusQuery.GridControl = this.gridStockStatusQuery;
            this.viewStockStatusQuery.Name = "viewStockStatusQuery";
            this.viewStockStatusQuery.OptionsView.ColumnAutoWidth = false;
            this.viewStockStatusQuery.OptionsView.ShowGroupPanel = false;
            // 
            // position_name
            // 
            this.supply_id.Caption = "补货编号";
            this.supply_id.FieldName = "supply_id";
            this.supply_id.Name = "supply_id";
            this.supply_id.OptionsColumn.AllowEdit = false;
            this.supply_id.OptionsColumn.AllowFocus = false;
            this.supply_id.Visible = true;
            this.supply_id.VisibleIndex = 0;
            // 
            // pack_no
            // 
            this.pack_no.Caption = "包装号";
            this.pack_no.FieldName = "pack_no";
            this.pack_no.Name = "pack_no";
            this.pack_no.OptionsColumn.AllowEdit = false;
            this.pack_no.OptionsColumn.AllowFocus = false;
            this.pack_no.Visible = true;
            this.pack_no.VisibleIndex = 1;
            // 
            // sorting_line_code
            // 
            this.sorting_line_code.Caption = "分拣线号";
            this.sorting_line_code.FieldName = "sorting_line_code";
            this.sorting_line_code.Name = "sorting_line_code";
            this.sorting_line_code.OptionsColumn.AllowEdit = false;
            this.sorting_line_code.OptionsColumn.AllowFocus = false;
            this.sorting_line_code.Visible = true;
            this.sorting_line_code.VisibleIndex = 2;
            // 
            // pack_no
            // 
            this.pack_no.Caption = "包装号";
            this.pack_no.FieldName = "pack_no";
            this.pack_no.Name = "pack_no";
            this.pack_no.OptionsColumn.AllowEdit = false;
            this.pack_no.OptionsColumn.AllowFocus = false;
            this.pack_no.Visible = true;
            this.pack_no.VisibleIndex = 3;
            // 
            // group_no
            // 
            this.group_no.Caption = "组号";
            this.group_no.FieldName = "group_no";
            this.group_no.Name = "group_no";
            this.group_no.OptionsColumn.AllowEdit = false;
            this.group_no.OptionsColumn.AllowFocus = false;
            this.group_no.Visible = true;
            this.group_no.VisibleIndex = 4;
            // 
            // channel_code
            // 
            this.channel_code.Caption = "烟道编码";
            this.channel_code.FieldName = "channel_code";
            this.channel_code.Name = "channel_code";
            this.channel_code.OptionsColumn.AllowEdit = false;
            this.channel_code.OptionsColumn.AllowFocus = false;
            this.channel_code.Visible = true;
            this.channel_code.VisibleIndex = 5;
            // 
            // channel_name
            // 
            this.channel_name.Caption = "烟道名称";
            this.channel_name.FieldName = "channel_name";
            this.channel_name.Name = "channel_name";
            this.channel_name.OptionsColumn.AllowEdit = false;
            this.channel_name.OptionsColumn.AllowFocus = false;
            this.channel_name.Visible = true;
            this.channel_name.VisibleIndex = 6;
            // 
            // product_code
            // 
            this.product_code.Caption = "商品编码";
            this.product_code.FieldName = "product_code";
            this.product_code.Name = "product_code";
            this.product_code.OptionsColumn.AllowEdit = false;
            this.product_code.OptionsColumn.AllowFocus = false;
            this.product_code.Visible = true;
            this.product_code.VisibleIndex = 7;
            // 
            // product_name
            // 
            this.product_name.Caption = "商品名称";
            this.product_name.FieldName = "product_name";
            this.product_name.Name = "product_name";
            this.product_name.OptionsColumn.AllowEdit = false;
            this.product_name.OptionsColumn.AllowFocus = false;
            this.product_name.Visible = true;
            this.product_name.VisibleIndex = 8;
            this.product_name.Width = 200;
            // 
            // product_barcode
            // 
            this.product_barcode.Caption = "卷烟条码";
            this.product_barcode.FieldName = "product_barcode";
            this.product_barcode.Name = "product_barcode";
            this.product_barcode.OptionsColumn.AllowEdit = false;
            this.product_barcode.OptionsColumn.AllowFocus = false;
            this.product_barcode.Visible = true;
            this.product_barcode.VisibleIndex = 9;
            // 
            // origin_position_address
            // 
            this.origin_position_address.Caption = "拆盘位置";
            this.origin_position_address.FieldName = "origin_position_address";
            this.origin_position_address.Name = "origin_position_address";
            this.origin_position_address.OptionsColumn.AllowEdit = false;
            this.origin_position_address.OptionsColumn.AllowFocus = false;
            this.origin_position_address.Visible = true;
            this.origin_position_address.VisibleIndex = 10;
            // 
            // target_supply_address
            // 
            this.target_supply_address.Caption = "补货目标地址";
            this.target_supply_address.FieldName = "target_supply_address";
            this.target_supply_address.Name = "target_supply_address";
            this.target_supply_address.OptionsColumn.AllowEdit = false;
            this.target_supply_address.OptionsColumn.AllowFocus = false;
            this.target_supply_address.Visible = true;
            this.target_supply_address.VisibleIndex = 11;
            this.target_supply_address.Width = 100;
            // 
            // status
            // 
            this.status.Caption = "是否可用";
            this.status.FieldName = "status";
            this.status.Name = "status";
            this.status.OptionsColumn.AllowEdit = false;
            this.status.OptionsColumn.AllowFocus = false;
            this.status.Visible = true;
            this.status.VisibleIndex = 12;
            // 
            // StockStatusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridStockStatusQuery);
            this.Name = "StockStatusControl";
            this.Size = new System.Drawing.Size(917, 403);
            ((System.ComponentModel.ISupportInitialize)(this.gridStockStatusQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewStockStatusQuery)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridStockStatusQuery;
        public DevExpress.XtraGrid.Views.Grid.GridView viewStockStatusQuery;
        private DevExpress.XtraGrid.Columns.GridColumn supply_id;
        private DevExpress.XtraGrid.Columns.GridColumn pack_no;
        private DevExpress.XtraGrid.Columns.GridColumn sorting_line_code;
        private DevExpress.XtraGrid.Columns.GridColumn group_no;
        private DevExpress.XtraGrid.Columns.GridColumn channel_code;
        private DevExpress.XtraGrid.Columns.GridColumn channel_name;
        private DevExpress.XtraGrid.Columns.GridColumn product_code;
        private DevExpress.XtraGrid.Columns.GridColumn product_name;
        private DevExpress.XtraGrid.Columns.GridColumn product_barcode;
        private DevExpress.XtraGrid.Columns.GridColumn origin_position_address;
        private DevExpress.XtraGrid.Columns.GridColumn target_supply_address;
        private DevExpress.XtraGrid.Columns.GridColumn status;
    }
}

