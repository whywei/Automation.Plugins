namespace Automation.Plugins.Stocking.View.Controls
{
    partial class SortChannelQueryControl
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
            this.gridSortChannel = new DevExpress.XtraGrid.GridControl();
            this.viewSortChannel = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.LINECODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CHANNELGROUP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CHANNELCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CHANNELNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CHANNELTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CIGARETTECODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CIGARETTENAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.STATUS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QUANTITY = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridSortChannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewSortChannel)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSortChannel
            // 
            this.gridSortChannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSortChannel.Location = new System.Drawing.Point(0, 0);
            this.gridSortChannel.MainView = this.viewSortChannel;
            this.gridSortChannel.Name = "gridSortChannel";
            this.gridSortChannel.Size = new System.Drawing.Size(733, 295);
            this.gridSortChannel.TabIndex = 0;
            this.gridSortChannel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewSortChannel});
            // 
            // viewSortChannel
            // 
            this.viewSortChannel.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.LINECODE,
            this.CHANNELGROUP,
            this.CHANNELCODE,
            this.CHANNELNAME,
            this.CHANNELTYPE,
            this.CIGARETTECODE,
            this.CIGARETTENAME,
            this.STATUS,
            this.QUANTITY});
            this.viewSortChannel.GridControl = this.gridSortChannel;
            this.viewSortChannel.Name = "viewSortChannel";
            this.viewSortChannel.OptionsView.ColumnAutoWidth = false;
            this.viewSortChannel.OptionsView.ShowGroupPanel = false;
            // 
            // LINECODE
            // 
            this.LINECODE.Caption = "生产线";
            this.LINECODE.FieldName = "LINECODE";
            this.LINECODE.Name = "LINECODE";
            this.LINECODE.OptionsColumn.AllowFocus = false;
            this.LINECODE.Visible = true;
            this.LINECODE.VisibleIndex = 0;
            this.LINECODE.Width = 80;
            // 
            // CHANNELGROUP
            // 
            this.CHANNELGROUP.Caption = "烟道组";
            this.CHANNELGROUP.FieldName = "CHANNELGROUP";
            this.CHANNELGROUP.Name = "CHANNELGROUP";
            this.CHANNELGROUP.OptionsColumn.AllowFocus = false;
            this.CHANNELGROUP.Visible = true;
            this.CHANNELGROUP.VisibleIndex = 1;
            this.CHANNELGROUP.Width = 80;
            // 
            // CHANNELCODE
            // 
            this.CHANNELCODE.Caption = "烟道代码";
            this.CHANNELCODE.FieldName = "CHANNELCODE";
            this.CHANNELCODE.Name = "CHANNELCODE";
            this.CHANNELCODE.OptionsColumn.AllowFocus = false;
            this.CHANNELCODE.Visible = true;
            this.CHANNELCODE.VisibleIndex = 2;
            this.CHANNELCODE.Width = 80;
            // 
            // CHANNELNAME
            // 
            this.CHANNELNAME.Caption = "烟道名称";
            this.CHANNELNAME.FieldName = "CHANNELNAME";
            this.CHANNELNAME.Name = "CHANNELNAME";
            this.CHANNELNAME.OptionsColumn.AllowFocus = false;
            this.CHANNELNAME.Visible = true;
            this.CHANNELNAME.VisibleIndex = 3;
            this.CHANNELNAME.Width = 80;
            // 
            // CHANNELTYPE
            // 
            this.CHANNELTYPE.Caption = "烟道类别";
            this.CHANNELTYPE.FieldName = "CHANNELTYPE";
            this.CHANNELTYPE.Name = "CHANNELTYPE";
            this.CHANNELTYPE.OptionsColumn.AllowFocus = false;
            this.CHANNELTYPE.Visible = true;
            this.CHANNELTYPE.VisibleIndex = 4;
            this.CHANNELTYPE.Width = 100;
            // 
            // CIGARETTECODE
            // 
            this.CIGARETTECODE.Caption = "卷烟代码";
            this.CIGARETTECODE.FieldName = "CIGARETTECODE";
            this.CIGARETTECODE.Name = "CIGARETTECODE";
            this.CIGARETTECODE.OptionsColumn.AllowFocus = false;
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
            this.CIGARETTENAME.Visible = true;
            this.CIGARETTENAME.VisibleIndex = 6;
            this.CIGARETTENAME.Width = 160;
            // 
            // STATUS
            // 
            this.STATUS.Caption = "状态";
            this.STATUS.FieldName = "STATUS";
            this.STATUS.Name = "STATUS";
            this.STATUS.OptionsColumn.AllowFocus = false;
            this.STATUS.Visible = true;
            this.STATUS.VisibleIndex = 7;
            this.STATUS.Width = 80;
            // 
            // QUANTITY
            // 
            this.QUANTITY.Caption = "数量";
            this.QUANTITY.FieldName = "QUANTITY";
            this.QUANTITY.Name = "QUANTITY";
            this.QUANTITY.OptionsColumn.AllowFocus = false;
            this.QUANTITY.Visible = true;
            this.QUANTITY.VisibleIndex = 8;
            this.QUANTITY.Width = 80;
            // 
            // SortChannelQueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridSortChannel);
            this.Name = "SortChannelQueryControl";
            this.Size = new System.Drawing.Size(733, 295);
            ((System.ComponentModel.ISupportInitialize)(this.gridSortChannel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewSortChannel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn LINECODE;
        private DevExpress.XtraGrid.Columns.GridColumn CHANNELCODE;
        private DevExpress.XtraGrid.Columns.GridColumn CHANNELNAME;
        private DevExpress.XtraGrid.Columns.GridColumn CHANNELTYPE;
        private DevExpress.XtraGrid.Columns.GridColumn CIGARETTECODE;
        private DevExpress.XtraGrid.Columns.GridColumn CIGARETTENAME;
        private DevExpress.XtraGrid.Columns.GridColumn QUANTITY;
        public DevExpress.XtraGrid.GridControl gridSortChannel;
        private DevExpress.XtraGrid.Columns.GridColumn STATUS;
        public DevExpress.XtraGrid.Views.Grid.GridView viewSortChannel;
        private DevExpress.XtraGrid.Columns.GridColumn CHANNELGROUP;
    }
}
