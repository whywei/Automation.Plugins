namespace Automation.Plugins.YZ.Sorting.View.Controls
{
    partial class OrderQueryControl
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
            this.gridSorting = new DevExpress.XtraGrid.GridControl();
            this.viewDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sort_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pack_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.customer_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.product_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Quantity1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bag_quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.channel_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.group_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.export_no = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridSorting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSorting
            // 
            this.gridSorting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSorting.Location = new System.Drawing.Point(0, 0);
            this.gridSorting.MainView = this.viewDetail;
            this.gridSorting.Name = "gridSorting";
            this.gridSorting.Size = new System.Drawing.Size(860, 227);
            this.gridSorting.TabIndex = 0;
            this.gridSorting.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewDetail});
            // 
            // viewDetail
            // 
            this.viewDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.sort_no,
            this.pack_no,
            this.customer_name,
            this.product_name,
            this.Quantity1,
            this.bag_quantity,
            this.channel_name,
            this.group_no,
            this.export_no});
            this.viewDetail.GridControl = this.gridSorting;
            this.viewDetail.Name = "viewDetail";
            this.viewDetail.OptionsView.ColumnAutoWidth = false;
            this.viewDetail.OptionsView.ShowGroupPanel = false;
            // 
            // sort_no
            // 
            this.sort_no.Caption = "流水号";
            this.sort_no.FieldName = "sort_no";
            this.sort_no.Name = "sort_no";
            this.sort_no.OptionsColumn.AllowFocus = false;
            this.sort_no.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.sort_no.Visible = true;
            this.sort_no.VisibleIndex = 0;
            this.sort_no.Width = 70;
            // 
            // pack_no
            // 
            this.pack_no.Caption = "包号";
            this.pack_no.FieldName = "pack_no";
            this.pack_no.Name = "pack_no";
            this.pack_no.OptionsColumn.AllowEdit = false;
            this.pack_no.OptionsColumn.AllowFocus = false;
            this.pack_no.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.pack_no.Visible = true;
            this.pack_no.VisibleIndex = 1;
            this.pack_no.Width = 70;
            // 
            // customer_name
            // 
            this.customer_name.Caption = "客户名称";
            this.customer_name.FieldName = "customer_name";
            this.customer_name.Name = "customer_name";
            this.customer_name.OptionsColumn.AllowEdit = false;
            this.customer_name.OptionsColumn.AllowFocus = false;
            this.customer_name.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.customer_name.Visible = true;
            this.customer_name.VisibleIndex = 2;
            this.customer_name.Width = 130;
            // 
            // product_name
            // 
            this.product_name.Caption = "卷烟名称";
            this.product_name.FieldName = "product_name";
            this.product_name.Name = "product_name";
            this.product_name.OptionsColumn.AllowEdit = false;
            this.product_name.OptionsColumn.AllowFocus = false;
            this.product_name.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.product_name.Visible = true;
            this.product_name.VisibleIndex = 3;
            this.product_name.Width = 130;
            // 
            // Quantity1
            // 
            this.Quantity1.Caption = "卷烟数量";
            this.Quantity1.FieldName = "quantity";
            this.Quantity1.Name = "Quantity1";
            this.Quantity1.OptionsColumn.AllowEdit = false;
            this.Quantity1.OptionsColumn.AllowFocus = false;
            this.Quantity1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.Quantity1.Visible = true;
            this.Quantity1.VisibleIndex = 4;
            this.Quantity1.Width = 70;
            // 
            // bag_quantity
            // 
            this.bag_quantity.Caption = "烟包数量";
            this.bag_quantity.FieldName = "bag_quantity";
            this.bag_quantity.Name = "bag_quantity";
            this.bag_quantity.OptionsColumn.AllowFocus = false;
            this.bag_quantity.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.bag_quantity.Visible = true;
            this.bag_quantity.VisibleIndex = 5;
            // 
            // channel_name
            // 
            this.channel_name.Caption = "烟道名称";
            this.channel_name.FieldName = "channel_name";
            this.channel_name.Name = "channel_name";
            this.channel_name.OptionsColumn.AllowEdit = false;
            this.channel_name.OptionsColumn.AllowFocus = false;
            this.channel_name.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.channel_name.Visible = true;
            this.channel_name.VisibleIndex = 6;
            this.channel_name.Width = 90;
            // 
            // group_no
            // 
            this.group_no.Caption = "烟道组";
            this.group_no.FieldName = "group_no";
            this.group_no.Name = "group_no";
            this.group_no.OptionsColumn.AllowEdit = false;
            this.group_no.OptionsColumn.AllowFocus = false;
            this.group_no.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.group_no.Visible = true;
            this.group_no.VisibleIndex = 7;
            this.group_no.Width = 80;
            // 
            // export_no
            // 
            this.export_no.Caption = "包装机";
            this.export_no.FieldName = "export_no";
            this.export_no.Name = "export_no";
            this.export_no.OptionsColumn.AllowEdit = false;
            this.export_no.OptionsColumn.AllowFocus = false;
            this.export_no.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.export_no.Visible = true;
            this.export_no.VisibleIndex = 8;
            this.export_no.Width = 70;
            // 
            // OrderQueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridSorting);
            this.Name = "OrderQueryControl";
            this.Size = new System.Drawing.Size(860, 227);
            ((System.ComponentModel.ISupportInitialize)(this.gridSorting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridSorting;
        private DevExpress.XtraGrid.Views.Grid.GridView viewDetail;
        private DevExpress.XtraGrid.Columns.GridColumn pack_no;
        private DevExpress.XtraGrid.Columns.GridColumn product_name;
        private DevExpress.XtraGrid.Columns.GridColumn customer_name;
        private DevExpress.XtraGrid.Columns.GridColumn export_no;
        private DevExpress.XtraGrid.Columns.GridColumn Quantity1;
        private DevExpress.XtraGrid.Columns.GridColumn channel_name;
        private DevExpress.XtraGrid.Columns.GridColumn group_no;
        private DevExpress.XtraGrid.Columns.GridColumn sort_no;
        private DevExpress.XtraGrid.Columns.GridColumn bag_quantity;

    }
}
