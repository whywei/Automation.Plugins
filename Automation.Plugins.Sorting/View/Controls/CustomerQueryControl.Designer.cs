namespace Automation.Plugins.Sorting.View.Controls
{
    partial class CustomerQueryControl
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
            this.ORDERNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SORTNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ORDERID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ROUTECODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ROUTENAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUSTOMERCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUSTOMERNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QUANTITY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QUANTITY1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ALLQUANTITY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDetail = new DevExpress.XtraGrid.GridControl();
            this.viewDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.detailSORTNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.detailORDERID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PACKNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.detailORDERNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CHANNELNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CHANNELTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CIGARETTECODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CIGARETTENAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.detailQUANTITY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CHANNELLINE = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.splitContainerControl1.Size = new System.Drawing.Size(744, 346);
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
            this.gridMaster.Size = new System.Drawing.Size(744, 193);
            this.gridMaster.TabIndex = 0;
            this.gridMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewMaster});
            // 
            // viewMaster
            // 
            this.viewMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ORDERDATE,
            this.ORDERNO,
            this.SORTNO,
            this.ORDERID,
            this.ROUTECODE,
            this.ROUTENAME,
            this.CUSTOMERCODE,
            this.CUSTOMERNAME,
            this.QUANTITY,
            this.QUANTITY1,
            this.ALLQUANTITY});
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
            this.ORDERDATE.Width = 80;
            // 
            // ORDERNO
            // 
            this.ORDERNO.Caption = "客户顺序号";
            this.ORDERNO.FieldName = "ORDERNO";
            this.ORDERNO.Name = "ORDERNO";
            this.ORDERNO.OptionsColumn.AllowFocus = false;
            this.ORDERNO.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ORDERNO.Visible = true;
            this.ORDERNO.VisibleIndex = 1;
            this.ORDERNO.Width = 80;
            // 
            // SORTNO
            // 
            this.SORTNO.Caption = "分拣流水号";
            this.SORTNO.FieldName = "SORTNO";
            this.SORTNO.Name = "SORTNO";
            this.SORTNO.OptionsColumn.AllowFocus = false;
            this.SORTNO.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.SORTNO.Visible = true;
            this.SORTNO.VisibleIndex = 2;
            this.SORTNO.Width = 80;
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
            // ROUTECODE
            // 
            this.ROUTECODE.Caption = "线路代码";
            this.ROUTECODE.FieldName = "ROUTECODE";
            this.ROUTECODE.Name = "ROUTECODE";
            this.ROUTECODE.OptionsColumn.AllowFocus = false;
            this.ROUTECODE.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ROUTECODE.Visible = true;
            this.ROUTECODE.VisibleIndex = 4;
            this.ROUTECODE.Width = 80;
            // 
            // ROUTENAME
            // 
            this.ROUTENAME.Caption = "线路名称";
            this.ROUTENAME.FieldName = "ROUTENAME";
            this.ROUTENAME.Name = "ROUTENAME";
            this.ROUTENAME.OptionsColumn.AllowFocus = false;
            this.ROUTENAME.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ROUTENAME.Visible = true;
            this.ROUTENAME.VisibleIndex = 5;
            this.ROUTENAME.Width = 80;
            // 
            // CUSTOMERCODE
            // 
            this.CUSTOMERCODE.Caption = "客户代码";
            this.CUSTOMERCODE.FieldName = "CUSTOMERCODE";
            this.CUSTOMERCODE.Name = "CUSTOMERCODE";
            this.CUSTOMERCODE.OptionsColumn.AllowFocus = false;
            this.CUSTOMERCODE.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.CUSTOMERCODE.Visible = true;
            this.CUSTOMERCODE.VisibleIndex = 6;
            this.CUSTOMERCODE.Width = 100;
            // 
            // CUSTOMERNAME
            // 
            this.CUSTOMERNAME.Caption = "客户名称";
            this.CUSTOMERNAME.FieldName = "CUSTOMERNAME";
            this.CUSTOMERNAME.Name = "CUSTOMERNAME";
            this.CUSTOMERNAME.OptionsColumn.AllowFocus = false;
            this.CUSTOMERNAME.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.CUSTOMERNAME.Visible = true;
            this.CUSTOMERNAME.VisibleIndex = 7;
            this.CUSTOMERNAME.Width = 170;
            // 
            // QUANTITY
            // 
            this.QUANTITY.Caption = "A线总数量";
            this.QUANTITY.FieldName = "QUANTITY";
            this.QUANTITY.Name = "QUANTITY";
            this.QUANTITY.OptionsColumn.AllowFocus = false;
            this.QUANTITY.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.QUANTITY.Visible = true;
            this.QUANTITY.VisibleIndex = 8;
            this.QUANTITY.Width = 80;
            // 
            // QUANTITY1
            // 
            this.QUANTITY1.Caption = "B线总数量";
            this.QUANTITY1.FieldName = "QUANTITY1";
            this.QUANTITY1.Name = "QUANTITY1";
            this.QUANTITY1.OptionsColumn.AllowFocus = false;
            this.QUANTITY1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.QUANTITY1.Visible = true;
            this.QUANTITY1.VisibleIndex = 9;
            this.QUANTITY1.Width = 80;
            // 
            // ALLQUANTITY
            // 
            this.ALLQUANTITY.Caption = "总数量";
            this.ALLQUANTITY.FieldName = "ALLQUANTITY";
            this.ALLQUANTITY.Name = "ALLQUANTITY";
            this.ALLQUANTITY.OptionsColumn.AllowFocus = false;
            this.ALLQUANTITY.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ALLQUANTITY.Visible = true;
            this.ALLQUANTITY.VisibleIndex = 10;
            this.ALLQUANTITY.Width = 80;
            // 
            // gridDetail
            // 
            this.gridDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetail.Location = new System.Drawing.Point(0, 0);
            this.gridDetail.MainView = this.viewDetail;
            this.gridDetail.Name = "gridDetail";
            this.gridDetail.Size = new System.Drawing.Size(744, 148);
            this.gridDetail.TabIndex = 0;
            this.gridDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewDetail});
            // 
            // viewDetail
            // 
            this.viewDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.detailSORTNO,
            this.detailORDERID,
            this.PACKNO,
            this.detailORDERNO,
            this.CHANNELNAME,
            this.CHANNELTYPE,
            this.CIGARETTECODE,
            this.CIGARETTENAME,
            this.detailQUANTITY,
            this.CHANNELLINE});
            this.viewDetail.GridControl = this.gridDetail;
            this.viewDetail.Name = "viewDetail";
            this.viewDetail.OptionsView.ColumnAutoWidth = false;
            this.viewDetail.OptionsView.ShowGroupPanel = false;
            // 
            // detailSORTNO
            // 
            this.detailSORTNO.Caption = "流水号";
            this.detailSORTNO.FieldName = "SORTNO";
            this.detailSORTNO.Name = "detailSORTNO";
            this.detailSORTNO.OptionsColumn.AllowFocus = false;
            this.detailSORTNO.Visible = true;
            this.detailSORTNO.VisibleIndex = 0;
            this.detailSORTNO.Width = 80;
            // 
            // detailORDERID
            // 
            this.detailORDERID.Caption = "订单号";
            this.detailORDERID.FieldName = "ORDERID";
            this.detailORDERID.Name = "detailORDERID";
            this.detailORDERID.OptionsColumn.AllowFocus = false;
            this.detailORDERID.Visible = true;
            this.detailORDERID.VisibleIndex = 1;
            this.detailORDERID.Width = 100;
            // 
            // PACKNO
            // 
            this.PACKNO.Caption = "包号";
            this.PACKNO.FieldName = "PACKNO";
            this.PACKNO.Name = "PACKNO";
            this.PACKNO.OptionsColumn.AllowFocus = false;
            this.PACKNO.Visible = true;
            this.PACKNO.VisibleIndex = 2;
            this.PACKNO.Width = 80;
            // 
            // detailORDERNO
            // 
            this.detailORDERNO.Caption = "客户流水号";
            this.detailORDERNO.FieldName = "ORDERNO";
            this.detailORDERNO.Name = "detailORDERNO";
            this.detailORDERNO.OptionsColumn.AllowFocus = false;
            this.detailORDERNO.Visible = true;
            this.detailORDERNO.VisibleIndex = 3;
            this.detailORDERNO.Width = 80;
            // 
            // CHANNELNAME
            // 
            this.CHANNELNAME.Caption = "烟道名称";
            this.CHANNELNAME.FieldName = "CHANNELNAME";
            this.CHANNELNAME.Name = "CHANNELNAME";
            this.CHANNELNAME.OptionsColumn.AllowFocus = false;
            this.CHANNELNAME.Visible = true;
            this.CHANNELNAME.VisibleIndex = 4;
            this.CHANNELNAME.Width = 80;
            // 
            // CHANNELTYPE
            // 
            this.CHANNELTYPE.Caption = "烟道类型";
            this.CHANNELTYPE.FieldName = "CHANNELTYPE";
            this.CHANNELTYPE.Name = "CHANNELTYPE";
            this.CHANNELTYPE.OptionsColumn.AllowFocus = false;
            this.CHANNELTYPE.Visible = true;
            this.CHANNELTYPE.VisibleIndex = 5;
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
            this.CIGARETTENAME.VisibleIndex = 7;
            this.CIGARETTENAME.Width = 120;
            // 
            // detailQUANTITY
            // 
            this.detailQUANTITY.Caption = "数量";
            this.detailQUANTITY.FieldName = "QUANTITY";
            this.detailQUANTITY.Name = "detailQUANTITY";
            this.detailQUANTITY.OptionsColumn.AllowFocus = false;
            this.detailQUANTITY.Visible = true;
            this.detailQUANTITY.VisibleIndex = 8;
            this.detailQUANTITY.Width = 80;
            // 
            // CHANNELLINE
            // 
            this.CHANNELLINE.Caption = "线组";
            this.CHANNELLINE.FieldName = "CHANNELLINE";
            this.CHANNELLINE.Name = "CHANNELLINE";
            this.CHANNELLINE.OptionsColumn.AllowFocus = false;
            this.CHANNELLINE.Visible = true;
            this.CHANNELLINE.VisibleIndex = 9;
            this.CHANNELLINE.Width = 80;
            // 
            // CustomerQueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "CustomerQueryControl";
            this.Size = new System.Drawing.Size(744, 346);
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
        private DevExpress.XtraGrid.Columns.GridColumn ORDERNO;
        private DevExpress.XtraGrid.Columns.GridColumn SORTNO;
        private DevExpress.XtraGrid.Columns.GridColumn ORDERID;
        private DevExpress.XtraGrid.Columns.GridColumn ROUTECODE;
        private DevExpress.XtraGrid.Columns.GridColumn ROUTENAME;
        private DevExpress.XtraGrid.Columns.GridColumn CUSTOMERCODE;
        private DevExpress.XtraGrid.Columns.GridColumn CUSTOMERNAME;
        private DevExpress.XtraGrid.Columns.GridColumn QUANTITY;
        private DevExpress.XtraGrid.Columns.GridColumn QUANTITY1;
        private DevExpress.XtraGrid.Columns.GridColumn ALLQUANTITY;
        public DevExpress.XtraGrid.GridControl gridDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView viewDetail;
        private DevExpress.XtraGrid.Columns.GridColumn detailSORTNO;
        private DevExpress.XtraGrid.Columns.GridColumn detailORDERID;
        private DevExpress.XtraGrid.Columns.GridColumn PACKNO;
        private DevExpress.XtraGrid.Columns.GridColumn detailORDERNO;
        private DevExpress.XtraGrid.Columns.GridColumn CHANNELNAME;
        private DevExpress.XtraGrid.Columns.GridColumn CHANNELTYPE;
        private DevExpress.XtraGrid.Columns.GridColumn CIGARETTECODE;
        private DevExpress.XtraGrid.Columns.GridColumn CIGARETTENAME;
        private DevExpress.XtraGrid.Columns.GridColumn detailQUANTITY;
        private DevExpress.XtraGrid.Columns.GridColumn CHANNELLINE;
    }
}
