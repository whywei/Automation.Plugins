namespace Automation.Plugins.Sorting.View.Controls
{
    partial class CacheOrderQueryControl
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
            this.gridCacheOrder = new DevExpress.XtraGrid.GridControl();
            this.viewCacheOrder = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SORTNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUSTOMERNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CIGARETTENAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QUANTITY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CHANNELLINE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CIGARETTECODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CHANNELNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CHANNELTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridCacheOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewCacheOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // gridCacheOrder
            // 
            this.gridCacheOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCacheOrder.Location = new System.Drawing.Point(0, 0);
            this.gridCacheOrder.MainView = this.viewCacheOrder;
            this.gridCacheOrder.Name = "gridCacheOrder";
            this.gridCacheOrder.Size = new System.Drawing.Size(694, 280);
            this.gridCacheOrder.TabIndex = 0;
            this.gridCacheOrder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewCacheOrder});
            // 
            // viewCacheOrder
            // 
            this.viewCacheOrder.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SORTNO,
            this.CUSTOMERNAME,
            this.CIGARETTENAME,
            this.QUANTITY,
            this.CHANNELLINE,
            this.CIGARETTECODE,
            this.CHANNELNAME,
            this.CHANNELTYPE});
            this.viewCacheOrder.GridControl = this.gridCacheOrder;
            this.viewCacheOrder.Name = "viewCacheOrder";
            this.viewCacheOrder.OptionsView.ColumnAutoWidth = false;
            this.viewCacheOrder.OptionsView.ShowGroupPanel = false;
            // 
            // SORTNO
            // 
            this.SORTNO.Caption = "流水号";
            this.SORTNO.FieldName = "SORTNO";
            this.SORTNO.Name = "SORTNO";
            this.SORTNO.OptionsColumn.AllowFocus = false;
            this.SORTNO.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.SORTNO.Visible = true;
            this.SORTNO.VisibleIndex = 0;
            this.SORTNO.Width = 70;
            // 
            // CUSTOMERNAME
            // 
            this.CUSTOMERNAME.Caption = "客户名称";
            this.CUSTOMERNAME.FieldName = "CUSTOMERNAME";
            this.CUSTOMERNAME.Name = "CUSTOMERNAME";
            this.CUSTOMERNAME.OptionsColumn.AllowFocus = false;
            this.CUSTOMERNAME.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.CUSTOMERNAME.Visible = true;
            this.CUSTOMERNAME.VisibleIndex = 1;
            this.CUSTOMERNAME.Width = 150;
            // 
            // CIGARETTENAME
            // 
            this.CIGARETTENAME.Caption = "卷烟名称";
            this.CIGARETTENAME.FieldName = "CIGARETTENAME";
            this.CIGARETTENAME.Name = "CIGARETTENAME";
            this.CIGARETTENAME.OptionsColumn.AllowFocus = false;
            this.CIGARETTENAME.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.CIGARETTENAME.Visible = true;
            this.CIGARETTENAME.VisibleIndex = 2;
            this.CIGARETTENAME.Width = 170;
            // 
            // QUANTITY
            // 
            this.QUANTITY.Caption = "数量";
            this.QUANTITY.FieldName = "QUANTITY";
            this.QUANTITY.Name = "QUANTITY";
            this.QUANTITY.OptionsColumn.AllowFocus = false;
            this.QUANTITY.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.QUANTITY.Visible = true;
            this.QUANTITY.VisibleIndex = 3;
            this.QUANTITY.Width = 70;
            // 
            // CHANNELLINE
            // 
            this.CHANNELLINE.Caption = "线组";
            this.CHANNELLINE.FieldName = "CHANNELLINE";
            this.CHANNELLINE.Name = "CHANNELLINE";
            this.CHANNELLINE.OptionsColumn.AllowFocus = false;
            this.CHANNELLINE.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.CHANNELLINE.Visible = true;
            this.CHANNELLINE.VisibleIndex = 4;
            this.CHANNELLINE.Width = 70;
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
            // CHANNELNAME
            // 
            this.CHANNELNAME.Caption = "烟道名称";
            this.CHANNELNAME.FieldName = "CHANNELNAME";
            this.CHANNELNAME.Name = "CHANNELNAME";
            this.CHANNELNAME.OptionsColumn.AllowFocus = false;
            this.CHANNELNAME.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.CHANNELNAME.Visible = true;
            this.CHANNELNAME.VisibleIndex = 6;
            this.CHANNELNAME.Width = 80;
            // 
            // CHANNELTYPE
            // 
            this.CHANNELTYPE.Caption = "烟道类型";
            this.CHANNELTYPE.FieldName = "CHANNELTYPE";
            this.CHANNELTYPE.Name = "CHANNELTYPE";
            this.CHANNELTYPE.OptionsColumn.AllowFocus = false;
            this.CHANNELTYPE.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.CHANNELTYPE.Visible = true;
            this.CHANNELTYPE.VisibleIndex = 7;
            this.CHANNELTYPE.Width = 80;
            // 
            // CacheOrderQueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridCacheOrder);
            this.Name = "CacheOrderQueryControl";
            this.Size = new System.Drawing.Size(694, 280);
            ((System.ComponentModel.ISupportInitialize)(this.gridCacheOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewCacheOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn SORTNO;
        private DevExpress.XtraGrid.Columns.GridColumn CUSTOMERNAME;
        private DevExpress.XtraGrid.Columns.GridColumn CIGARETTENAME;
        private DevExpress.XtraGrid.Columns.GridColumn QUANTITY;
        private DevExpress.XtraGrid.Columns.GridColumn CHANNELLINE;
        private DevExpress.XtraGrid.Columns.GridColumn CIGARETTECODE;
        private DevExpress.XtraGrid.Columns.GridColumn CHANNELNAME;
        private DevExpress.XtraGrid.Columns.GridColumn CHANNELTYPE;
        public DevExpress.XtraGrid.GridControl gridCacheOrder;
        public DevExpress.XtraGrid.Views.Grid.GridView viewCacheOrder;
    }
}
