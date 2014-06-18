namespace Automation.Plugins.YZ.Sorting.View.Controls
{
    partial class LedQueryControl
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.led_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.led_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.led_type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.led_ip = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xaxes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.yaxes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.width = new DevExpress.XtraGrid.Columns.GridColumn();
            this.height = new DevExpress.XtraGrid.Columns.GridColumn();
            this.led_group_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.order_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(863, 450);
            this.splitContainerControl1.SplitterPosition = 193;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(863, 193);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.led_code,
            this.led_name,
            this.led_type,
            this.led_ip,
            this.xaxes,
            this.yaxes,
            this.width,
            this.height,
            this.led_group_code,
            this.order_no,
            this.status});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // led_code
            // 
            this.led_code.Caption = "编号";
            this.led_code.FieldName = "led_code";
            this.led_code.Name = "led_code";
            this.led_code.OptionsColumn.AllowEdit = false;
            this.led_code.OptionsColumn.AllowFocus = false;
            this.led_code.Visible = true;
            this.led_code.VisibleIndex = 0;
            // 
            // led_name
            // 
            this.led_name.Caption = "名称";
            this.led_name.FieldName = "led_name";
            this.led_name.Name = "led_name";
            this.led_name.OptionsColumn.AllowEdit = false;
            this.led_name.OptionsColumn.AllowFocus = false;
            this.led_name.Visible = true;
            this.led_name.VisibleIndex = 1;
            // 
            // led_type
            // 
            this.led_type.Caption = "类型";
            this.led_type.FieldName = "led_type";
            this.led_type.Name = "led_type";
            this.led_type.OptionsColumn.AllowEdit = false;
            this.led_type.OptionsColumn.AllowFocus = false;
            this.led_type.Visible = true;
            this.led_type.VisibleIndex = 2;
            // 
            // led_ip
            // 
            this.led_ip.Caption = "IP地址";
            this.led_ip.FieldName = "led_ip";
            this.led_ip.Name = "led_ip";
            this.led_ip.OptionsColumn.AllowEdit = false;
            this.led_ip.OptionsColumn.AllowFocus = false;
            this.led_ip.Visible = true;
            this.led_ip.VisibleIndex = 9;
            // 
            // xaxes
            // 
            this.xaxes.Caption = "X坐标";
            this.xaxes.FieldName = "xaxes";
            this.xaxes.Name = "xaxes";
            this.xaxes.OptionsColumn.AllowEdit = false;
            this.xaxes.OptionsColumn.AllowFocus = false;
            this.xaxes.Visible = true;
            this.xaxes.VisibleIndex = 3;
            // 
            // yaxes
            // 
            this.yaxes.Caption = "Y坐标";
            this.yaxes.FieldName = "yaxes";
            this.yaxes.Name = "yaxes";
            this.yaxes.OptionsColumn.AllowEdit = false;
            this.yaxes.OptionsColumn.AllowFocus = false;
            this.yaxes.Visible = true;
            this.yaxes.VisibleIndex = 4;
            // 
            // width
            // 
            this.width.Caption = "宽";
            this.width.FieldName = "width";
            this.width.Name = "width";
            this.width.OptionsColumn.AllowEdit = false;
            this.width.OptionsColumn.AllowFocus = false;
            this.width.Visible = true;
            this.width.VisibleIndex = 5;
            // 
            // height
            // 
            this.height.Caption = "高";
            this.height.FieldName = "height";
            this.height.Name = "height";
            this.height.OptionsColumn.AllowEdit = false;
            this.height.OptionsColumn.AllowFocus = false;
            this.height.Visible = true;
            this.height.VisibleIndex = 6;
            // 
            // led_group_code
            // 
            this.led_group_code.Caption = "父级Led屏编号";
            this.led_group_code.FieldName = "led_group_code";
            this.led_group_code.Name = "led_group_code";
            this.led_group_code.OptionsColumn.AllowEdit = false;
            // 
            // order_no
            // 
            this.order_no.Caption = "顺序号";
            this.order_no.FieldName = "order_no";
            this.order_no.Name = "order_no";
            this.order_no.OptionsColumn.AllowEdit = false;
            this.order_no.OptionsColumn.AllowFocus = false;
            this.order_no.Visible = true;
            this.order_no.VisibleIndex = 7;
            // 
            // status
            // 
            this.status.Caption = "状态";
            this.status.FieldName = "status";
            this.status.Name = "status";
            this.status.OptionsColumn.AllowEdit = false;
            this.status.OptionsColumn.AllowFocus = false;
            this.status.Visible = true;
            this.status.VisibleIndex = 8;
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(863, 252);
            this.gridControl2.TabIndex = 2;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "编号";
            this.gridColumn1.FieldName = "led_code";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "名称";
            this.gridColumn2.FieldName = "led_name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "类型";
            this.gridColumn3.FieldName = "led_type";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "IP地址";
            this.gridColumn4.FieldName = "led_ip";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "X坐标";
            this.gridColumn5.FieldName = "xaxes";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Y坐标";
            this.gridColumn6.FieldName = "yaxes";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "宽";
            this.gridColumn7.FieldName = "width";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "高";
            this.gridColumn8.FieldName = "height";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "父级Led屏编号";
            this.gridColumn9.FieldName = "led_group_code";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "顺序号";
            this.gridColumn10.FieldName = "order_no";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "状态";
            this.gridColumn11.FieldName = "status";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 9;
            // 
            // LedQueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "LedQueryControl";
            this.Size = new System.Drawing.Size(863, 450);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        public DevExpress.XtraGrid.GridControl gridControl1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn led_code;
        private DevExpress.XtraGrid.Columns.GridColumn led_name;
        private DevExpress.XtraGrid.Columns.GridColumn led_type;
        private DevExpress.XtraGrid.Columns.GridColumn led_ip;
        private DevExpress.XtraGrid.Columns.GridColumn xaxes;
        private DevExpress.XtraGrid.Columns.GridColumn yaxes;
        private DevExpress.XtraGrid.Columns.GridColumn width;
        private DevExpress.XtraGrid.Columns.GridColumn height;
        private DevExpress.XtraGrid.Columns.GridColumn led_group_code;
        private DevExpress.XtraGrid.Columns.GridColumn order_no;
        private DevExpress.XtraGrid.Columns.GridColumn status;
        public DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
    }
}
