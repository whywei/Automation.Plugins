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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridMaster = new DevExpress.XtraGrid.GridControl();
            this.viewMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ORDERDATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BATCHNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PackNos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ORDERID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DistName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DeliverLineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LicenseNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustomerOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustomerDeliverOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FinishTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExportNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Quantitys = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDetail = new DevExpress.XtraGrid.GridControl();
            this.viewDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PackNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ChannelName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.customer_deliver_order = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Quantity1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExportNo1 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.splitContainerControl1.Size = new System.Drawing.Size(863, 450);
            this.splitContainerControl1.SplitterPosition = 193;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridMaster
            // 
            this.gridMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMaster.Location = new System.Drawing.Point(0, 0);
            this.gridMaster.MainView = this.viewMaster;
            this.gridMaster.Name = "gridMaster";
            this.gridMaster.Size = new System.Drawing.Size(863, 193);
            this.gridMaster.TabIndex = 0;
            this.gridMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewMaster});
            // 
            // viewMaster
            // 
            this.viewMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ORDERDATE,
            this.BATCHNO,
            this.PackNos,
            this.ORDERID,
            this.DistName,
            this.DeliverLineName,
            this.LicenseNo,
            this.CustomerOrder,
            this.CustomerDeliverOrder,
            this.FinishTime,
            this.StartTime,
            this.ExportNo,
            this.Quantitys,
            this.Address,
            this.Status,
            this.CustomerName});
            this.viewMaster.GridControl = this.gridMaster;
            this.viewMaster.Name = "viewMaster";
            this.viewMaster.OptionsView.ColumnAutoWidth = false;
            this.viewMaster.OptionsView.ShowGroupPanel = false;
            // 
            // ORDERDATE
            // 
            this.ORDERDATE.Caption = "订单日期";
            this.ORDERDATE.FieldName = "order_date";
            this.ORDERDATE.Name = "ORDERDATE";
            this.ORDERDATE.OptionsColumn.AllowEdit = false;
            this.ORDERDATE.OptionsColumn.AllowFocus = false;
            this.ORDERDATE.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ORDERDATE.Visible = true;
            this.ORDERDATE.VisibleIndex = 0;
            this.ORDERDATE.Width = 70;
            // 
            // BATCHNO
            // 
            this.BATCHNO.Caption = "批次号";
            this.BATCHNO.FieldName = "batch_no";
            this.BATCHNO.Name = "BATCHNO";
            this.BATCHNO.OptionsColumn.AllowEdit = false;
            this.BATCHNO.OptionsColumn.AllowFocus = false;
            this.BATCHNO.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.BATCHNO.Visible = true;
            this.BATCHNO.VisibleIndex = 1;
            this.BATCHNO.Width = 60;
            // 
            // PackNos
            // 
            this.PackNos.Caption = "烟包包号";
            this.PackNos.FieldName = "pack_no";
            this.PackNos.Name = "PackNos";
            this.PackNos.OptionsColumn.AllowEdit = false;
            this.PackNos.OptionsColumn.AllowFocus = false;
            this.PackNos.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.PackNos.Visible = true;
            this.PackNos.VisibleIndex = 2;
            this.PackNos.Width = 60;
            // 
            // ORDERID
            // 
            this.ORDERID.Caption = "订单号";
            this.ORDERID.FieldName = "order_id";
            this.ORDERID.Name = "ORDERID";
            this.ORDERID.OptionsColumn.AllowEdit = false;
            this.ORDERID.OptionsColumn.AllowFocus = false;
            this.ORDERID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ORDERID.Visible = true;
            this.ORDERID.VisibleIndex = 3;
            this.ORDERID.Width = 120;
            // 
            // DistName
            // 
            this.DistName.Caption = "销售区名称";
            this.DistName.FieldName = "dist_name";
            this.DistName.Name = "DistName";
            this.DistName.OptionsColumn.AllowEdit = false;
            this.DistName.OptionsColumn.AllowFocus = false;
            // 
            // DeliverLineName
            // 
            this.DeliverLineName.Caption = "线路名称";
            this.DeliverLineName.FieldName = "deliver_line_name";
            this.DeliverLineName.Name = "DeliverLineName";
            this.DeliverLineName.OptionsColumn.AllowEdit = false;
            this.DeliverLineName.OptionsColumn.AllowFocus = false;
            this.DeliverLineName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.DeliverLineName.Visible = true;
            this.DeliverLineName.VisibleIndex = 4;
            this.DeliverLineName.Width = 170;
            // 
            // LicenseNo
            // 
            this.LicenseNo.Caption = "许可证号";
            this.LicenseNo.FieldName = "license_no";
            this.LicenseNo.Name = "LicenseNo";
            this.LicenseNo.OptionsColumn.AllowEdit = false;
            this.LicenseNo.OptionsColumn.AllowFocus = false;
            this.LicenseNo.Visible = true;
            this.LicenseNo.VisibleIndex = 5;
            // 
            // CustomerOrder
            // 
            this.CustomerOrder.Caption = "客户顺序";
            this.CustomerOrder.FieldName = "customer_order";
            this.CustomerOrder.Name = "CustomerOrder";
            this.CustomerOrder.OptionsColumn.AllowEdit = false;
            this.CustomerOrder.OptionsColumn.AllowFocus = false;
            this.CustomerOrder.Visible = true;
            this.CustomerOrder.VisibleIndex = 6;
            // 
            // CustomerDeliverOrder
            // 
            this.CustomerDeliverOrder.Caption = "客户配送顺序";
            this.CustomerDeliverOrder.FieldName = "customer_deliver_order";
            this.CustomerDeliverOrder.Name = "CustomerDeliverOrder";
            this.CustomerDeliverOrder.OptionsColumn.AllowEdit = false;
            this.CustomerDeliverOrder.OptionsColumn.AllowFocus = false;
            // 
            // FinishTime
            // 
            this.FinishTime.Caption = "完成时间";
            this.FinishTime.FieldName = "finish_time";
            this.FinishTime.Name = "FinishTime";
            this.FinishTime.OptionsColumn.AllowEdit = false;
            this.FinishTime.OptionsColumn.AllowFocus = false;
            this.FinishTime.Visible = true;
            this.FinishTime.VisibleIndex = 7;
            // 
            // StartTime
            // 
            this.StartTime.Caption = "开始时间";
            this.StartTime.FieldName = "start_time";
            this.StartTime.Name = "StartTime";
            this.StartTime.OptionsColumn.AllowEdit = false;
            this.StartTime.OptionsColumn.AllowFocus = false;
            this.StartTime.Visible = true;
            this.StartTime.VisibleIndex = 8;
            // 
            // ExportNo
            // 
            this.ExportNo.Caption = "包装机方向";
            this.ExportNo.FieldName = "export_no";
            this.ExportNo.Name = "ExportNo";
            this.ExportNo.OptionsColumn.AllowEdit = false;
            this.ExportNo.OptionsColumn.AllowFocus = false;
            // 
            // Quantitys
            // 
            this.Quantitys.Caption = "烟包数量";
            this.Quantitys.FieldName = "quantity";
            this.Quantitys.Name = "Quantitys";
            this.Quantitys.OptionsColumn.AllowEdit = false;
            this.Quantitys.OptionsColumn.AllowFocus = false;
            // 
            // Address
            // 
            this.Address.Caption = "客户地址";
            this.Address.FieldName = "address";
            this.Address.Name = "Address";
            this.Address.OptionsColumn.AllowEdit = false;
            this.Address.OptionsColumn.AllowFocus = false;
            this.Address.Visible = true;
            this.Address.VisibleIndex = 9;
            // 
            // Status
            // 
            this.Status.Caption = "任务状态";
            this.Status.FieldName = "status";
            this.Status.Name = "Status";
            this.Status.OptionsColumn.AllowEdit = false;
            this.Status.OptionsColumn.AllowFocus = false;
            this.Status.Visible = true;
            this.Status.VisibleIndex = 10;
            // 
            // CustomerName
            // 
            this.CustomerName.Caption = "客户名称";
            this.CustomerName.FieldName = "customer_name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.OptionsColumn.AllowEdit = false;
            this.CustomerName.OptionsColumn.AllowFocus = false;
            this.CustomerName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.CustomerName.Visible = true;
            this.CustomerName.VisibleIndex = 11;
            this.CustomerName.Width = 130;
            // 
            // gridDetail
            // 
            this.gridDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetail.Location = new System.Drawing.Point(0, 0);
            this.gridDetail.MainView = this.viewDetail;
            this.gridDetail.Name = "gridDetail";
            this.gridDetail.Size = new System.Drawing.Size(863, 252);
            this.gridDetail.TabIndex = 0;
            this.gridDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewDetail});
            // 
            // viewDetail
            // 
            this.viewDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.PackNo,
            this.ProductName,
            this.ChannelName,
            this.Quantity1,
            this.customer_deliver_order,
            this.ExportNo1,
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
            this.PackNo.OptionsColumn.AllowFocus = false;
            this.PackNo.Visible = true;
            this.PackNo.VisibleIndex = 0;
            // 
            // ChannelName
            // 
            this.ChannelName.Caption = "烟道名称";
            this.ChannelName.FieldName = "channel_name";
            this.ChannelName.Name = "ChannelName";
            this.ChannelName.OptionsColumn.AllowFocus = false;
            this.ChannelName.Visible = true;
            this.ChannelName.VisibleIndex = 2;
            // 
            // ProductName
            // 
            this.ProductName.Caption = "商品名称";
            this.ProductName.FieldName = "product_name";
            this.ProductName.Name = "ProductName";
            this.ProductName.OptionsColumn.AllowFocus = false;
            this.ProductName.Visible = true;
            this.ProductName.VisibleIndex = 1;
            // 
            // Quantity
            // 
            this.Quantity.Caption = "数量";
            this.Quantity.FieldName = "quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.OptionsColumn.AllowFocus = false;
            this.Quantity.Visible = true;
            this.Quantity.VisibleIndex = 6;
            // 
            // customer_deliver_order
            // 
            this.customer_deliver_order.Caption = "客户配送顺序";
            this.customer_deliver_order.FieldName = "customer_deliver_order";
            this.customer_deliver_order.Name = "customer_deliver_order";
            this.customer_deliver_order.Visible = true;
            this.customer_deliver_order.VisibleIndex = 4;
            this.customer_deliver_order.Width = 90;
            // 
            // Quantity1
            // 
            this.Quantity1.Caption = "烟包数量";
            this.Quantity1.FieldName = "quantity1";
            this.Quantity1.Name = "Quantity1";
            this.Quantity1.Visible = true;
            this.Quantity1.VisibleIndex = 3;
            // 
            // ExportNo1
            // 
            this.ExportNo1.Caption = "包装机方向";
            this.ExportNo1.FieldName = "Export_No";
            this.ExportNo1.Name = "ExportNo1";
            this.ExportNo1.Visible = true;
            this.ExportNo1.VisibleIndex = 5;
            this.ExportNo1.Width = 80;
            // 
            // OrderQueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "OrderQueryControl";
            this.Size = new System.Drawing.Size(863, 450);
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
        private DevExpress.XtraGrid.Columns.GridColumn ORDERDATE;
        private DevExpress.XtraGrid.Columns.GridColumn BATCHNO;
        private DevExpress.XtraGrid.Columns.GridColumn PackNos;
        private DevExpress.XtraGrid.Columns.GridColumn ORDERID;
        private DevExpress.XtraGrid.Columns.GridColumn DistName;
        private DevExpress.XtraGrid.Columns.GridColumn DeliverLineName;
        private DevExpress.XtraGrid.Columns.GridColumn LicenseNo;
        private DevExpress.XtraGrid.Columns.GridColumn CustomerOrder;
        private DevExpress.XtraGrid.Columns.GridColumn CustomerDeliverOrder;
        private DevExpress.XtraGrid.Columns.GridColumn FinishTime;
        private DevExpress.XtraGrid.Columns.GridColumn StartTime;
        private DevExpress.XtraGrid.Columns.GridColumn ExportNo;
        private DevExpress.XtraGrid.Columns.GridColumn Quantitys;
        private DevExpress.XtraGrid.Columns.GridColumn Address;
        private DevExpress.XtraGrid.Columns.GridColumn Status;
        private DevExpress.XtraGrid.Columns.GridColumn CustomerName;
        public DevExpress.XtraGrid.GridControl gridDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView viewDetail;
        private DevExpress.XtraGrid.Columns.GridColumn PackNo;
        private DevExpress.XtraGrid.Columns.GridColumn ChannelName;
        private DevExpress.XtraGrid.Columns.GridColumn ProductName;
        private DevExpress.XtraGrid.Columns.GridColumn Quantity;
        private DevExpress.XtraGrid.Columns.GridColumn Quantity1;
        private DevExpress.XtraGrid.Columns.GridColumn customer_deliver_order;
        private DevExpress.XtraGrid.Columns.GridColumn ExportNo1;

    }
}
