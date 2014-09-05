namespace Automation.Plugins.Share.Sorting.View.Controls
{
    partial class PackDataControl
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
            this.gridPackData = new DevExpress.XtraGrid.GridControl();
            this.viewPackData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pack_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.customer_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.customer_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.product_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.product_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bag_quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.total_quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.export_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.deliver_line_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.deliver_line_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.line_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.order_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.batch_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridPackData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewPackData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridPackData
            // 
            this.gridPackData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPackData.Location = new System.Drawing.Point(2, 2);
            this.gridPackData.MainView = this.viewPackData;
            this.gridPackData.Name = "gridPackData";
            this.gridPackData.Size = new System.Drawing.Size(765, 327);
            this.gridPackData.TabIndex = 0;
            this.gridPackData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewPackData});
            // 
            // viewPackData
            // 
            this.viewPackData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.pack_no,
            this.customer_code,
            this.customer_name,
            this.product_code,
            this.product_name,
            this.quantity,
            this.bag_quantity,
            this.total_quantity,
            this.export_no,
            this.status,
            this.address,
            this.deliver_line_code,
            this.deliver_line_name,
            this.line_code,
            this.order_date,
            this.batch_no});
            this.viewPackData.GridControl = this.gridPackData;
            this.viewPackData.Name = "viewPackData";
            this.viewPackData.OptionsBehavior.ReadOnly = true;
            this.viewPackData.OptionsView.ColumnAutoWidth = false;
            this.viewPackData.OptionsView.ShowGroupPanel = false;
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "id";
            this.id.Name = "id";
            this.id.OptionsColumn.AllowFocus = false;
            // 
            // pack_no
            // 
            this.pack_no.Caption = "包号";
            this.pack_no.FieldName = "pack_no";
            this.pack_no.Name = "pack_no";
            this.pack_no.OptionsColumn.AllowFocus = false;
            this.pack_no.Visible = true;
            this.pack_no.VisibleIndex = 0;
            this.pack_no.Width = 50;
            // 
            // customer_code
            // 
            this.customer_code.Caption = "客户编码";
            this.customer_code.FieldName = "customer_code";
            this.customer_code.Name = "customer_code";
            this.customer_code.OptionsColumn.AllowFocus = false;
            // 
            // customer_name
            // 
            this.customer_name.Caption = "客户名称";
            this.customer_name.FieldName = "customer_name";
            this.customer_name.Name = "customer_name";
            this.customer_name.OptionsColumn.AllowFocus = false;
            this.customer_name.Visible = true;
            this.customer_name.VisibleIndex = 1;
            this.customer_name.Width = 120;
            // 
            // product_code
            // 
            this.product_code.Caption = "卷烟编码";
            this.product_code.FieldName = "product_code";
            this.product_code.Name = "product_code";
            this.product_code.OptionsColumn.AllowFocus = false;
            // 
            // product_name
            // 
            this.product_name.Caption = "卷烟名称";
            this.product_name.FieldName = "product_name";
            this.product_name.Name = "product_name";
            this.product_name.OptionsColumn.AllowFocus = false;
            this.product_name.Visible = true;
            this.product_name.VisibleIndex = 2;
            this.product_name.Width = 130;
            // 
            // quantity
            // 
            this.quantity.Caption = "当前烟数量";
            this.quantity.FieldName = "quantity";
            this.quantity.Name = "quantity";
            this.quantity.OptionsColumn.AllowFocus = false;
            this.quantity.Visible = true;
            this.quantity.VisibleIndex = 3;
            this.quantity.Width = 70;
            // 
            // bag_quantity
            // 
            this.bag_quantity.Caption = "当前包数量";
            this.bag_quantity.FieldName = "bag_quantity";
            this.bag_quantity.Name = "bag_quantity";
            this.bag_quantity.OptionsColumn.AllowFocus = false;
            this.bag_quantity.Visible = true;
            this.bag_quantity.VisibleIndex = 4;
            this.bag_quantity.Width = 70;
            // 
            // total_quantity
            // 
            this.total_quantity.Caption = "当前客户数量";
            this.total_quantity.FieldName = "total_quantity";
            this.total_quantity.Name = "total_quantity";
            this.total_quantity.OptionsColumn.AllowFocus = false;
            this.total_quantity.Visible = true;
            this.total_quantity.VisibleIndex = 5;
            this.total_quantity.Width = 80;
            // 
            // export_no
            // 
            this.export_no.Caption = "包装机号";
            this.export_no.FieldName = "export_no";
            this.export_no.Name = "export_no";
            this.export_no.OptionsColumn.AllowFocus = false;
            this.export_no.Visible = true;
            this.export_no.VisibleIndex = 6;
            this.export_no.Width = 60;
            // 
            // status
            // 
            this.status.Caption = "状态";
            this.status.FieldName = "status";
            this.status.Name = "status";
            this.status.OptionsColumn.AllowFocus = false;
            this.status.Visible = true;
            this.status.VisibleIndex = 7;
            this.status.Width = 80;
            // 
            // address
            // 
            this.address.Caption = "地址";
            this.address.FieldName = "address";
            this.address.Name = "address";
            this.address.OptionsColumn.AllowFocus = false;
            this.address.Visible = true;
            this.address.VisibleIndex = 8;
            this.address.Width = 150;
            // 
            // deliver_line_code
            // 
            this.deliver_line_code.Caption = "线路编码";
            this.deliver_line_code.FieldName = "deliver_line_code";
            this.deliver_line_code.Name = "deliver_line_code";
            this.deliver_line_code.OptionsColumn.AllowFocus = false;
            // 
            // deliver_line_name
            // 
            this.deliver_line_name.Caption = "线路名称";
            this.deliver_line_name.FieldName = "deliver_line_name";
            this.deliver_line_name.Name = "deliver_line_name";
            this.deliver_line_name.OptionsColumn.AllowFocus = false;
            this.deliver_line_name.Visible = true;
            this.deliver_line_name.VisibleIndex = 9;
            this.deliver_line_name.Width = 150;
            // 
            // line_code
            // 
            this.line_code.Caption = "分拣线编码";
            this.line_code.FieldName = "line_code";
            this.line_code.Name = "line_code";
            this.line_code.OptionsColumn.AllowFocus = false;
            this.line_code.Visible = true;
            this.line_code.VisibleIndex = 10;
            this.line_code.Width = 60;
            // 
            // order_date
            // 
            this.order_date.Caption = "订单日期";
            this.order_date.FieldName = "order_date";
            this.order_date.Name = "order_date";
            this.order_date.OptionsColumn.AllowFocus = false;
            this.order_date.Visible = true;
            this.order_date.VisibleIndex = 11;
            this.order_date.Width = 80;
            // 
            // batch_no
            // 
            this.batch_no.Caption = "批次";
            this.batch_no.FieldName = "batch_no";
            this.batch_no.Name = "batch_no";
            this.batch_no.OptionsColumn.AllowFocus = false;
            this.batch_no.Visible = true;
            this.batch_no.VisibleIndex = 12;
            this.batch_no.Width = 60;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridPackData);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(769, 331);
            this.panelControl2.TabIndex = 2;
            // 
            // PackDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Name = "PackDataControl";
            this.Size = new System.Drawing.Size(769, 331);
            ((System.ComponentModel.ISupportInitialize)(this.gridPackData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewPackData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn pack_no;
        private DevExpress.XtraGrid.Columns.GridColumn customer_code;
        private DevExpress.XtraGrid.Columns.GridColumn customer_name;
        private DevExpress.XtraGrid.Columns.GridColumn product_code;
        private DevExpress.XtraGrid.Columns.GridColumn product_name;
        private DevExpress.XtraGrid.Columns.GridColumn quantity;
        private DevExpress.XtraGrid.Columns.GridColumn bag_quantity;
        private DevExpress.XtraGrid.Columns.GridColumn total_quantity;
        private DevExpress.XtraGrid.Columns.GridColumn export_no;
        private DevExpress.XtraGrid.Columns.GridColumn status;
        private DevExpress.XtraGrid.Columns.GridColumn address;
        private DevExpress.XtraGrid.Columns.GridColumn deliver_line_code;
        private DevExpress.XtraGrid.Columns.GridColumn deliver_line_name;
        private DevExpress.XtraGrid.Columns.GridColumn line_code;
        private DevExpress.XtraGrid.Columns.GridColumn order_date;
        private DevExpress.XtraGrid.Columns.GridColumn batch_no;
        public DevExpress.XtraGrid.GridControl gridPackData;
        public DevExpress.XtraGrid.Views.Grid.GridView viewPackData;
        private DevExpress.XtraEditors.PanelControl panelControl2;
    }
}
