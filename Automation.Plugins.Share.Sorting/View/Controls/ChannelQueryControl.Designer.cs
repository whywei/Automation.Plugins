namespace Automation.Plugins.Share.Sorting.View.Controls
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
            this.channel_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.channel_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.channel_type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.product_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.product_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.remain_quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.group_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sort_address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.supply_address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.status = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridChannelQuery.Size = new System.Drawing.Size(917, 403);
            this.gridChannelQuery.TabIndex = 2;
            this.gridChannelQuery.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewChannelQuery});
            // 
            // viewChannelQuery
            // 
            this.viewChannelQuery.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.channel_code,
            this.channel_name,
            this.channel_type,
            this.product_code,
            this.product_name,
            this.quantity,
            this.remain_quantity,
            this.group_no,
            this.sort_address,
            this.supply_address,
            this.status});
            this.viewChannelQuery.GridControl = this.gridChannelQuery;
            this.viewChannelQuery.Name = "viewChannelQuery";
            this.viewChannelQuery.OptionsView.ColumnAutoWidth = false;
            this.viewChannelQuery.OptionsView.ShowGroupPanel = false;
            // 
            // channel_code
            // 
            this.channel_code.Caption = "烟道代码";
            this.channel_code.FieldName = "channel_code";
            this.channel_code.Name = "channel_code";
            this.channel_code.OptionsColumn.AllowEdit = false;
            this.channel_code.OptionsColumn.AllowFocus = false;
            this.channel_code.Visible = true;
            this.channel_code.VisibleIndex = 0;
            // 
            // channel_name
            // 
            this.channel_name.Caption = "烟道名称";
            this.channel_name.FieldName = "channel_name";
            this.channel_name.Name = "channel_name";
            this.channel_name.OptionsColumn.AllowEdit = false;
            this.channel_name.OptionsColumn.AllowFocus = false;
            this.channel_name.Visible = true;
            this.channel_name.VisibleIndex = 1;
            // 
            // channel_type
            // 
            this.channel_type.Caption = "烟道类型";
            this.channel_type.FieldName = "channel_type";
            this.channel_type.Name = "channel_type";
            this.channel_type.OptionsColumn.AllowEdit = false;
            this.channel_type.OptionsColumn.AllowFocus = false;
            this.channel_type.Visible = true;
            this.channel_type.VisibleIndex = 2;
            this.channel_type.Width = 85;
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
            this.quantity.Caption = "商品数量";
            this.quantity.FieldName = "quantity";
            this.quantity.Name = "quantity";
            this.quantity.OptionsColumn.AllowEdit = false;
            this.quantity.OptionsColumn.AllowFocus = false;
            this.quantity.Visible = true;
            this.quantity.VisibleIndex = 5;
            // 
            // remain_quantity
            // 
            this.remain_quantity.Caption = "剩余数量";
            this.remain_quantity.FieldName = "remain_quantity";
            this.remain_quantity.Name = "remain_quantity";
            this.remain_quantity.OptionsColumn.AllowEdit = false;
            this.remain_quantity.OptionsColumn.AllowFocus = false;
            this.remain_quantity.Visible = true;
            this.remain_quantity.VisibleIndex = 6;
            // 
            // group_no
            // 
            this.group_no.Caption = "分拣线组号";
            this.group_no.FieldName = "group_no";
            this.group_no.Name = "group_no";
            this.group_no.OptionsColumn.AllowEdit = false;
            this.group_no.OptionsColumn.AllowFocus = false;
            this.group_no.Visible = true;
            this.group_no.VisibleIndex = 7;
            // 
            // sort_address
            // 
            this.sort_address.Caption = "分拣地址";
            this.sort_address.FieldName = "sort_address";
            this.sort_address.Name = "sort_address";
            this.sort_address.OptionsColumn.AllowEdit = false;
            this.sort_address.OptionsColumn.AllowFocus = false;
            this.sort_address.Visible = true;
            this.sort_address.VisibleIndex = 8;
            // 
            // supply_address
            // 
            this.supply_address.Caption = "补货地址";
            this.supply_address.FieldName = "supply_address";
            this.supply_address.Name = "supply_address";
            this.supply_address.OptionsColumn.AllowEdit = false;
            this.supply_address.OptionsColumn.AllowFocus = false;
            this.supply_address.Visible = true;
            this.supply_address.VisibleIndex = 9;
            // 
            // status
            // 
            this.status.Caption = "是否可用";
            this.status.FieldName = "status";
            this.status.Name = "status";
            this.status.OptionsColumn.AllowEdit = false;
            this.status.OptionsColumn.AllowFocus = false;
            this.status.Visible = true;
            this.status.VisibleIndex = 10;
            // 
            // ChannelQueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridChannelQuery);
            this.Name = "ChannelQueryControl";
            this.Size = new System.Drawing.Size(917, 403);
            ((System.ComponentModel.ISupportInitialize)(this.gridChannelQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewChannelQuery)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridChannelQuery;
        public DevExpress.XtraGrid.Views.Grid.GridView viewChannelQuery;
        private DevExpress.XtraGrid.Columns.GridColumn channel_code;
        private DevExpress.XtraGrid.Columns.GridColumn channel_name;
        private DevExpress.XtraGrid.Columns.GridColumn channel_type;
        private DevExpress.XtraGrid.Columns.GridColumn product_name;
        private DevExpress.XtraGrid.Columns.GridColumn quantity;
        private DevExpress.XtraGrid.Columns.GridColumn remain_quantity;
        private DevExpress.XtraGrid.Columns.GridColumn group_no;
        private DevExpress.XtraGrid.Columns.GridColumn sort_address;
        private DevExpress.XtraGrid.Columns.GridColumn supply_address;
        private DevExpress.XtraGrid.Columns.GridColumn status;
        private DevExpress.XtraGrid.Columns.GridColumn product_code;
    }
}
