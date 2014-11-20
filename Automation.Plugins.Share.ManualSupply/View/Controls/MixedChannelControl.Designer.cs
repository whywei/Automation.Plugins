namespace Automation.Plugins.Share.ManualSupply.View.Controls
{
    partial class MixedChannelControl
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.supply_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.supply_batch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pack_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.deliver_line_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.customer_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.channel_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.product_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.product_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xStatus = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridControl1.Size = new System.Drawing.Size(860, 416);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.supply_id,
            this.supply_batch,
            this.pack_no,
            this.deliver_line_name,
            this.customer_name,
            this.channel_name,
            this.product_code,
            this.product_name,
            this.quantity,
            this.status,
            this.xStatus});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // supply_id
            // 
            this.supply_id.AppearanceCell.Options.UseTextOptions = true;
            this.supply_id.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.supply_id.Caption = "补货编码";
            this.supply_id.FieldName = "supply_id";
            this.supply_id.Name = "supply_id";
            this.supply_id.OptionsColumn.AllowEdit = false;
            this.supply_id.OptionsColumn.AllowFocus = false;
            this.supply_id.Visible = true;
            this.supply_id.VisibleIndex = 0;
            this.supply_id.Width = 56;
            // 
            // supply_batch
            // 
            this.supply_batch.AppearanceCell.Options.UseTextOptions = true;
            this.supply_batch.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.supply_batch.Caption = "补货批次号";
            this.supply_batch.FieldName = "supply_batch";
            this.supply_batch.Name = "supply_batch";
            this.supply_batch.OptionsColumn.AllowEdit = false;
            this.supply_batch.OptionsColumn.AllowFocus = false;
            this.supply_batch.Visible = true;
            this.supply_batch.VisibleIndex = 1;
            this.supply_batch.Width = 55;
            // 
            // pack_no
            // 
            this.pack_no.AppearanceCell.Options.UseTextOptions = true;
            this.pack_no.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.pack_no.Caption = "烟包包号";
            this.pack_no.FieldName = "pack_no";
            this.pack_no.Name = "pack_no";
            this.pack_no.OptionsColumn.AllowEdit = false;
            this.pack_no.OptionsColumn.AllowFocus = false;
            this.pack_no.Visible = true;
            this.pack_no.VisibleIndex = 2;
            this.pack_no.Width = 50;
            // 
            // deliver_line_name
            // 
            this.deliver_line_name.AppearanceCell.Options.UseTextOptions = true;
            this.deliver_line_name.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.deliver_line_name.Caption = "线路";
            this.deliver_line_name.FieldName = "deliver_line_name";
            this.deliver_line_name.Name = "deliver_line_name";
            this.deliver_line_name.OptionsColumn.AllowEdit = false;
            this.deliver_line_name.OptionsColumn.AllowFocus = false;
            this.deliver_line_name.Visible = true;
            this.deliver_line_name.VisibleIndex = 3;
            this.deliver_line_name.Width = 96;
            // 
            // customer_name
            // 
            this.customer_name.AppearanceCell.Options.UseTextOptions = true;
            this.customer_name.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.customer_name.Caption = "客户";
            this.customer_name.FieldName = "customer_name";
            this.customer_name.Name = "customer_name";
            this.customer_name.OptionsColumn.AllowEdit = false;
            this.customer_name.OptionsColumn.AllowFocus = false;
            this.customer_name.Visible = true;
            this.customer_name.VisibleIndex = 4;
            this.customer_name.Width = 96;
            // 
            // channel_name
            // 
            this.channel_name.AppearanceCell.Options.UseTextOptions = true;
            this.channel_name.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.channel_name.Caption = "烟道名称";
            this.channel_name.FieldName = "channel_name";
            this.channel_name.Name = "channel_name";
            this.channel_name.OptionsColumn.AllowEdit = false;
            this.channel_name.OptionsColumn.AllowFocus = false;
            this.channel_name.Visible = true;
            this.channel_name.VisibleIndex = 5;
            this.channel_name.Width = 60;
            // 
            // product_code
            // 
            this.product_code.AppearanceCell.Options.UseTextOptions = true;
            this.product_code.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.product_code.Caption = "卷烟编码";
            this.product_code.FieldName = "product_code";
            this.product_code.Name = "product_code";
            this.product_code.OptionsColumn.AllowEdit = false;
            this.product_code.OptionsColumn.AllowFocus = false;
            this.product_code.Visible = true;
            this.product_code.VisibleIndex = 6;
            this.product_code.Width = 63;
            // 
            // product_name
            // 
            this.product_name.AppearanceCell.Options.UseTextOptions = true;
            this.product_name.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.product_name.Caption = "卷烟名称";
            this.product_name.FieldName = "product_name";
            this.product_name.Name = "product_name";
            this.product_name.OptionsColumn.AllowEdit = false;
            this.product_name.OptionsColumn.AllowFocus = false;
            this.product_name.Visible = true;
            this.product_name.VisibleIndex = 7;
            this.product_name.Width = 113;
            // 
            // quantity
            // 
            this.quantity.AppearanceCell.Options.UseTextOptions = true;
            this.quantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.quantity.Caption = "数量";
            this.quantity.FieldName = "quantity";
            this.quantity.Name = "quantity";
            this.quantity.OptionsColumn.AllowEdit = false;
            this.quantity.OptionsColumn.AllowFocus = false;
            this.quantity.Visible = true;
            this.quantity.VisibleIndex = 8;
            this.quantity.Width = 54;
            // 
            // status
            // 
            this.status.AppearanceCell.Options.UseTextOptions = true;
            this.status.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.status.Caption = "补货状态";
            this.status.FieldName = "status";
            this.status.Name = "status";
            this.status.OptionsColumn.AllowEdit = false;
            this.status.OptionsColumn.AllowFocus = false;
            this.status.Visible = true;
            this.status.VisibleIndex = 9;
            this.status.Width = 89;
            // 
            // xStatus
            // 
            this.xStatus.AppearanceCell.Options.UseTextOptions = true;
            this.xStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xStatus.Caption = "下单状态";
            this.xStatus.FieldName = "xStatus";
            this.xStatus.Name = "xStatus";
            this.xStatus.OptionsColumn.AllowEdit = false;
            this.xStatus.OptionsColumn.AllowFocus = false;
            this.xStatus.Visible = true;
            this.xStatus.VisibleIndex = 10;
            this.xStatus.Width = 110;
            // 
            // MixedChannelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "MixedChannelControl";
            this.Size = new System.Drawing.Size(860, 416);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridControl1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn supply_id;
        private DevExpress.XtraGrid.Columns.GridColumn supply_batch;
        private DevExpress.XtraGrid.Columns.GridColumn pack_no;
        private DevExpress.XtraGrid.Columns.GridColumn deliver_line_name;
        private DevExpress.XtraGrid.Columns.GridColumn customer_name;
        private DevExpress.XtraGrid.Columns.GridColumn channel_name;
        private DevExpress.XtraGrid.Columns.GridColumn product_code;
        private DevExpress.XtraGrid.Columns.GridColumn product_name;
        private DevExpress.XtraGrid.Columns.GridColumn quantity;
        private DevExpress.XtraGrid.Columns.GridColumn status;
        private DevExpress.XtraGrid.Columns.GridColumn xStatus;

    }
}
