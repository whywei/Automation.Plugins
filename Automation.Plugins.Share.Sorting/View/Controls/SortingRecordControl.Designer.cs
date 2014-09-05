namespace Automation.Plugins.Share.Sorting.View.Controls
{
    partial class SortingRecordControl
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
            this.gridSortingRecord = new DevExpress.XtraGrid.GridControl();
            this.viewSortingRecord = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sort_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pack_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.channel_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.group_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sort_address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.remain_quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.export_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.product_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.product_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridSortingRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewSortingRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridSortingRecord
            // 
            this.gridSortingRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSortingRecord.Location = new System.Drawing.Point(2, 2);
            this.gridSortingRecord.MainView = this.viewSortingRecord;
            this.gridSortingRecord.Name = "gridSortingRecord";
            this.gridSortingRecord.Size = new System.Drawing.Size(766, 326);
            this.gridSortingRecord.TabIndex = 0;
            this.gridSortingRecord.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewSortingRecord});
            // 
            // viewSortingRecord
            // 
            this.viewSortingRecord.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.sort_no,
            this.pack_no,
            this.quantity,
            this.channel_name,
            this.group_no,
            this.sort_address,
            this.remain_quantity,
            this.export_no,
            this.product_code,
            this.product_name,
            this.status});
            this.viewSortingRecord.GridControl = this.gridSortingRecord;
            this.viewSortingRecord.Name = "viewSortingRecord";
            this.viewSortingRecord.OptionsBehavior.ReadOnly = true;
            this.viewSortingRecord.OptionsView.ColumnAutoWidth = false;
            this.viewSortingRecord.OptionsView.ShowGroupPanel = false;
            // 
            // sort_no
            // 
            this.sort_no.Caption = "流水号";
            this.sort_no.FieldName = "sort_no";
            this.sort_no.Name = "sort_no";
            this.sort_no.OptionsColumn.AllowEdit = false;
            this.sort_no.OptionsColumn.AllowFocus = false;
            this.sort_no.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.sort_no.OptionsColumn.TabStop = false;
            this.sort_no.Visible = true;
            this.sort_no.VisibleIndex = 0;
            this.sort_no.Width = 60;
            // 
            // pack_no
            // 
            this.pack_no.Caption = "烟包包号";
            this.pack_no.FieldName = "pack_no";
            this.pack_no.Name = "pack_no";
            this.pack_no.OptionsColumn.AllowEdit = false;
            this.pack_no.OptionsColumn.AllowFocus = false;
            this.pack_no.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.pack_no.Visible = true;
            this.pack_no.VisibleIndex = 1;
            this.pack_no.Width = 60;
            // 
            // quantity
            // 
            this.quantity.Caption = "烟包数量";
            this.quantity.FieldName = "quantity";
            this.quantity.Name = "quantity";
            this.quantity.OptionsColumn.AllowEdit = false;
            this.quantity.OptionsColumn.AllowFocus = false;
            this.quantity.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.quantity.Visible = true;
            this.quantity.VisibleIndex = 2;
            this.quantity.Width = 60;
            // 
            // channel_name
            // 
            this.channel_name.Caption = "烟道名称";
            this.channel_name.FieldName = "channel_name";
            this.channel_name.Name = "channel_name";
            this.channel_name.OptionsColumn.AllowEdit = false;
            this.channel_name.OptionsColumn.AllowFocus = false;
            this.channel_name.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.channel_name.Visible = true;
            this.channel_name.VisibleIndex = 3;
            this.channel_name.Width = 80;
            // 
            // group_no
            // 
            this.group_no.Caption = "烟道组";
            this.group_no.FieldName = "group_no";
            this.group_no.Name = "group_no";
            this.group_no.OptionsColumn.AllowFocus = false;
            this.group_no.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.group_no.Visible = true;
            this.group_no.VisibleIndex = 4;
            // 
            // sort_address
            // 
            this.sort_address.Caption = "分拣地址";
            this.sort_address.FieldName = "sort_address";
            this.sort_address.Name = "sort_address";
            this.sort_address.OptionsColumn.AllowEdit = false;
            this.sort_address.OptionsColumn.AllowFocus = false;
            this.sort_address.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.sort_address.Visible = true;
            this.sort_address.VisibleIndex = 5;
            this.sort_address.Width = 80;
            // 
            // remain_quantity
            // 
            this.remain_quantity.Caption = "剩余数量";
            this.remain_quantity.FieldName = "remain_quantity";
            this.remain_quantity.Name = "remain_quantity";
            this.remain_quantity.OptionsColumn.AllowEdit = false;
            this.remain_quantity.OptionsColumn.AllowFocus = false;
            this.remain_quantity.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.remain_quantity.Visible = true;
            this.remain_quantity.VisibleIndex = 6;
            this.remain_quantity.Width = 60;
            // 
            // export_no
            // 
            this.export_no.Caption = "包装机号";
            this.export_no.FieldName = "export_no";
            this.export_no.Name = "export_no";
            this.export_no.OptionsColumn.AllowEdit = false;
            this.export_no.OptionsColumn.AllowFocus = false;
            this.export_no.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.export_no.Visible = true;
            this.export_no.VisibleIndex = 7;
            this.export_no.Width = 60;
            // 
            // product_code
            // 
            this.product_code.Caption = "商品代码";
            this.product_code.FieldName = "product_code";
            this.product_code.Name = "product_code";
            this.product_code.OptionsColumn.AllowEdit = false;
            this.product_code.OptionsColumn.AllowFocus = false;
            this.product_code.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.product_code.Visible = true;
            this.product_code.VisibleIndex = 8;
            this.product_code.Width = 80;
            // 
            // product_name
            // 
            this.product_name.Caption = "商品名称";
            this.product_name.FieldName = "product_name";
            this.product_name.Name = "product_name";
            this.product_name.OptionsColumn.AllowFocus = false;
            this.product_name.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.product_name.Visible = true;
            this.product_name.VisibleIndex = 9;
            this.product_name.Width = 130;
            // 
            // status
            // 
            this.status.Caption = "下单状态";
            this.status.FieldName = "status";
            this.status.Name = "status";
            this.status.OptionsColumn.AllowEdit = false;
            this.status.OptionsColumn.AllowFocus = false;
            this.status.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.status.Visible = true;
            this.status.VisibleIndex = 10;
            this.status.Width = 60;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridSortingRecord);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(770, 330);
            this.panelControl2.TabIndex = 3;
            // 
            // SortingRecordControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Name = "SortingRecordControl";
            this.Size = new System.Drawing.Size(770, 330);
            ((System.ComponentModel.ISupportInitialize)(this.gridSortingRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewSortingRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridSortingRecord;
        public DevExpress.XtraGrid.Views.Grid.GridView viewSortingRecord;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn sort_no;
        private DevExpress.XtraGrid.Columns.GridColumn pack_no;
        private DevExpress.XtraGrid.Columns.GridColumn quantity;
        private DevExpress.XtraGrid.Columns.GridColumn channel_name;
        private DevExpress.XtraGrid.Columns.GridColumn sort_address;
        private DevExpress.XtraGrid.Columns.GridColumn remain_quantity;
        private DevExpress.XtraGrid.Columns.GridColumn export_no;
        private DevExpress.XtraGrid.Columns.GridColumn product_code;
        private DevExpress.XtraGrid.Columns.GridColumn product_name;
        private DevExpress.XtraGrid.Columns.GridColumn status;
        private DevExpress.XtraGrid.Columns.GridColumn group_no;
    }
}
