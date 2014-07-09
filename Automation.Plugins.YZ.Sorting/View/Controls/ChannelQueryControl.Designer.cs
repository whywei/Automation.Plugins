namespace Automation.Plugins.YZ.Sorting.View.Controls
{
    partial class ChannelQueryControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
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
            this.gridChannelQuery = new DevExpress.XtraGrid.GridControl();
            this.viewChannelQuery = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ChannelCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ChannelName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ChannelType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RemainQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ChannelCapacity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GroupNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SortAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SupplyAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridChannelQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewChannelQuery)).BeginInit();
            this.SuspendLayout();
            // 
            // gridChannelQuery
            // 
            this.gridChannelQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridChannelQuery.Location = new System.Drawing.Point(0, 0);
            this.gridChannelQuery.MainView = this.viewChannelQuery;
            this.gridChannelQuery.Name = "gridChannelQuery";
            this.gridChannelQuery.Size = new System.Drawing.Size(730, 311);
            this.gridChannelQuery.TabIndex = 2;
            this.gridChannelQuery.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewChannelQuery});
            // 
            // viewChannelQuery
            // 
            this.viewChannelQuery.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ChannelCode,
            this.ChannelName,
            this.ChannelType,
            this.ProductName,
            this.Quantity,
            this.RemainQuantity,
            this.ChannelCapacity,
            this.GroupNo,
            this.OrderNo,
            this.SortAddress,
            this.SupplyAddress,
            this.IsActive});
            this.viewChannelQuery.GridControl = this.gridChannelQuery;
            this.viewChannelQuery.Name = "viewChannelQuery";
            this.viewChannelQuery.OptionsView.ColumnAutoWidth = false;
            this.viewChannelQuery.OptionsView.ShowGroupPanel = false;
            // 
            // ChannelCode
            // 
            this.ChannelCode.Caption = "烟道代码";
            this.ChannelCode.FieldName = "channel_code";
            this.ChannelCode.Name = "ChannelCode";
            this.ChannelCode.OptionsColumn.AllowEdit = false;
            this.ChannelCode.OptionsColumn.AllowFocus = false;
            this.ChannelCode.Visible = true;
            this.ChannelCode.VisibleIndex = 0;
            // 
            // ChannelName
            // 
            this.ChannelName.Caption = "烟道名称";
            this.ChannelName.FieldName = "channel_name";
            this.ChannelName.Name = "ChannelName";
            this.ChannelName.OptionsColumn.AllowEdit = false;
            this.ChannelName.OptionsColumn.AllowFocus = false;
            this.ChannelName.Visible = true;
            this.ChannelName.VisibleIndex = 1;
            // 
            // ChannelType
            // 
            this.ChannelType.Caption = "烟道类型";
            this.ChannelType.FieldName = "channel_type";
            this.ChannelType.Name = "ChannelType";
            this.ChannelType.OptionsColumn.AllowEdit = false;
            this.ChannelType.OptionsColumn.AllowFocus = false;
            this.ChannelType.Visible = true;
            this.ChannelType.VisibleIndex = 2;
            // 
            // ProductName
            // 
            this.ProductName.Caption = "商品名称";
            this.ProductName.FieldName = "product_name";
            this.ProductName.Name = "ProductName";
            this.ProductName.OptionsColumn.AllowEdit = false;
            this.ProductName.OptionsColumn.AllowFocus = false;
            this.ProductName.Visible = true;
            this.ProductName.VisibleIndex = 3;
            // 
            // Quantity
            // 
            this.Quantity.Caption = "商品数量";
            this.Quantity.FieldName = "quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.OptionsColumn.AllowEdit = false;
            this.Quantity.OptionsColumn.AllowFocus = false;
            this.Quantity.Visible = true;
            this.Quantity.VisibleIndex = 4;
            // 
            // RemainQuantity
            // 
            this.RemainQuantity.Caption = "剩余数量";
            this.RemainQuantity.FieldName = "remain_quantity";
            this.RemainQuantity.Name = "RemainQuantity";
            this.RemainQuantity.OptionsColumn.AllowEdit = false;
            this.RemainQuantity.OptionsColumn.AllowFocus = false;
            this.RemainQuantity.Visible = true;
            this.RemainQuantity.VisibleIndex = 5;
            // 
            // ChannelCapacity
            // 
            this.ChannelCapacity.Caption = "烟道容量";
            this.ChannelCapacity.FieldName = "channel_capacity";
            this.ChannelCapacity.Name = "ChannelCapacity";
            this.ChannelCapacity.OptionsColumn.AllowEdit = false;
            this.ChannelCapacity.OptionsColumn.AllowFocus = false;
            this.ChannelCapacity.Visible = true;
            this.ChannelCapacity.VisibleIndex = 6;
            // 
            // GroupNo
            // 
            this.GroupNo.Caption = "分拣线组号";
            this.GroupNo.FieldName = "group_no";
            this.GroupNo.Name = "GroupNo";
            this.GroupNo.OptionsColumn.AllowEdit = false;
            this.GroupNo.OptionsColumn.AllowFocus = false;
            this.GroupNo.Visible = true;
            this.GroupNo.VisibleIndex = 7;
            // 
            // OrderNo
            // 
            this.OrderNo.Caption = "顺序号";
            this.OrderNo.FieldName = "order_no";
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.OptionsColumn.AllowEdit = false;
            this.OrderNo.OptionsColumn.AllowFocus = false;
            this.OrderNo.Visible = true;
            this.OrderNo.VisibleIndex = 8;
            // 
            // SortAddress
            // 
            this.SortAddress.Caption = "分拣地址";
            this.SortAddress.FieldName = "sort_address";
            this.SortAddress.Name = "SortAddress";
            this.SortAddress.OptionsColumn.AllowEdit = false;
            this.SortAddress.OptionsColumn.AllowFocus = false;
            this.SortAddress.Visible = true;
            this.SortAddress.VisibleIndex = 9;
            // 
            // SupplyAddress
            // 
            this.SupplyAddress.Caption = "补货地址";
            this.SupplyAddress.FieldName = "supply_address";
            this.SupplyAddress.Name = "SupplyAddress";
            this.SupplyAddress.OptionsColumn.AllowEdit = false;
            this.SupplyAddress.OptionsColumn.AllowFocus = false;
            this.SupplyAddress.Visible = true;
            this.SupplyAddress.VisibleIndex = 10;
            // 
            // IsActive
            // 
            this.IsActive.Caption = "是否可用";
            this.IsActive.FieldName = "is_active";
            this.IsActive.Name = "IsActive";
            this.IsActive.OptionsColumn.AllowEdit = false;
            this.IsActive.OptionsColumn.AllowFocus = false;
            this.IsActive.Visible = true;
            this.IsActive.VisibleIndex = 11;
            // 
            // ChannelQueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridChannelQuery);
            this.Name = "ChannelQueryControl";
            this.Size = new System.Drawing.Size(730, 311);
            ((System.ComponentModel.ISupportInitialize)(this.gridChannelQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewChannelQuery)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridChannelQuery;
        public DevExpress.XtraGrid.Views.Grid.GridView viewChannelQuery;
        private DevExpress.XtraGrid.Columns.GridColumn ChannelCode;
        private DevExpress.XtraGrid.Columns.GridColumn ChannelName;
        private DevExpress.XtraGrid.Columns.GridColumn ChannelType;
        private DevExpress.XtraGrid.Columns.GridColumn ProductName;
        private DevExpress.XtraGrid.Columns.GridColumn Quantity;
        private DevExpress.XtraGrid.Columns.GridColumn RemainQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn ChannelCapacity;
        private DevExpress.XtraGrid.Columns.GridColumn GroupNo;
        private DevExpress.XtraGrid.Columns.GridColumn OrderNo;
        private DevExpress.XtraGrid.Columns.GridColumn SortAddress;
        private DevExpress.XtraGrid.Columns.GridColumn SupplyAddress;
        private DevExpress.XtraGrid.Columns.GridColumn IsActive;
    }
}
