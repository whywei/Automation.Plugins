namespace Automation.Plugins.YZ.Sorting.View.Controls
{
    partial class CustomerQueryControl
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridMaster = new DevExpress.XtraGrid.GridControl();
            this.viewMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.customer_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.customer_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.order_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.deliver_line_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dist_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.customer_Info = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pack_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDetail = new DevExpress.XtraGrid.GridControl();
            this.viewDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PackNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridMaster);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridDetail);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(730, 311);
            this.splitContainerControl1.SplitterPosition = 193;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridMaster
            // 
            this.gridMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMaster.Location = new System.Drawing.Point(0, 0);
            this.gridMaster.MainView = this.viewMaster;
            this.gridMaster.Name = "gridMaster";
            this.gridMaster.Size = new System.Drawing.Size(730, 193);
            this.gridMaster.TabIndex = 0;
            this.gridMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewMaster});
            // 
            // viewMaster
            // 
            this.viewMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.customer_code,
            this.customer_name,
            this.order_date,
            this.deliver_line_name,
            this.dist_name,
            this.address,
            this.customer_Info,
            this.pack_no,
            this.status});
            this.viewMaster.GridControl = this.gridMaster;
            this.viewMaster.Name = "viewMaster";
            this.viewMaster.OptionsView.ColumnAutoWidth = false;
            this.viewMaster.OptionsView.ShowGroupPanel = false;
            // 
            // customer_code
            // 
            this.customer_code.Caption = "客户代码";
            this.customer_code.FieldName = "customer_code";
            this.customer_code.Name = "customer_code";
            this.customer_code.OptionsColumn.AllowEdit = false;
            this.customer_code.OptionsColumn.AllowFocus = false;
            this.customer_code.Visible = true;
            this.customer_code.VisibleIndex = 0;
            // 
            // customer_name
            // 
            this.customer_name.Caption = "客户名称";
            this.customer_name.FieldName = "customer_name";
            this.customer_name.Name = "customer_name";
            this.customer_name.OptionsColumn.AllowEdit = false;
            this.customer_name.OptionsColumn.AllowFocus = false;
            this.customer_name.Visible = true;
            this.customer_name.VisibleIndex = 1;
            // 
            // order_date
            // 
            this.order_date.Caption = "订单日期";
            this.order_date.FieldName = "order_date";
            this.order_date.Name = "order_date";
            this.order_date.OptionsColumn.AllowEdit = false;
            this.order_date.OptionsColumn.AllowFocus = false;
            this.order_date.Visible = true;
            this.order_date.VisibleIndex = 2;
            // 
            // deliver_line_name
            // 
            this.deliver_line_name.Caption = "线路名称";
            this.deliver_line_name.FieldName = "deliver_line_name";
            this.deliver_line_name.Name = "deliver_line_name";
            this.deliver_line_name.OptionsColumn.AllowEdit = false;
            this.deliver_line_name.OptionsColumn.AllowFocus = false;
            this.deliver_line_name.Visible = true;
            this.deliver_line_name.VisibleIndex = 3;
            // 
            // dist_name
            // 
            this.dist_name.Caption = "区域名称";
            this.dist_name.FieldName = "dist_name";
            this.dist_name.Name = "dist_name";
            this.dist_name.OptionsColumn.AllowEdit = false;
            this.dist_name.OptionsColumn.AllowFocus = false;
            this.dist_name.Visible = true;
            this.dist_name.VisibleIndex = 4;
            // 
            // address
            // 
            this.address.Caption = "客户地址";
            this.address.FieldName = "address";
            this.address.Name = "address";
            this.address.OptionsColumn.AllowEdit = false;
            this.address.OptionsColumn.AllowFocus = false;
            this.address.Visible = true;
            this.address.VisibleIndex = 5;
            // 
            // customer_Info
            // 
            this.customer_Info.Caption = "客户信息";
            this.customer_Info.FieldName = "customer_Info";
            this.customer_Info.Name = "customer_Info";
            this.customer_Info.OptionsColumn.AllowEdit = false;
            this.customer_Info.OptionsColumn.AllowFocus = false;
            this.customer_Info.Visible = true;
            this.customer_Info.VisibleIndex = 6;
            // 
            // pack_no
            // 
            this.pack_no.Caption = "烟包数量";
            this.pack_no.FieldName = "quantity";
            this.pack_no.Name = "pack_no";
            this.pack_no.OptionsColumn.AllowEdit = false;
            this.pack_no.OptionsColumn.AllowFocus = false;
            this.pack_no.Visible = true;
            this.pack_no.VisibleIndex = 7;
            // 
            // status
            // 
            this.status.Caption = " 任务状态";
            this.status.FieldName = "status";
            this.status.Name = "status";
            this.status.OptionsColumn.AllowEdit = false;
            this.status.OptionsColumn.AllowFocus = false;
            this.status.Visible = true;
            this.status.VisibleIndex = 8;
            // 
            // gridDetail
            // 
            this.gridDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetail.Location = new System.Drawing.Point(0, 0);
            this.gridDetail.MainView = this.viewDetail;
            this.gridDetail.Name = "gridDetail";
            this.gridDetail.Size = new System.Drawing.Size(730, 113);
            this.gridDetail.TabIndex = 0;
            this.gridDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewDetail});
            // 
            // viewDetail
            // 
            this.viewDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.PackNo,
            this.ProductName,
            this.Quantity});
            this.viewDetail.GridControl = this.gridDetail;
            this.viewDetail.Name = "viewDetail";
            this.viewDetail.OptionsView.ColumnAutoWidth = false;
            this.viewDetail.OptionsView.ShowGroupPanel = false;
            // 
            // PackNo
            // 
            this.PackNo.Caption = "包号";
            this.PackNo.FieldName = "pack_no";
            this.PackNo.Name = "PackNo";
            this.PackNo.OptionsColumn.AllowEdit = false;
            this.PackNo.OptionsColumn.AllowFocus = false;
            this.PackNo.Visible = true;
            this.PackNo.VisibleIndex = 0;
            // 
            // ProductName
            // 
            this.ProductName.Caption = "商品名称";
            this.ProductName.FieldName = "product_name";
            this.ProductName.Name = "ProductName";
            this.ProductName.OptionsColumn.AllowEdit = false;
            this.ProductName.OptionsColumn.AllowFocus = false;
            this.ProductName.Visible = true;
            this.ProductName.VisibleIndex = 1;
            // 
            // Quantity
            // 
            this.Quantity.Caption = "数量";
            this.Quantity.FieldName = "quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.OptionsColumn.AllowEdit = false;
            this.Quantity.OptionsColumn.AllowFocus = false;
            this.Quantity.Visible = true;
            this.Quantity.VisibleIndex = 2;
            // 
            // CustomerQueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "CustomerQueryControl";
            this.Size = new System.Drawing.Size(730, 311);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        public DevExpress.XtraGrid.GridControl gridMaster;
        public DevExpress.XtraGrid.Views.Grid.GridView viewMaster;
        public DevExpress.XtraGrid.GridControl gridDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView viewDetail;
        private DevExpress.XtraGrid.Columns.GridColumn PackNo;
        private DevExpress.XtraGrid.Columns.GridColumn ProductName;
        private DevExpress.XtraGrid.Columns.GridColumn Quantity;
        private DevExpress.XtraGrid.Columns.GridColumn customer_code;
        private DevExpress.XtraGrid.Columns.GridColumn customer_name;
        private DevExpress.XtraGrid.Columns.GridColumn order_date;
        private DevExpress.XtraGrid.Columns.GridColumn deliver_line_name;
        private DevExpress.XtraGrid.Columns.GridColumn dist_name;
        private DevExpress.XtraGrid.Columns.GridColumn address;
        private DevExpress.XtraGrid.Columns.GridColumn customer_Info;
        private DevExpress.XtraGrid.Columns.GridColumn pack_no;
        private DevExpress.XtraGrid.Columns.GridColumn status;
    }
}
