namespace Automation.Plugins.Sorting.View.Controls
{
    partial class OrderQueryControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridMaster = new DevExpress.XtraGrid.GridControl();
            this.viewMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ORDERDATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BATCHNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SORTNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ORDERID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ROUTENAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUSTOMERCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUSTOMERNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.STATUS_A = new DevExpress.XtraGrid.Columns.GridColumn();
            this.STATUS_B = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDetail = new DevExpress.XtraGrid.GridControl();
            this.viewDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SORTNO_Detail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PACKNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ORDERID_Detail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CHANNELNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CHANNELTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CIGARETTECODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CIGARETTENAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QUANTITY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CHANNELLINE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CHANNELADDRESS = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.splitContainerControl1.Size = new System.Drawing.Size(740, 386);
            this.splitContainerControl1.SplitterPosition = 193;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridMaster
            // 
            this.gridMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMaster.Location = new System.Drawing.Point(0, 0);
            this.gridMaster.MainView = this.viewMaster;
            this.gridMaster.Name = "gridMaster";
            this.gridMaster.Size = new System.Drawing.Size(740, 193);
            this.gridMaster.TabIndex = 0;
            this.gridMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewMaster});
            // 
            // viewMaster
            // 
            this.viewMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ORDERDATE,
            this.BATCHNO,
            this.SORTNO,
            this.ORDERID,
            this.ROUTENAME,
            this.CUSTOMERCODE,
            this.CUSTOMERNAME,
            this.STATUS_A,
            this.STATUS_B});
            this.viewMaster.GridControl = this.gridMaster;
            this.viewMaster.Name = "viewMaster";
            this.viewMaster.OptionsView.ColumnAutoWidth = false;
            this.viewMaster.OptionsView.ShowGroupPanel = false;
            // 
            // ORDERDATE
            // 
            this.ORDERDATE.Caption = "订单日期";
            this.ORDERDATE.FieldName = "ORDERDATE";
            this.ORDERDATE.Name = "ORDERDATE";
            this.ORDERDATE.OptionsColumn.AllowFocus = false;
            this.ORDERDATE.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ORDERDATE.Visible = true;
            this.ORDERDATE.VisibleIndex = 0;
            this.ORDERDATE.Width = 70;
            // 
            // BATCHNO
            // 
            this.BATCHNO.Caption = "分拣批次";
            this.BATCHNO.FieldName = "BATCHNO";
            this.BATCHNO.Name = "BATCHNO";
            this.BATCHNO.OptionsColumn.AllowFocus = false;
            this.BATCHNO.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.BATCHNO.Visible = true;
            this.BATCHNO.VisibleIndex = 1;
            this.BATCHNO.Width = 60;
            // 
            // SORTNO
            // 
            this.SORTNO.Caption = "流水号";
            this.SORTNO.FieldName = "SORTNO";
            this.SORTNO.Name = "SORTNO";
            this.SORTNO.OptionsColumn.AllowFocus = false;
            this.SORTNO.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.SORTNO.Visible = true;
            this.SORTNO.VisibleIndex = 2;
            this.SORTNO.Width = 60;
            // 
            // ORDERID
            // 
            this.ORDERID.Caption = "订单号";
            this.ORDERID.FieldName = "ORDERID";
            this.ORDERID.Name = "ORDERID";
            this.ORDERID.OptionsColumn.AllowFocus = false;
            this.ORDERID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ORDERID.Visible = true;
            this.ORDERID.VisibleIndex = 3;
            this.ORDERID.Width = 120;
            // 
            // ROUTENAME
            // 
            this.ROUTENAME.Caption = "线路名称";
            this.ROUTENAME.FieldName = "ROUTENAME";
            this.ROUTENAME.Name = "ROUTENAME";
            this.ROUTENAME.OptionsColumn.AllowFocus = false;
            this.ROUTENAME.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ROUTENAME.Visible = true;
            this.ROUTENAME.VisibleIndex = 4;
            this.ROUTENAME.Width = 170;
            // 
            // CUSTOMERCODE
            // 
            this.CUSTOMERCODE.Caption = "客户代码";
            this.CUSTOMERCODE.FieldName = "CUSTOMERCODE";
            this.CUSTOMERCODE.Name = "CUSTOMERCODE";
            this.CUSTOMERCODE.OptionsColumn.AllowFocus = false;
            this.CUSTOMERCODE.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.CUSTOMERCODE.Visible = true;
            this.CUSTOMERCODE.VisibleIndex = 5;
            this.CUSTOMERCODE.Width = 130;
            // 
            // CUSTOMERNAME
            // 
            this.CUSTOMERNAME.Caption = "客户名称";
            this.CUSTOMERNAME.FieldName = "CUSTOMERNAME";
            this.CUSTOMERNAME.Name = "CUSTOMERNAME";
            this.CUSTOMERNAME.OptionsColumn.AllowFocus = false;
            this.CUSTOMERNAME.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.CUSTOMERNAME.Visible = true;
            this.CUSTOMERNAME.VisibleIndex = 6;
            this.CUSTOMERNAME.Width = 180;
            // 
            // STATUS_A
            // 
            this.STATUS_A.Caption = "A线下单状态";
            this.STATUS_A.FieldName = "STATUS_A";
            this.STATUS_A.Name = "STATUS_A";
            this.STATUS_A.OptionsColumn.AllowFocus = false;
            this.STATUS_A.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.STATUS_A.Visible = true;
            this.STATUS_A.VisibleIndex = 7;
            this.STATUS_A.Width = 80;
            // 
            // STATUS_B
            // 
            this.STATUS_B.Caption = "B线下单状态";
            this.STATUS_B.FieldName = "STATUS_B";
            this.STATUS_B.Name = "STATUS_B";
            this.STATUS_B.OptionsColumn.AllowFocus = false;
            this.STATUS_B.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.STATUS_B.Visible = true;
            this.STATUS_B.VisibleIndex = 8;
            this.STATUS_B.Width = 80;
            // 
            // gridDetail
            // 
            this.gridDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetail.Location = new System.Drawing.Point(0, 0);
            this.gridDetail.MainView = this.viewDetail;
            this.gridDetail.Name = "gridDetail";
            this.gridDetail.Size = new System.Drawing.Size(740, 188);
            this.gridDetail.TabIndex = 0;
            this.gridDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewDetail});
            // 
            // viewDetail
            // 
            this.viewDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SORTNO_Detail,
            this.PACKNO,
            this.ORDERID_Detail,
            this.CHANNELNAME,
            this.CHANNELTYPE,
            this.CIGARETTECODE,
            this.CIGARETTENAME,
            this.QUANTITY,
            this.CHANNELLINE,
            this.CHANNELADDRESS});
            this.viewDetail.GridControl = this.gridDetail;
            this.viewDetail.Name = "viewDetail";
            this.viewDetail.OptionsView.ColumnAutoWidth = false;
            this.viewDetail.OptionsView.ShowGroupPanel = false;
            // 
            // SORTNO_Detail
            // 
            this.SORTNO_Detail.Caption = "流水号";
            this.SORTNO_Detail.FieldName = "SORTNO";
            this.SORTNO_Detail.Name = "SORTNO_Detail";
            this.SORTNO_Detail.OptionsColumn.AllowFocus = false;
            this.SORTNO_Detail.Visible = true;
            this.SORTNO_Detail.VisibleIndex = 0;
            this.SORTNO_Detail.Width = 70;
            // 
            // PACKNO
            // 
            this.PACKNO.Caption = "包号";
            this.PACKNO.FieldName = "PACKNO";
            this.PACKNO.Name = "PACKNO";
            this.PACKNO.OptionsColumn.AllowFocus = false;
            this.PACKNO.Visible = true;
            this.PACKNO.VisibleIndex = 1;
            this.PACKNO.Width = 70;
            // 
            // ORDERID_Detail
            // 
            this.ORDERID_Detail.Caption = "订单号";
            this.ORDERID_Detail.FieldName = "ORDERID";
            this.ORDERID_Detail.Name = "ORDERID_Detail";
            this.ORDERID_Detail.OptionsColumn.AllowFocus = false;
            this.ORDERID_Detail.Visible = true;
            this.ORDERID_Detail.VisibleIndex = 2;
            this.ORDERID_Detail.Width = 120;
            // 
            // CHANNELNAME
            // 
            this.CHANNELNAME.Caption = "烟道名称";
            this.CHANNELNAME.FieldName = "CHANNELNAME";
            this.CHANNELNAME.Name = "CHANNELNAME";
            this.CHANNELNAME.OptionsColumn.AllowFocus = false;
            this.CHANNELNAME.Visible = true;
            this.CHANNELNAME.VisibleIndex = 3;
            this.CHANNELNAME.Width = 80;
            // 
            // CHANNELTYPE
            // 
            this.CHANNELTYPE.Caption = "烟道类型";
            this.CHANNELTYPE.FieldName = "CHANNELTYPE";
            this.CHANNELTYPE.Name = "CHANNELTYPE";
            this.CHANNELTYPE.OptionsColumn.AllowFocus = false;
            this.CHANNELTYPE.Visible = true;
            this.CHANNELTYPE.VisibleIndex = 4;
            this.CHANNELTYPE.Width = 80;
            // 
            // CIGARETTECODE
            // 
            this.CIGARETTECODE.Caption = "卷烟代码";
            this.CIGARETTECODE.FieldName = "CIGARETTECODE";
            this.CIGARETTECODE.Name = "CIGARETTECODE";
            this.CIGARETTECODE.OptionsColumn.AllowFocus = false;
            this.CIGARETTECODE.Visible = true;
            this.CIGARETTECODE.VisibleIndex = 6;
            this.CIGARETTECODE.Width = 80;
            // 
            // CIGARETTENAME
            // 
            this.CIGARETTENAME.Caption = "卷烟名称";
            this.CIGARETTENAME.FieldName = "CIGARETTENAME";
            this.CIGARETTENAME.Name = "CIGARETTENAME";
            this.CIGARETTENAME.OptionsColumn.AllowFocus = false;
            this.CIGARETTENAME.Visible = true;
            this.CIGARETTENAME.VisibleIndex = 5;
            this.CIGARETTENAME.Width = 140;
            // 
            // QUANTITY
            // 
            this.QUANTITY.Caption = "数量";
            this.QUANTITY.FieldName = "QUANTITY";
            this.QUANTITY.Name = "QUANTITY";
            this.QUANTITY.OptionsColumn.AllowFocus = false;
            this.QUANTITY.Visible = true;
            this.QUANTITY.VisibleIndex = 7;
            this.QUANTITY.Width = 60;
            // 
            // CHANNELLINE
            // 
            this.CHANNELLINE.Caption = "线组";
            this.CHANNELLINE.FieldName = "CHANNELLINE";
            this.CHANNELLINE.Name = "CHANNELLINE";
            this.CHANNELLINE.OptionsColumn.AllowFocus = false;
            this.CHANNELLINE.Visible = true;
            this.CHANNELLINE.VisibleIndex = 8;
            this.CHANNELLINE.Width = 60;
            // 
            // CHANNELADDRESS
            // 
            this.CHANNELADDRESS.Caption = "烟道地址";
            this.CHANNELADDRESS.FieldName = "CHANNELADDRESS";
            this.CHANNELADDRESS.Name = "CHANNELADDRESS";
            this.CHANNELADDRESS.OptionsColumn.AllowFocus = false;
            this.CHANNELADDRESS.Visible = true;
            this.CHANNELADDRESS.VisibleIndex = 9;
            this.CHANNELADDRESS.Width = 80;
            // 
            // OrderQueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "OrderQueryControl";
            this.Size = new System.Drawing.Size(740, 386);
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
        private DevExpress.XtraGrid.Columns.GridColumn ORDERDATE;
        private DevExpress.XtraGrid.Columns.GridColumn BATCHNO;
        private DevExpress.XtraGrid.Columns.GridColumn SORTNO;
        private DevExpress.XtraGrid.Columns.GridColumn ORDERID;
        private DevExpress.XtraGrid.Columns.GridColumn ROUTENAME;
        private DevExpress.XtraGrid.Columns.GridColumn CUSTOMERCODE;
        private DevExpress.XtraGrid.Columns.GridColumn CUSTOMERNAME;
        private DevExpress.XtraGrid.Columns.GridColumn STATUS_A;
        private DevExpress.XtraGrid.Columns.GridColumn STATUS_B;
        private DevExpress.XtraGrid.Views.Grid.GridView viewDetail;
        private DevExpress.XtraGrid.Columns.GridColumn SORTNO_Detail;
        private DevExpress.XtraGrid.Columns.GridColumn PACKNO;
        private DevExpress.XtraGrid.Columns.GridColumn ORDERID_Detail;
        private DevExpress.XtraGrid.Columns.GridColumn CHANNELNAME;
        private DevExpress.XtraGrid.Columns.GridColumn CHANNELTYPE;
        private DevExpress.XtraGrid.Columns.GridColumn CIGARETTECODE;
        private DevExpress.XtraGrid.Columns.GridColumn CIGARETTENAME;
        private DevExpress.XtraGrid.Columns.GridColumn QUANTITY;
        private DevExpress.XtraGrid.Columns.GridColumn CHANNELLINE;
        private DevExpress.XtraGrid.Columns.GridColumn CHANNELADDRESS;
        public DevExpress.XtraGrid.GridControl gridMaster;
        public DevExpress.XtraGrid.Views.Grid.GridView viewMaster;
        public DevExpress.XtraGrid.GridControl gridDetail;


    }
}
