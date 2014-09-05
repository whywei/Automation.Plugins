namespace Automation.Plugins.Share.Sorting.View.Dialog
{
    partial class DownLoadDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbOrderDate = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbBatchNo = new DevExpress.XtraEditors.LookUpEdit();
            this.lblProgress = new DevExpress.XtraEditors.LabelControl();
            this.progressBar = new DevExpress.XtraEditors.ProgressBarControl();
            this.btnDaowmLoad = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOrderDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBatchNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "订单日期：";
            // 
            // cmbOrderDate
            // 
            this.cmbOrderDate.Location = new System.Drawing.Point(80, 25);
            this.cmbOrderDate.Name = "cmbOrderDate";
            this.cmbOrderDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbOrderDate.Properties.NullText = "";
            this.cmbOrderDate.Size = new System.Drawing.Size(119, 20);
            this.cmbOrderDate.TabIndex = 1;
            this.cmbOrderDate.EditValueChanged += new System.EventHandler(this.cmbOrderDate_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(242, 26);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "批次：";
            // 
            // cmbBatchNo
            // 
            this.cmbBatchNo.EditValue = "";
            this.cmbBatchNo.Location = new System.Drawing.Point(284, 25);
            this.cmbBatchNo.Name = "cmbBatchNo";
            this.cmbBatchNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBatchNo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", 30, "批次")});
            this.cmbBatchNo.Properties.NullText = "";
            this.cmbBatchNo.Size = new System.Drawing.Size(73, 20);
            this.cmbBatchNo.TabIndex = 3;
            // 
            // lblProgress
            // 
            this.lblProgress.Location = new System.Drawing.Point(14, 83);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(48, 14);
            this.lblProgress.TabIndex = 4;
            this.lblProgress.Text = "下载进度";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(14, 106);
            this.progressBar.Name = "progressBar";
            this.progressBar.Properties.Step = 1;
            this.progressBar.Size = new System.Drawing.Size(343, 18);
            this.progressBar.TabIndex = 5;
            // 
            // btnDaowmLoad
            // 
            this.btnDaowmLoad.Location = new System.Drawing.Point(80, 18);
            this.btnDaowmLoad.Name = "btnDaowmLoad";
            this.btnDaowmLoad.Size = new System.Drawing.Size(75, 23);
            this.btnDaowmLoad.TabIndex = 6;
            this.btnDaowmLoad.Text = "下载";
            this.btnDaowmLoad.Click += new System.EventHandler(this.btnDaowmLoad_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(201, 18);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.panelControl1.Controls.Add(this.btnDaowmLoad);
            this.panelControl1.Controls.Add(this.btnCancel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 151);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(371, 53);
            this.panelControl1.TabIndex = 8;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.cmbOrderDate);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.progressBar);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.lblProgress);
            this.panelControl2.Controls.Add(this.cmbBatchNo);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(371, 151);
            this.panelControl2.TabIndex = 9;
            // 
            // DownLoadDataDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 204);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DownLoadDataDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "分拣数据下载";
            ((System.ComponentModel.ISupportInitialize)(this.cmbOrderDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBatchNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit cmbOrderDate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit cmbBatchNo;
        private DevExpress.XtraEditors.LabelControl lblProgress;
        private DevExpress.XtraEditors.ProgressBarControl progressBar;
        private DevExpress.XtraEditors.SimpleButton btnDaowmLoad;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
    }
}