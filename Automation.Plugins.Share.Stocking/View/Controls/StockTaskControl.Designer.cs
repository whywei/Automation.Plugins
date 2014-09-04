namespace Automation.Plugins.Share.Stocking.View.Controls
{
    partial class StockTaskControl
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
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.orderstatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ledStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridStockStatusQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewStockStatusQuery)).BeginInit();
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
            // viewStockStatusQuery
            // 
            this.viewStockStatusQuery.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
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
            this.orderstatus,
            this.ledStatus});
            this.viewStockStatusQuery.GridControl = this.gridStockStatusQuery;
            this.viewStockStatusQuery.Name = "viewStockStatusQuery";
            this.viewStockStatusQuery.OptionsView.ColumnAutoWidth = false;
            this.viewStockStatusQuery.OptionsView.ShowGroupPanel = false;
            // 
            // id
            // 
            this.id.Caption = "补货编号";
            this.id.FieldName = "id";
            this.id.Name = "id";
            this.id.OptionsColumn.AllowEdit = false;
            this.id.OptionsColumn.AllowFocus = false;
            this.id.Visible = true;
            this.id.VisibleIndex = 0;
            this.id.Width = 65;
            // 
            // pack_no
            // 
            this.pack_no.Caption = "包装号";
            this.pack_no.FieldName = "pack_no";
            this.pack_no.Name = "pack_no";
            this.pack_no.OptionsColumn.AllowEdit = false;
            this.pack_no.OptionsColumn.AllowFocus = false;
            // 
            // sorting_line_code
            // 
            this.sorting_line_code.Caption = "分拣线号";
            this.sorting_line_code.FieldName = "sorting_line_code";
            this.sorting_line_code.Name = "sorting_line_code";
            this.sorting_line_code.OptionsColumn.AllowEdit = false;
            this.sorting_line_code.OptionsColumn.AllowFocus = false;
            this.sorting_line_code.Visible = true;
            this.sorting_line_code.VisibleIndex = 1;
            this.sorting_line_code.Width = 65;
            // 
            // group_no
            // 
            this.group_no.Caption = "组号";
            this.group_no.FieldName = "group_no";
            this.group_no.Name = "group_no";
            this.group_no.OptionsColumn.AllowEdit = false;
            this.group_no.OptionsColumn.AllowFocus = false;
            this.group_no.Visible = true;
            this.group_no.VisibleIndex = 2;
            this.group_no.Width = 40;
            // 
            // channel_code
            // 
            this.channel_code.Caption = "烟道编码";
            this.channel_code.FieldName = "channel_code";
            this.channel_code.Name = "channel_code";
            this.channel_code.OptionsColumn.AllowEdit = false;
            this.channel_code.OptionsColumn.AllowFocus = false;
            this.channel_code.Visible = true;
            this.channel_code.VisibleIndex = 3;
            // 
            // channel_name
            // 
            this.channel_name.Caption = "烟道名称";
            this.channel_name.FieldName = "channel_name";
            this.channel_name.Name = "channel_name";
            this.channel_name.OptionsColumn.AllowEdit = false;
            this.channel_name.OptionsColumn.AllowFocus = false;
            this.channel_name.Visible = true;
            this.channel_name.VisibleIndex = 4;
            this.channel_name.Width = 100;
            // 
            // product_code
            // 
            this.product_code.Caption = "商品编码";
            this.product_code.FieldName = "product_code";
            this.product_code.Name = "product_code";
            this.product_code.OptionsColumn.AllowEdit = false;
            this.product_code.OptionsColumn.AllowFocus = false;
            this.product_code.Visible = true;
            this.product_code.VisibleIndex = 5;
            // 
            // product_name
            // 
            this.product_name.Caption = "商品名称";
            this.product_name.FieldName = "product_name";
            this.product_name.Name = "product_name";
            this.product_name.OptionsColumn.AllowEdit = false;
            this.product_name.OptionsColumn.AllowFocus = false;
            this.product_name.Visible = true;
            this.product_name.VisibleIndex = 6;
            this.product_name.Width = 150;
            // 
            // product_barcode
            // 
            this.product_barcode.Caption = "卷烟条码";
            this.product_barcode.FieldName = "product_barcode";
            this.product_barcode.Name = "product_barcode";
            this.product_barcode.OptionsColumn.AllowEdit = false;
            this.product_barcode.OptionsColumn.AllowFocus = false;
            this.product_barcode.Visible = true;
            this.product_barcode.VisibleIndex = 7;
            // 
            // origin_position_address
            // 
            this.origin_position_address.Caption = "拆盘位置";
            this.origin_position_address.FieldName = "origin_position_address";
            this.origin_position_address.Name = "origin_position_address";
            this.origin_position_address.OptionsColumn.AllowEdit = false;
            this.origin_position_address.OptionsColumn.AllowFocus = false;
            this.origin_position_address.Visible = true;
            this.origin_position_address.VisibleIndex = 8;
            this.origin_position_address.Width = 70;
            // 
            // target_supply_address
            // 
            this.target_supply_address.Caption = "目标地址";
            this.target_supply_address.FieldName = "target_supply_address";
            this.target_supply_address.Name = "target_supply_address";
            this.target_supply_address.OptionsColumn.AllowEdit = false;
            this.target_supply_address.OptionsColumn.AllowFocus = false;
            this.target_supply_address.Visible = true;
            this.target_supply_address.VisibleIndex = 9;
            this.target_supply_address.Width = 70;
            // 
            // orderstatus
            // 
            this.orderstatus.Caption = "订单状态";
            this.orderstatus.FieldName = "orderstatus";
            this.orderstatus.Name = "orderstatus";
            this.orderstatus.OptionsColumn.AllowEdit = false;
            this.orderstatus.OptionsColumn.AllowFocus = false;
            this.orderstatus.Visible = true;
            this.orderstatus.VisibleIndex = 10;
            // 
            // ledStatus
            // 
            this.ledStatus.Caption = "LED状态";
            this.ledStatus.FieldName = "ledStatus";
            this.ledStatus.Name = "ledStatus";
            this.ledStatus.OptionsColumn.AllowEdit = false;
            this.ledStatus.OptionsColumn.AllowFocus = false;
            this.ledStatus.Visible = true;
            this.ledStatus.VisibleIndex = 11;
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
        private DevExpress.XtraGrid.Columns.GridColumn id;
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
        private DevExpress.XtraGrid.Columns.GridColumn orderstatus;
        private DevExpress.XtraGrid.Columns.GridColumn ledStatus;
    }
}

