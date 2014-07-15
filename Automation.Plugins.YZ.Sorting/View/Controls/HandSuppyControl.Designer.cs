namespace Automation.Plugins.YZ.Sorting.View.Controls
{
    partial class HandSuppyControl
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
            this.supply_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.supply_batch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pack_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.channel_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.product_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.product_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.status = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridControl1.Size = new System.Drawing.Size(860, 450);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.supply_id,
            this.supply_batch,
            this.pack_no,
            this.channel_code,
            this.product_code,
            this.product_name,
            this.quantity,
            this.status});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // supply_id
            // 
            this.supply_id.Caption = "补货编号";
            this.supply_id.FieldName = "supply_id";
            this.supply_id.Name = "supply_id";
            this.supply_id.OptionsColumn.AllowEdit = false;
            this.supply_id.OptionsColumn.AllowFocus = false;
            this.supply_id.Visible = true;
            this.supply_id.VisibleIndex = 0;
            // 
            // supply_batch
            // 
            this.supply_batch.Caption = "批次";
            this.supply_batch.FieldName = "supply_batch";
            this.supply_batch.Name = "supply_batch";
            this.supply_batch.OptionsColumn.AllowEdit = false;
            this.supply_batch.OptionsColumn.AllowFocus = false;
            this.supply_batch.Visible = true;
            this.supply_batch.VisibleIndex = 1;
            // 
            // pack_no
            // 
            this.pack_no.Caption = "包号";
            this.pack_no.FieldName = "pack_no";
            this.pack_no.Name = "pack_no";
            this.pack_no.OptionsColumn.AllowEdit = false;
            this.pack_no.OptionsColumn.AllowFocus = false;
            this.pack_no.Visible = true;
            this.pack_no.VisibleIndex = 2;
            // 
            // channel_code
            // 
            this.channel_code.Caption = "烟道编号";
            this.channel_code.FieldName = "channel_code";
            this.channel_code.Name = "channel_code";
            this.channel_code.OptionsColumn.AllowEdit = false;
            this.channel_code.OptionsColumn.AllowFocus = false;
            this.channel_code.Visible = true;
            this.channel_code.VisibleIndex = 3;
            // 
            // product_code
            // 
            this.product_code.Caption = "卷烟编号";
            this.product_code.FieldName = "product_code";
            this.product_code.Name = "product_code";
            this.product_code.OptionsColumn.AllowEdit = false;
            this.product_code.OptionsColumn.AllowFocus = false;
            this.product_code.Visible = true;
            this.product_code.VisibleIndex = 4;
            // 
            // product_name
            // 
            this.product_name.Caption = "卷烟名称";
            this.product_name.FieldName = "product_name";
            this.product_name.Name = "product_name";
            this.product_name.OptionsColumn.AllowEdit = false;
            this.product_name.OptionsColumn.AllowFocus = false;
            this.product_name.Visible = true;
            this.product_name.VisibleIndex = 5;
            // 
            // quantity
            // 
            this.quantity.Caption = "数量";
            this.quantity.FieldName = "quantity";
            this.quantity.Name = "quantity";
            this.quantity.OptionsColumn.AllowEdit = false;
            this.quantity.OptionsColumn.AllowFocus = false;
            this.quantity.Visible = true;
            this.quantity.VisibleIndex = 6;
            // 
            // status
            // 
            this.status.Caption = "状态";
            this.status.FieldName = "status";
            this.status.Name = "status";
            this.status.OptionsColumn.AllowEdit = false;
            this.status.OptionsColumn.AllowFocus = false;
            this.status.Visible = true;
            this.status.VisibleIndex = 7;
            // 
            // HandSuppyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "HandSuppyControl";
            this.Size = new System.Drawing.Size(860, 450);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn supply_id;
        private DevExpress.XtraGrid.Columns.GridColumn supply_batch;
        private DevExpress.XtraGrid.Columns.GridColumn pack_no;
        private DevExpress.XtraGrid.Columns.GridColumn channel_code;
        private DevExpress.XtraGrid.Columns.GridColumn product_code;
        private DevExpress.XtraGrid.Columns.GridColumn product_name;
        private DevExpress.XtraGrid.Columns.GridColumn quantity;
        private DevExpress.XtraGrid.Columns.GridColumn status;
        public DevExpress.XtraGrid.GridControl gridControl1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}
