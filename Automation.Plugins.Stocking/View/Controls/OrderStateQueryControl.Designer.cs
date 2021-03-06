﻿namespace Automation.Plugins.Stocking.View.Controls
{
    partial class OrderStateQueryControl
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
            this.gridOrderStateQuery = new DevExpress.XtraGrid.GridControl();
            this.viewOrderStateQuery = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ROW_INDEX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.STOCKOUTID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LINECODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CIGARETTECODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CIGARETTENAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SORTCHANNELCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CHANNELNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.STATE = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrderStateQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewOrderStateQuery)).BeginInit();
            this.SuspendLayout();
            // 
            // gridOrderStateQuery
            // 
            this.gridOrderStateQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridOrderStateQuery.Location = new System.Drawing.Point(0, 0);
            this.gridOrderStateQuery.MainView = this.viewOrderStateQuery;
            this.gridOrderStateQuery.Name = "gridOrderStateQuery";
            this.gridOrderStateQuery.Size = new System.Drawing.Size(730, 311);
            this.gridOrderStateQuery.TabIndex = 1;
            this.gridOrderStateQuery.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewOrderStateQuery});
            // 
            // viewOrderStateQuery
            // 
            this.viewOrderStateQuery.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ROW_INDEX,
            this.STOCKOUTID,
            this.LINECODE,
            this.CIGARETTECODE,
            this.CIGARETTENAME,
            this.SORTCHANNELCODE,
            this.CHANNELNAME,
            this.STATE});
            this.viewOrderStateQuery.GridControl = this.gridOrderStateQuery;
            this.viewOrderStateQuery.Name = "viewOrderStateQuery";
            this.viewOrderStateQuery.OptionsView.ColumnAutoWidth = false;
            this.viewOrderStateQuery.OptionsView.ShowGroupPanel = false;
            // 
            // ROW_INDEX
            // 
            this.ROW_INDEX.Caption = "流水号";
            this.ROW_INDEX.FieldName = "ROW_INDEX";
            this.ROW_INDEX.Name = "ROW_INDEX";
            this.ROW_INDEX.OptionsColumn.AllowFocus = false;
            this.ROW_INDEX.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ROW_INDEX.Visible = true;
            this.ROW_INDEX.VisibleIndex = 0;
            this.ROW_INDEX.Width = 70;
            // 
            // STOCKOUTID
            // 
            this.STOCKOUTID.Caption = "补货ID";
            this.STOCKOUTID.FieldName = "STOCKOUTID";
            this.STOCKOUTID.Name = "STOCKOUTID";
            this.STOCKOUTID.OptionsColumn.AllowFocus = false;
            this.STOCKOUTID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.STOCKOUTID.Visible = true;
            this.STOCKOUTID.VisibleIndex = 1;
            this.STOCKOUTID.Width = 70;
            // 
            // LINECODE
            // 
            this.LINECODE.Caption = "生产线";
            this.LINECODE.FieldName = "LINECODE";
            this.LINECODE.Name = "LINECODE";
            this.LINECODE.OptionsColumn.AllowFocus = false;
            this.LINECODE.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.LINECODE.Visible = true;
            this.LINECODE.VisibleIndex = 2;
            this.LINECODE.Width = 70;
            // 
            // CIGARETTECODE
            // 
            this.CIGARETTECODE.Caption = "卷烟代码";
            this.CIGARETTECODE.FieldName = "CIGARETTECODE";
            this.CIGARETTECODE.Name = "CIGARETTECODE";
            this.CIGARETTECODE.OptionsColumn.AllowFocus = false;
            this.CIGARETTECODE.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.CIGARETTECODE.Visible = true;
            this.CIGARETTECODE.VisibleIndex = 3;
            this.CIGARETTECODE.Width = 90;
            // 
            // CIGARETTENAME
            // 
            this.CIGARETTENAME.Caption = "卷烟名称";
            this.CIGARETTENAME.FieldName = "CIGARETTENAME";
            this.CIGARETTENAME.Name = "CIGARETTENAME";
            this.CIGARETTENAME.OptionsColumn.AllowFocus = false;
            this.CIGARETTENAME.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.CIGARETTENAME.Visible = true;
            this.CIGARETTENAME.VisibleIndex = 4;
            this.CIGARETTENAME.Width = 150;
            // 
            // SORTCHANNELCODE
            // 
            this.SORTCHANNELCODE.Caption = "分拣烟道";
            this.SORTCHANNELCODE.FieldName = "SORTCHANNELCODE";
            this.SORTCHANNELCODE.Name = "SORTCHANNELCODE";
            this.SORTCHANNELCODE.OptionsColumn.AllowFocus = false;
            this.SORTCHANNELCODE.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.SORTCHANNELCODE.Visible = true;
            this.SORTCHANNELCODE.VisibleIndex = 5;
            this.SORTCHANNELCODE.Width = 100;
            // 
            // CHANNELNAME
            // 
            this.CHANNELNAME.Caption = "补货烟道";
            this.CHANNELNAME.FieldName = "CHANNELNAME";
            this.CHANNELNAME.Name = "CHANNELNAME";
            this.CHANNELNAME.OptionsColumn.AllowFocus = false;
            this.CHANNELNAME.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.CHANNELNAME.Visible = true;
            this.CHANNELNAME.VisibleIndex = 6;
            this.CHANNELNAME.Width = 100;
            // 
            // STATE
            // 
            this.STATE.Caption = "状态";
            this.STATE.FieldName = "STATE";
            this.STATE.Name = "STATE";
            this.STATE.OptionsColumn.AllowFocus = false;
            this.STATE.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.STATE.Visible = true;
            this.STATE.VisibleIndex = 7;
            this.STATE.Width = 60;
            // 
            // OrderStateQueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridOrderStateQuery);
            this.Name = "OrderStateQueryControl";
            this.Size = new System.Drawing.Size(730, 311);
            ((System.ComponentModel.ISupportInitialize)(this.gridOrderStateQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewOrderStateQuery)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridOrderStateQuery;
        public DevExpress.XtraGrid.Views.Grid.GridView viewOrderStateQuery;
        private DevExpress.XtraGrid.Columns.GridColumn ROW_INDEX;
        private DevExpress.XtraGrid.Columns.GridColumn STOCKOUTID;
        private DevExpress.XtraGrid.Columns.GridColumn LINECODE;
        private DevExpress.XtraGrid.Columns.GridColumn CIGARETTECODE;
        private DevExpress.XtraGrid.Columns.GridColumn CIGARETTENAME;
        private DevExpress.XtraGrid.Columns.GridColumn SORTCHANNELCODE;
        private DevExpress.XtraGrid.Columns.GridColumn CHANNELNAME;
        private DevExpress.XtraGrid.Columns.GridColumn STATE;
    }
}
