namespace Automation.Plugins.MDJ.WCS.View.Controls
{
    partial class ScanManagerPanel
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Barcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ScanQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ZNState = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(651, 207);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ProductCode,
            this.ProductNo,
            this.ProductName,
            this.Barcode,
            this.Quantity,
            this.ScanQuantity,
            this.gcIndex,
            this.ZNState});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsLayout.Columns.AddNewColumns = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // ProductCode
            // 
            this.ProductCode.Caption = "卷烟代码";
            this.ProductCode.FieldName = "ProductCode";
            this.ProductCode.Name = "ProductCode";
            this.ProductCode.OptionsColumn.AllowEdit = false;
            this.ProductCode.OptionsColumn.AllowFocus = false;
            this.ProductCode.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ProductCode.Visible = true;
            this.ProductCode.VisibleIndex = 0;
            this.ProductCode.Width = 85;
            // 
            // ProductNo
            // 
            this.ProductNo.Caption = "卷烟简码";
            this.ProductNo.FieldName = "ProductNo";
            this.ProductNo.Name = "ProductNo";
            this.ProductNo.OptionsColumn.AllowEdit = false;
            this.ProductNo.OptionsColumn.AllowFocus = false;
            this.ProductNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ProductNo.Visible = true;
            this.ProductNo.VisibleIndex = 1;
            this.ProductNo.Width = 101;
            // 
            // ProductName
            // 
            this.ProductName.Caption = "卷烟名称";
            this.ProductName.FieldName = "ProductName";
            this.ProductName.Name = "ProductName";
            this.ProductName.OptionsColumn.AllowEdit = false;
            this.ProductName.OptionsColumn.AllowFocus = false;
            this.ProductName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ProductName.Visible = true;
            this.ProductName.VisibleIndex = 2;
            this.ProductName.Width = 111;
            // 
            // Barcode
            // 
            this.Barcode.Caption = "条码";
            this.Barcode.FieldName = "Barcode";
            this.Barcode.Name = "Barcode";
            this.Barcode.OptionsColumn.AllowEdit = false;
            this.Barcode.OptionsColumn.AllowFocus = false;
            this.Barcode.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.Barcode.Visible = true;
            this.Barcode.VisibleIndex = 3;
            this.Barcode.Width = 124;
            // 
            // Quantity
            // 
            this.Quantity.Caption = "数量";
            this.Quantity.FieldName = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.OptionsColumn.AllowEdit = false;
            this.Quantity.OptionsColumn.AllowFocus = false;
            this.Quantity.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.Quantity.Visible = true;
            this.Quantity.VisibleIndex = 4;
            this.Quantity.Width = 100;
            // 
            // ScanQuantity
            // 
            this.ScanQuantity.Caption = "已扫码";
            this.ScanQuantity.FieldName = "ScanQuantity";
            this.ScanQuantity.Name = "ScanQuantity";
            this.ScanQuantity.OptionsColumn.AllowEdit = false;
            this.ScanQuantity.OptionsColumn.AllowFocus = false;
            this.ScanQuantity.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ScanQuantity.Visible = true;
            this.ScanQuantity.VisibleIndex = 5;
            this.ScanQuantity.Width = 83;
            // 
            // gcIndex
            // 
            this.gcIndex.Caption = "扫码顺序";
            this.gcIndex.FieldName = "Index";
            this.gcIndex.Name = "gcIndex";
            this.gcIndex.OptionsColumn.AllowEdit = false;
            this.gcIndex.OptionsColumn.AllowFocus = false;
            this.gcIndex.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcIndex.Visible = true;
            this.gcIndex.VisibleIndex = 6;
            // 
            // ZNState
            // 
            this.ZNState.Caption = "状态";
            this.ZNState.FieldName = "ZNState";
            this.ZNState.Name = "ZNState";
            this.ZNState.OptionsColumn.AllowEdit = false;
            this.ZNState.OptionsColumn.AllowFocus = false;
            this.ZNState.OptionsColumn.AllowMove = false;
            this.ZNState.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ZNState.Visible = true;
            this.ZNState.VisibleIndex = 7;
            this.ZNState.Width = 92;
            // 
            // ScanManagerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "ScanManagerPanel";
            this.Size = new System.Drawing.Size(651, 207);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridControl1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn ProductNo;
        private DevExpress.XtraGrid.Columns.GridColumn ProductName;
        private DevExpress.XtraGrid.Columns.GridColumn Barcode;
        private DevExpress.XtraGrid.Columns.GridColumn Quantity;
        private DevExpress.XtraGrid.Columns.GridColumn ScanQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn ZNState;
        private DevExpress.XtraGrid.Columns.GridColumn gcIndex;
    }
}
