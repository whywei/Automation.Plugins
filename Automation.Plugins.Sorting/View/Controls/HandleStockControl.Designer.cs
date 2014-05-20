namespace Automation.Plugins.Sorting.View.Controls
{
    partial class HandleStockControl
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
            this.gridHandleStock = new DevExpress.XtraGrid.GridControl();
            this.viewHandleStock = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BATCHNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SUPPLYNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SORTNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SUPPLYBATCH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CHANNELNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CIGARETTECODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CIGARETTENAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QUANTITY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.STATUS = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridHandleStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewHandleStock)).BeginInit();
            this.SuspendLayout();
            // 
            // gridHandleStock
            // 
            this.gridHandleStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridHandleStock.Location = new System.Drawing.Point(0, 0);
            this.gridHandleStock.MainView = this.viewHandleStock;
            this.gridHandleStock.Name = "gridHandleStock";
            this.gridHandleStock.Size = new System.Drawing.Size(725, 327);
            this.gridHandleStock.TabIndex = 0;
            this.gridHandleStock.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewHandleStock});
            // 
            // viewHandleStock
            // 
            this.viewHandleStock.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.BATCHNO,
            this.SUPPLYNO,
            this.SORTNO,
            this.SUPPLYBATCH,
            this.CHANNELNAME,
            this.CIGARETTECODE,
            this.CIGARETTENAME,
            this.QUANTITY,
            this.STATUS});
            this.viewHandleStock.GridControl = this.gridHandleStock;
            this.viewHandleStock.Name = "viewHandleStock";
            this.viewHandleStock.OptionsView.ColumnAutoWidth = false;
            this.viewHandleStock.OptionsView.ShowGroupPanel = false;
            // 
            // BATCHNO
            // 
            this.BATCHNO.Caption = "分拣批次";
            this.BATCHNO.FieldName = "BATCHNO";
            this.BATCHNO.Name = "BATCHNO";
            this.BATCHNO.OptionsColumn.AllowFocus = false;
            this.BATCHNO.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.BATCHNO.Visible = true;
            this.BATCHNO.VisibleIndex = 0;
            this.BATCHNO.Width = 80;
            // 
            // SUPPLYNO
            // 
            this.SUPPLYNO.Caption = "补货编号";
            this.SUPPLYNO.FieldName = "SUPPLYNO";
            this.SUPPLYNO.Name = "SUPPLYNO";
            this.SUPPLYNO.OptionsColumn.AllowFocus = false;
            this.SUPPLYNO.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.SUPPLYNO.Visible = true;
            this.SUPPLYNO.VisibleIndex = 1;
            this.SUPPLYNO.Width = 80;
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
            this.SORTNO.Width = 80;
            // 
            // SUPPLYBATCH
            // 
            this.SUPPLYBATCH.Caption = "补货批次";
            this.SUPPLYBATCH.FieldName = "SUPPLYBATCH";
            this.SUPPLYBATCH.Name = "SUPPLYBATCH";
            this.SUPPLYBATCH.OptionsColumn.AllowFocus = false;
            this.SUPPLYBATCH.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.SUPPLYBATCH.Visible = true;
            this.SUPPLYBATCH.VisibleIndex = 3;
            this.SUPPLYBATCH.Width = 80;
            // 
            // CHANNELNAME
            // 
            this.CHANNELNAME.Caption = "烟道名称";
            this.CHANNELNAME.FieldName = "CHANNELNAME";
            this.CHANNELNAME.Name = "CHANNELNAME";
            this.CHANNELNAME.OptionsColumn.AllowFocus = false;
            this.CHANNELNAME.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.CHANNELNAME.Visible = true;
            this.CHANNELNAME.VisibleIndex = 4;
            this.CHANNELNAME.Width = 80;
            // 
            // CIGARETTECODE
            // 
            this.CIGARETTECODE.Caption = "卷烟代码";
            this.CIGARETTECODE.FieldName = "CIGARETTECODE";
            this.CIGARETTECODE.Name = "CIGARETTECODE";
            this.CIGARETTECODE.OptionsColumn.AllowFocus = false;
            this.CIGARETTECODE.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.CIGARETTECODE.Visible = true;
            this.CIGARETTECODE.VisibleIndex = 5;
            this.CIGARETTECODE.Width = 80;
            // 
            // CIGARETTENAME
            // 
            this.CIGARETTENAME.Caption = "卷烟名称";
            this.CIGARETTENAME.FieldName = "CIGARETTENAME";
            this.CIGARETTENAME.Name = "CIGARETTENAME";
            this.CIGARETTENAME.OptionsColumn.AllowFocus = false;
            this.CIGARETTENAME.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.CIGARETTENAME.Visible = true;
            this.CIGARETTENAME.VisibleIndex = 6;
            this.CIGARETTENAME.Width = 150;
            // 
            // QUANTITY
            // 
            this.QUANTITY.Caption = "卷烟数量";
            this.QUANTITY.FieldName = "QUANTITY";
            this.QUANTITY.Name = "QUANTITY";
            this.QUANTITY.OptionsColumn.AllowFocus = false;
            this.QUANTITY.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.QUANTITY.Visible = true;
            this.QUANTITY.VisibleIndex = 7;
            this.QUANTITY.Width = 80;
            // 
            // STATUS
            // 
            this.STATUS.Caption = "补货状态";
            this.STATUS.FieldName = "STATUS";
            this.STATUS.Name = "STATUS";
            this.STATUS.OptionsColumn.AllowFocus = false;
            this.STATUS.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.STATUS.Visible = true;
            this.STATUS.VisibleIndex = 8;
            this.STATUS.Width = 80;
            // 
            // HandleStockControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridHandleStock);
            this.Name = "HandleStockControl";
            this.Size = new System.Drawing.Size(725, 327);
            ((System.ComponentModel.ISupportInitialize)(this.gridHandleStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewHandleStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView viewHandleStock;
        private DevExpress.XtraGrid.Columns.GridColumn BATCHNO;
        private DevExpress.XtraGrid.Columns.GridColumn SUPPLYNO;
        private DevExpress.XtraGrid.Columns.GridColumn SORTNO;
        private DevExpress.XtraGrid.Columns.GridColumn SUPPLYBATCH;
        private DevExpress.XtraGrid.Columns.GridColumn CHANNELNAME;
        private DevExpress.XtraGrid.Columns.GridColumn CIGARETTECODE;
        private DevExpress.XtraGrid.Columns.GridColumn CIGARETTENAME;
        private DevExpress.XtraGrid.Columns.GridColumn QUANTITY;
        private DevExpress.XtraGrid.Columns.GridColumn STATUS;
        public DevExpress.XtraGrid.GridControl gridHandleStock;
    }
}
