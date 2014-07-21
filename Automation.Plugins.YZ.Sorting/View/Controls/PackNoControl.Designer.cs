namespace Automation.Plugins.YZ.Sorting.View.Controls
{
    partial class PackNoControl
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
            this.OrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.batch_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pack_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dist_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.deliverLine_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mquantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDetail = new DevExpress.XtraGrid.GridControl();
            this.viewDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PackNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OrderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Quantity1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ChannelLine = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ChannelName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ChannelType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ChannelAddress = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.splitContainerControl1.TabIndex = 2;
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
            this.OrderDate,
            this.batch_no,
            this.pack_no,
            this.dist_name,
            this.deliverLine_name,
            this.CustomerName,
            this.mquantity,
            this.Status});
            this.viewMaster.GridControl = this.gridMaster;
            this.viewMaster.Name = "viewMaster";
            this.viewMaster.OptionsView.ColumnAutoWidth = false;
            this.viewMaster.OptionsView.ShowGroupPanel = false;
            // 
            // OrderDate
            // 
            this.OrderDate.Caption = "订单日期";
            this.OrderDate.FieldName = "order_date";
            this.OrderDate.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.OrderDate.Name = "OrderDate";
            this.OrderDate.OptionsColumn.AllowEdit = false;
            this.OrderDate.OptionsColumn.AllowFocus = false;
            this.OrderDate.Visible = true;
            this.OrderDate.VisibleIndex = 0;
            this.OrderDate.Width = 120;
            // 
            // batch_no
            // 
            this.batch_no.Caption = "批次号";
            this.batch_no.FieldName = "batch_no";
            this.batch_no.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.batch_no.Name = "batch_no";
            this.batch_no.OptionsColumn.AllowEdit = false;
            this.batch_no.OptionsColumn.AllowFocus = false;
            this.batch_no.Visible = true;
            this.batch_no.VisibleIndex = 1;
            this.batch_no.Width = 50;
            // 
            // pack_no
            // 
            this.pack_no.Caption = "烟包包号";
            this.pack_no.FieldName = "pack_no";
            this.pack_no.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.pack_no.Name = "pack_no";
            this.pack_no.OptionsColumn.AllowEdit = false;
            this.pack_no.OptionsColumn.AllowFocus = false;
            this.pack_no.Visible = true;
            this.pack_no.VisibleIndex = 2;
            // 
            // dist_name
            // 
            this.dist_name.Caption = "区域名称";
            this.dist_name.FieldName = "dist_name";
            this.dist_name.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.dist_name.Name = "dist_name";
            this.dist_name.OptionsColumn.AllowEdit = false;
            this.dist_name.OptionsColumn.AllowFocus = false;
            this.dist_name.Visible = true;
            this.dist_name.VisibleIndex = 3;
            this.dist_name.Width = 150;
            // 
            // deliverLine_name
            // 
            this.deliverLine_name.Caption = "线路名称";
            this.deliverLine_name.FieldName = "deliver_line_name";
            this.deliverLine_name.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.deliverLine_name.Name = "deliverLine_name";
            this.deliverLine_name.OptionsColumn.AllowEdit = false;
            this.deliverLine_name.OptionsColumn.AllowFocus = false;
            this.deliverLine_name.Visible = true;
            this.deliverLine_name.VisibleIndex = 4;
            this.deliverLine_name.Width = 150;
            // 
            // CustomerName
            // 
            this.CustomerName.Caption = "客户名称";
            this.CustomerName.FieldName = "customer_name";
            this.CustomerName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.OptionsColumn.AllowEdit = false;
            this.CustomerName.OptionsColumn.AllowFocus = false;
            this.CustomerName.Visible = true;
            this.CustomerName.VisibleIndex = 5;
            this.CustomerName.Width = 150;
            // 
            // mquantity
            // 
            this.mquantity.Caption = "烟包数量";
            this.mquantity.FieldName = "mquantity";
            this.mquantity.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.mquantity.Name = "mquantity";
            this.mquantity.OptionsColumn.AllowEdit = false;
            this.mquantity.OptionsColumn.AllowFocus = false;
            this.mquantity.Visible = true;
            this.mquantity.VisibleIndex = 6;
            // 
            // Status
            // 
            this.Status.Caption = " 任务状态";
            this.Status.FieldName = "status";
            this.Status.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.Status.Name = "Status";
            this.Status.OptionsColumn.AllowEdit = false;
            this.Status.OptionsColumn.AllowFocus = false;
            this.Status.Visible = true;
            this.Status.VisibleIndex = 7;
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
            this.OrderId,
            this.ProductCode,
            this.ProductName,
            this.Quantity1,
            this.ChannelLine,
            this.ChannelName,
            this.ChannelType,
            this.ChannelAddress});
            this.viewDetail.GridControl = this.gridDetail;
            this.viewDetail.Name = "viewDetail";
            this.viewDetail.OptionsView.ColumnAutoWidth = false;
            this.viewDetail.OptionsView.ShowGroupPanel = false;
            // 
            // PackNo
            // 
            this.PackNo.Caption = "包号";
            this.PackNo.FieldName = "pack_no";
            this.PackNo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.PackNo.Name = "PackNo";
            this.PackNo.OptionsColumn.AllowEdit = false;
            this.PackNo.OptionsColumn.AllowFocus = false;
            this.PackNo.Visible = true;
            this.PackNo.VisibleIndex = 0;
            this.PackNo.Width = 50;
            // 
            // OrderId
            // 
            this.OrderId.Caption = "订单号";
            this.OrderId.FieldName = "order_id";
            this.OrderId.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.OrderId.Name = "OrderId";
            this.OrderId.OptionsColumn.AllowEdit = false;
            this.OrderId.OptionsColumn.AllowFocus = false;
            this.OrderId.Visible = true;
            this.OrderId.VisibleIndex = 1;
            this.OrderId.Width = 150;
            // 
            // ProductCode
            // 
            this.ProductCode.Caption = "卷烟代码";
            this.ProductCode.FieldName = "product_code";
            this.ProductCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.ProductCode.Name = "ProductCode";
            this.ProductCode.OptionsColumn.AllowEdit = false;
            this.ProductCode.OptionsColumn.AllowFocus = false;
            this.ProductCode.Visible = true;
            this.ProductCode.VisibleIndex = 2;
            // 
            // ProductName
            // 
            this.ProductName.Caption = "卷烟名称";
            this.ProductName.FieldName = "product_name";
            this.ProductName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.ProductName.Name = "ProductName";
            this.ProductName.OptionsColumn.AllowEdit = false;
            this.ProductName.OptionsColumn.AllowFocus = false;
            this.ProductName.Visible = true;
            this.ProductName.VisibleIndex = 3;
            this.ProductName.Width = 120;
            // 
            // Quantity1
            // 
            this.Quantity1.Caption = "数量";
            this.Quantity1.FieldName = "dquantity";
            this.Quantity1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.Quantity1.Name = "Quantity1";
            this.Quantity1.OptionsColumn.AllowEdit = false;
            this.Quantity1.OptionsColumn.AllowFocus = false;
            this.Quantity1.Visible = true;
            this.Quantity1.VisibleIndex = 4;
            // 
            // ChannelLine
            // 
            this.ChannelLine.Caption = "线组";
            this.ChannelLine.FieldName = "channelline";
            this.ChannelLine.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.ChannelLine.Name = "ChannelLine";
            this.ChannelLine.OptionsColumn.AllowEdit = false;
            this.ChannelLine.OptionsColumn.AllowFocus = false;
            this.ChannelLine.Visible = true;
            this.ChannelLine.VisibleIndex = 5;
            this.ChannelLine.Width = 50;
            // 
            // ChannelName
            // 
            this.ChannelName.Caption = "烟道名称";
            this.ChannelName.FieldName = "channel_name";
            this.ChannelName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.ChannelName.Name = "ChannelName";
            this.ChannelName.OptionsColumn.AllowEdit = false;
            this.ChannelName.OptionsColumn.AllowFocus = false;
            this.ChannelName.Visible = true;
            this.ChannelName.VisibleIndex = 6;
            // 
            // ChannelType
            // 
            this.ChannelType.Caption = "烟道类型";
            this.ChannelType.FieldName = "channel_type";
            this.ChannelType.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.ChannelType.Name = "ChannelType";
            this.ChannelType.OptionsColumn.AllowEdit = false;
            this.ChannelType.OptionsColumn.AllowFocus = false;
            this.ChannelType.Visible = true;
            this.ChannelType.VisibleIndex = 7;
            this.ChannelType.Width = 100;
            // 
            // ChannelAddress
            // 
            this.ChannelAddress.Caption = "烟道地址";
            this.ChannelAddress.FieldName = "sort_address";
            this.ChannelAddress.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.ChannelAddress.Name = "ChannelAddress";
            this.ChannelAddress.OptionsColumn.AllowEdit = false;
            this.ChannelAddress.OptionsColumn.AllowFocus = false;
            this.ChannelAddress.Visible = true;
            this.ChannelAddress.VisibleIndex = 8;
            // 
            // PackNoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "PackNoControl";
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
        public DevExpress.XtraGrid.GridControl gridDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView viewDetail;
        private DevExpress.XtraGrid.Columns.GridColumn PackNo;
        private DevExpress.XtraGrid.Columns.GridColumn ProductName;
        private DevExpress.XtraGrid.Columns.GridColumn Quantity1;
        private DevExpress.XtraGrid.Columns.GridColumn OrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn pack_no;
        private DevExpress.XtraGrid.Columns.GridColumn batch_no;
        private DevExpress.XtraGrid.Columns.GridColumn deliverLine_name;
        private DevExpress.XtraGrid.Columns.GridColumn dist_name;
        private DevExpress.XtraGrid.Columns.GridColumn CustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn mquantity;
        private DevExpress.XtraGrid.Columns.GridColumn Status;
        private DevExpress.XtraGrid.Columns.GridColumn ChannelLine;
        private DevExpress.XtraGrid.Columns.GridColumn ChannelName;
        private DevExpress.XtraGrid.Columns.GridColumn OrderId;
        private DevExpress.XtraGrid.Columns.GridColumn ProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn ChannelType;
        private DevExpress.XtraGrid.Columns.GridColumn ChannelAddress;
    }
}
