namespace Automation.Plugins.Stocking.View.Controls
{
    partial class StockChannelQueryControl
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
            this.gridStockChannel = new DevExpress.XtraGrid.GridControl();
            this.viewStockChannel = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CHANNELCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CHANNELNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CHANNELTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CIGARETTECODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CIGARETTENAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SUMQUANTITY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SCANNERQUANTITY = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridStockChannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewStockChannel)).BeginInit();
            this.SuspendLayout();
            // 
            // gridStockChannel
            // 
            this.gridStockChannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStockChannel.Location = new System.Drawing.Point(0, 0);
            this.gridStockChannel.MainView = this.viewStockChannel;
            this.gridStockChannel.Name = "gridStockChannel";
            this.gridStockChannel.Size = new System.Drawing.Size(687, 279);
            this.gridStockChannel.TabIndex = 0;
            this.gridStockChannel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewStockChannel});
            // 
            // viewStockChannel
            // 
            this.viewStockChannel.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CHANNELCODE,
            this.CHANNELNAME,
            this.CHANNELTYPE,
            this.CIGARETTECODE,
            this.CIGARETTENAME,
            this.SUMQUANTITY,
            this.SCANNERQUANTITY});
            this.viewStockChannel.GridControl = this.gridStockChannel;
            this.viewStockChannel.Name = "viewStockChannel";
            this.viewStockChannel.OptionsView.ColumnAutoWidth = false;
            this.viewStockChannel.OptionsView.ShowGroupPanel = false;
            // 
            // CHANNELCODE
            // 
            this.CHANNELCODE.Caption = "烟道代码";
            this.CHANNELCODE.FieldName = "CHANNELCODE";
            this.CHANNELCODE.Name = "CHANNELCODE";
            this.CHANNELCODE.OptionsColumn.AllowFocus = false;
            this.CHANNELCODE.Width = 80;
            // 
            // CHANNELNAME
            // 
            this.CHANNELNAME.Caption = "烟道名称";
            this.CHANNELNAME.FieldName = "CHANNELNAME";
            this.CHANNELNAME.Name = "CHANNELNAME";
            this.CHANNELNAME.OptionsColumn.AllowFocus = false;
            this.CHANNELNAME.Visible = true;
            this.CHANNELNAME.VisibleIndex = 0;
            this.CHANNELNAME.Width = 80;
            // 
            // CHANNELTYPE
            // 
            this.CHANNELTYPE.Caption = "烟道类型";
            this.CHANNELTYPE.FieldName = "CHANNELTYPE";
            this.CHANNELTYPE.Name = "CHANNELTYPE";
            this.CHANNELTYPE.OptionsColumn.AllowFocus = false;
            this.CHANNELTYPE.Visible = true;
            this.CHANNELTYPE.VisibleIndex = 1;
            this.CHANNELTYPE.Width = 170;
            // 
            // CIGARETTECODE
            // 
            this.CIGARETTECODE.Caption = "卷烟代码";
            this.CIGARETTECODE.FieldName = "CIGARETTECODE";
            this.CIGARETTECODE.Name = "CIGARETTECODE";
            this.CIGARETTECODE.OptionsColumn.AllowFocus = false;
            this.CIGARETTECODE.Visible = true;
            this.CIGARETTECODE.VisibleIndex = 2;
            this.CIGARETTECODE.Width = 80;
            // 
            // CIGARETTENAME
            // 
            this.CIGARETTENAME.Caption = "卷烟名称";
            this.CIGARETTENAME.FieldName = "CIGARETTENAME";
            this.CIGARETTENAME.Name = "CIGARETTENAME";
            this.CIGARETTENAME.OptionsColumn.AllowFocus = false;
            this.CIGARETTENAME.Visible = true;
            this.CIGARETTENAME.VisibleIndex = 3;
            this.CIGARETTENAME.Width = 160;
            // 
            // SUMQUANTITY
            // 
            this.SUMQUANTITY.Caption = "补货总件数";
            this.SUMQUANTITY.FieldName = "SUMQUANTITY";
            this.SUMQUANTITY.Name = "SUMQUANTITY";
            this.SUMQUANTITY.OptionsColumn.AllowFocus = false;
            this.SUMQUANTITY.Visible = true;
            this.SUMQUANTITY.VisibleIndex = 4;
            this.SUMQUANTITY.Width = 80;
            // 
            // SCANNERQUANTITY
            // 
            this.SCANNERQUANTITY.Caption = "已扫码件数";
            this.SCANNERQUANTITY.FieldName = "SCANNERQUANTITY";
            this.SCANNERQUANTITY.Name = "SCANNERQUANTITY";
            this.SCANNERQUANTITY.OptionsColumn.AllowFocus = false;
            this.SCANNERQUANTITY.Visible = true;
            this.SCANNERQUANTITY.VisibleIndex = 5;
            this.SCANNERQUANTITY.Width = 80;
            // 
            // StockChannelQueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridStockChannel);
            this.Name = "StockChannelQueryControl";
            this.Size = new System.Drawing.Size(687, 279);
            ((System.ComponentModel.ISupportInitialize)(this.gridStockChannel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewStockChannel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView viewStockChannel;
        private DevExpress.XtraGrid.Columns.GridColumn CHANNELCODE;
        private DevExpress.XtraGrid.Columns.GridColumn CHANNELNAME;
        private DevExpress.XtraGrid.Columns.GridColumn CHANNELTYPE;
        private DevExpress.XtraGrid.Columns.GridColumn CIGARETTECODE;
        private DevExpress.XtraGrid.Columns.GridColumn CIGARETTENAME;
        private DevExpress.XtraGrid.Columns.GridColumn SUMQUANTITY;
        private DevExpress.XtraGrid.Columns.GridColumn SCANNERQUANTITY;
        public DevExpress.XtraGrid.GridControl gridStockChannel;
    }
}
