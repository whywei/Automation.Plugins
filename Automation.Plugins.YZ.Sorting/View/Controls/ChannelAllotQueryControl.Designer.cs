namespace Automation.Plugins.YZ.Sorting.View.Controls
{
    partial class ChannelAllotQueryControl
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
            this.channel_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.channel_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.product_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.product_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.real_quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.channel_type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.led_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.remain_quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.middle_quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.max_quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cell_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.order_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.group_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.out_quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.in_quantity = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridControl1.Size = new System.Drawing.Size(863, 450);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.channel_code,
            this.channel_name,
            this.product_code,
            this.product_name,
            this.real_quantity,
            this.channel_type,
            this.led_code,
            this.remain_quantity,
            this.middle_quantity,
            this.max_quantity,
            this.status,
            this.cell_code,
            this.address,
            this.order_no,
            this.group_no,
            this.out_quantity,
            this.in_quantity});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // channel_code
            // 
            this.channel_code.Caption = "烟道代码";
            this.channel_code.FieldName = "channel_code";
            this.channel_code.Name = "channel_code";
            this.channel_code.OptionsColumn.AllowEdit = false;
            this.channel_code.OptionsColumn.AllowFocus = false;
            this.channel_code.Visible = true;
            this.channel_code.VisibleIndex = 0;
            // 
            // channel_name
            // 
            this.channel_name.Caption = "烟道名称";
            this.channel_name.FieldName = "channel_name";
            this.channel_name.Name = "channel_name";
            this.channel_name.OptionsColumn.AllowEdit = false;
            this.channel_name.OptionsColumn.AllowFocus = false;
            this.channel_name.Visible = true;
            this.channel_name.VisibleIndex = 1;
            // 
            // product_code
            // 
            this.product_code.Caption = "商品代码";
            this.product_code.FieldName = "product_code";
            this.product_code.Name = "product_code";
            this.product_code.OptionsColumn.AllowEdit = false;
            this.product_code.OptionsColumn.AllowFocus = false;
            // 
            // product_name
            // 
            this.product_name.Caption = "商品名称";
            this.product_name.FieldName = "product_name";
            this.product_name.Name = "product_name";
            this.product_name.OptionsColumn.AllowEdit = false;
            this.product_name.OptionsColumn.AllowFocus = false;
            this.product_name.Visible = true;
            this.product_name.VisibleIndex = 8;
            // 
            // real_quantity
            // 
            this.real_quantity.Caption = "实际数量";
            this.real_quantity.FieldName = "real_quantity";
            this.real_quantity.Name = "real_quantity";
            this.real_quantity.OptionsColumn.AllowEdit = false;
            this.real_quantity.OptionsColumn.AllowFocus = false;
            this.real_quantity.Visible = true;
            this.real_quantity.VisibleIndex = 2;
            // 
            // channel_type
            // 
            this.channel_type.Caption = "烟道类型";
            this.channel_type.FieldName = "channel_type";
            this.channel_type.Name = "channel_type";
            this.channel_type.OptionsColumn.AllowEdit = false;
            this.channel_type.OptionsColumn.AllowFocus = false;
            this.channel_type.Visible = true;
            this.channel_type.VisibleIndex = 3;
            // 
            // led_code
            // 
            this.led_code.Caption = "Led屏编号";
            this.led_code.FieldName = "led_code";
            this.led_code.Name = "led_code";
            this.led_code.OptionsColumn.AllowEdit = false;
            this.led_code.OptionsColumn.AllowFocus = false;
            this.led_code.Visible = true;
            this.led_code.VisibleIndex = 4;
            // 
            // remain_quantity
            // 
            this.remain_quantity.Caption = "提前量";
            this.remain_quantity.FieldName = "remain_quantity";
            this.remain_quantity.Name = "remain_quantity";
            this.remain_quantity.OptionsColumn.AllowEdit = false;
            this.remain_quantity.OptionsColumn.AllowFocus = false;
            this.remain_quantity.Visible = true;
            this.remain_quantity.VisibleIndex = 5;
            // 
            // middle_quantity
            // 
            this.middle_quantity.Caption = "补货中间量";
            this.middle_quantity.FieldName = "middle_quantity";
            this.middle_quantity.Name = "middle_quantity";
            this.middle_quantity.OptionsColumn.AllowEdit = false;
            this.middle_quantity.OptionsColumn.AllowFocus = false;
            this.middle_quantity.Visible = true;
            this.middle_quantity.VisibleIndex = 15;
            // 
            // max_quantity
            // 
            this.max_quantity.Caption = "最大缓存量";
            this.max_quantity.FieldName = "max_quantity";
            this.max_quantity.Name = "max_quantity";
            this.max_quantity.OptionsColumn.AllowEdit = false;
            this.max_quantity.OptionsColumn.AllowFocus = false;
            this.max_quantity.Visible = true;
            this.max_quantity.VisibleIndex = 6;
            // 
            // status
            // 
            this.status.Caption = "状态";
            this.status.FieldName = "status";
            this.status.Name = "status";
            this.status.OptionsColumn.AllowEdit = false;
            this.status.OptionsColumn.AllowFocus = false;
            this.status.Visible = true;
            this.status.VisibleIndex = 9;
            // 
            // cell_code
            // 
            this.cell_code.Caption = "货位编码";
            this.cell_code.FieldName = "cell_code";
            this.cell_code.Name = "cell_code";
            this.cell_code.OptionsColumn.AllowEdit = false;
            this.cell_code.OptionsColumn.AllowFocus = false;
            this.cell_code.Visible = true;
            this.cell_code.VisibleIndex = 10;
            // 
            // address
            // 
            this.address.Caption = "物理地址";
            this.address.FieldName = "address";
            this.address.Name = "address";
            this.address.OptionsColumn.AllowEdit = false;
            this.address.OptionsColumn.AllowFocus = false;
            this.address.Visible = true;
            this.address.VisibleIndex = 11;
            // 
            // order_no
            // 
            this.order_no.Caption = "顺序号";
            this.order_no.FieldName = "order_no";
            this.order_no.Name = "order_no";
            this.order_no.OptionsColumn.AllowEdit = false;
            this.order_no.OptionsColumn.AllowFocus = false;
            this.order_no.Visible = true;
            this.order_no.VisibleIndex = 12;
            // 
            // group_no
            // 
            this.group_no.Caption = "组号";
            this.group_no.FieldName = "group_no";
            this.group_no.Name = "group_no";
            this.group_no.OptionsColumn.AllowEdit = false;
            this.group_no.OptionsColumn.AllowFocus = false;
            this.group_no.Visible = true;
            this.group_no.VisibleIndex = 13;
            // 
            // out_quantity
            // 
            this.out_quantity.Caption = "出库数量";
            this.out_quantity.FieldName = "out_quantity";
            this.out_quantity.Name = "out_quantity";
            this.out_quantity.OptionsColumn.AllowEdit = false;
            this.out_quantity.OptionsColumn.AllowFocus = false;
            this.out_quantity.Visible = true;
            this.out_quantity.VisibleIndex = 14;
            // 
            // in_quantity
            // 
            this.in_quantity.Caption = "入库数量";
            this.in_quantity.FieldName = "in_quantity";
            this.in_quantity.Name = "in_quantity";
            this.in_quantity.OptionsColumn.AllowEdit = false;
            this.in_quantity.OptionsColumn.AllowFocus = false;
            this.in_quantity.Visible = true;
            this.in_quantity.VisibleIndex = 7;
            // 
            // ChannelAllotQueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "ChannelAllotQueryControl";
            this.Size = new System.Drawing.Size(863, 450);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridControl1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn channel_code;
        private DevExpress.XtraGrid.Columns.GridColumn channel_name;
        private DevExpress.XtraGrid.Columns.GridColumn product_code;
        private DevExpress.XtraGrid.Columns.GridColumn product_name;
        private DevExpress.XtraGrid.Columns.GridColumn real_quantity;
        private DevExpress.XtraGrid.Columns.GridColumn channel_type;
        private DevExpress.XtraGrid.Columns.GridColumn led_code;
        private DevExpress.XtraGrid.Columns.GridColumn remain_quantity;
        private DevExpress.XtraGrid.Columns.GridColumn middle_quantity;
        private DevExpress.XtraGrid.Columns.GridColumn max_quantity;
        private DevExpress.XtraGrid.Columns.GridColumn in_quantity;
        private DevExpress.XtraGrid.Columns.GridColumn status;
        private DevExpress.XtraGrid.Columns.GridColumn cell_code;
        private DevExpress.XtraGrid.Columns.GridColumn address;
        private DevExpress.XtraGrid.Columns.GridColumn order_no;
        private DevExpress.XtraGrid.Columns.GridColumn group_no;
        private DevExpress.XtraGrid.Columns.GridColumn out_quantity;

    }
}
