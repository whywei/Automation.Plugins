namespace Automation.Plugins.Sorting.View.Controls
{
    partial class SortChannelCheckControl
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
            this.gridSortChannelCheck = new DevExpress.XtraGrid.GridControl();
            this.viewSortChannelCheck = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.LINECODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CHANNELGROUP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CHANNELCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CHANNELNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CHANNELTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CIGARETTECODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CIGARETTENAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.STATUS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QUANTITY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SORTQUANTITY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.REMAINQUANTITY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BOXQUANTITY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ITEMQUANTITY = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridSortChannelCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewSortChannelCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSortChannelCheck
            // 
            this.gridSortChannelCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSortChannelCheck.Location = new System.Drawing.Point(0, 0);
            this.gridSortChannelCheck.MainView = this.viewSortChannelCheck;
            this.gridSortChannelCheck.Name = "gridSortChannelCheck";
            this.gridSortChannelCheck.Size = new System.Drawing.Size(667, 325);
            this.gridSortChannelCheck.TabIndex = 0;
            this.gridSortChannelCheck.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewSortChannelCheck});
            // 
            // viewSortChannelCheck
            // 
            this.viewSortChannelCheck.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.LINECODE,
            this.CHANNELGROUP,
            this.CHANNELCODE,
            this.CHANNELNAME,
            this.CHANNELTYPE,
            this.CIGARETTECODE,
            this.CIGARETTENAME,
            this.STATUS,
            this.QUANTITY,
            this.SORTQUANTITY,
            this.REMAINQUANTITY,
            this.BOXQUANTITY,
            this.ITEMQUANTITY});
            this.viewSortChannelCheck.GridControl = this.gridSortChannelCheck;
            this.viewSortChannelCheck.Name = "viewSortChannelCheck";
            this.viewSortChannelCheck.OptionsView.ColumnAutoWidth = false;
            this.viewSortChannelCheck.OptionsView.ShowGroupPanel = false;
            // 
            // LINECODE
            // 
            this.LINECODE.Caption = "分拣线";
            this.LINECODE.FieldName = "LINECODE";
            this.LINECODE.Name = "LINECODE";
            this.LINECODE.OptionsColumn.AllowFocus = false;
            this.LINECODE.Visible = true;
            this.LINECODE.VisibleIndex = 0;
            this.LINECODE.Width = 50;
            // 
            // CHANNELGROUP
            // 
            this.CHANNELGROUP.Caption = "烟道组";
            this.CHANNELGROUP.FieldName = "CHANNELGROUP";
            this.CHANNELGROUP.Name = "CHANNELGROUP";
            this.CHANNELGROUP.OptionsColumn.AllowFocus = false;
            this.CHANNELGROUP.Visible = true;
            this.CHANNELGROUP.VisibleIndex = 1;
            this.CHANNELGROUP.Width = 50;
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
            this.CHANNELNAME.Width = 70;
            // 
            // CHANNELTYPE
            // 
            this.CHANNELTYPE.Caption = "烟道类型";
            this.CHANNELTYPE.FieldName = "CHANNELTYPE";
            this.CHANNELTYPE.Name = "CHANNELTYPE";
            this.CHANNELTYPE.OptionsColumn.AllowFocus = false;
            this.CHANNELTYPE.Visible = true;
            this.CHANNELTYPE.VisibleIndex = 4;
            this.CHANNELTYPE.Width = 70;
            // 
            // CIGARETTECODE
            // 
            this.CIGARETTECODE.Caption = "卷烟代码";
            this.CIGARETTECODE.FieldName = "CIGARETTECODE";
            this.CIGARETTECODE.Name = "CIGARETTECODE";
            this.CIGARETTECODE.OptionsColumn.AllowFocus = false;
            this.CIGARETTECODE.Visible = true;
            this.CIGARETTECODE.VisibleIndex = 5;
            this.CIGARETTECODE.Width = 70;
            // 
            // CIGARETTENAME
            // 
            this.CIGARETTENAME.Caption = "卷烟名称";
            this.CIGARETTENAME.FieldName = "CIGARETTENAME";
            this.CIGARETTENAME.Name = "CIGARETTENAME";
            this.CIGARETTENAME.OptionsColumn.AllowFocus = false;
            this.CIGARETTENAME.Visible = true;
            this.CIGARETTENAME.VisibleIndex = 6;
            this.CIGARETTENAME.Width = 140;
            // 
            // STATUS
            // 
            this.STATUS.Caption = "状态";
            this.STATUS.FieldName = "STATUS";
            this.STATUS.Name = "STATUS";
            this.STATUS.OptionsColumn.AllowFocus = false;
            this.STATUS.Visible = true;
            this.STATUS.VisibleIndex = 7;
            this.STATUS.Width = 60;
            // 
            // QUANTITY
            // 
            this.QUANTITY.Caption = "分拣总量";
            this.QUANTITY.FieldName = "QUANTITY";
            this.QUANTITY.Name = "QUANTITY";
            this.QUANTITY.OptionsColumn.AllowFocus = false;
            this.QUANTITY.Visible = true;
            this.QUANTITY.VisibleIndex = 8;
            this.QUANTITY.Width = 70;
            // 
            // SORTQUANTITY
            // 
            this.SORTQUANTITY.Caption = "已分拣量";
            this.SORTQUANTITY.FieldName = "SORTQUANTITY";
            this.SORTQUANTITY.Name = "SORTQUANTITY";
            this.SORTQUANTITY.OptionsColumn.AllowFocus = false;
            this.SORTQUANTITY.Visible = true;
            this.SORTQUANTITY.VisibleIndex = 9;
            this.SORTQUANTITY.Width = 70;
            // 
            // REMAINQUANTITY
            // 
            this.REMAINQUANTITY.Caption = "剩余数量";
            this.REMAINQUANTITY.FieldName = "REMAINQUANTITY";
            this.REMAINQUANTITY.Name = "REMAINQUANTITY";
            this.REMAINQUANTITY.OptionsColumn.AllowFocus = false;
            this.REMAINQUANTITY.Visible = true;
            this.REMAINQUANTITY.VisibleIndex = 10;
            this.REMAINQUANTITY.Width = 70;
            // 
            // BOXQUANTITY
            // 
            this.BOXQUANTITY.Caption = "剩余件数";
            this.BOXQUANTITY.FieldName = "BOXQUANTITY";
            this.BOXQUANTITY.Name = "BOXQUANTITY";
            this.BOXQUANTITY.OptionsColumn.AllowFocus = false;
            this.BOXQUANTITY.Visible = true;
            this.BOXQUANTITY.VisibleIndex = 11;
            this.BOXQUANTITY.Width = 70;
            // 
            // ITEMQUANTITY
            // 
            this.ITEMQUANTITY.Caption = "剩余条数";
            this.ITEMQUANTITY.FieldName = "ITEMQUANTITY";
            this.ITEMQUANTITY.Name = "ITEMQUANTITY";
            this.ITEMQUANTITY.OptionsColumn.AllowFocus = false;
            this.ITEMQUANTITY.Visible = true;
            this.ITEMQUANTITY.VisibleIndex = 12;
            this.ITEMQUANTITY.Width = 70;
            // 
            // SortChannelCheckControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridSortChannelCheck);
            this.Name = "SortChannelCheckControl";
            this.Size = new System.Drawing.Size(667, 325);
            ((System.ComponentModel.ISupportInitialize)(this.gridSortChannelCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewSortChannelCheck)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridSortChannelCheck;
        private DevExpress.XtraGrid.Columns.GridColumn CHANNELNAME;
        private DevExpress.XtraGrid.Columns.GridColumn CHANNELTYPE;
        private DevExpress.XtraGrid.Columns.GridColumn CIGARETTECODE;
        private DevExpress.XtraGrid.Columns.GridColumn CIGARETTENAME;
        private DevExpress.XtraGrid.Columns.GridColumn QUANTITY;
        private DevExpress.XtraGrid.Columns.GridColumn SORTQUANTITY;
        private DevExpress.XtraGrid.Columns.GridColumn REMAINQUANTITY;
        private DevExpress.XtraGrid.Columns.GridColumn BOXQUANTITY;
        private DevExpress.XtraGrid.Columns.GridColumn ITEMQUANTITY;
        private DevExpress.XtraGrid.Columns.GridColumn CHANNELCODE;
        public DevExpress.XtraGrid.Views.Grid.GridView viewSortChannelCheck;
        private DevExpress.XtraGrid.Columns.GridColumn LINECODE;
        private DevExpress.XtraGrid.Columns.GridColumn CHANNELGROUP;
        private DevExpress.XtraGrid.Columns.GridColumn STATUS;
    }
}
