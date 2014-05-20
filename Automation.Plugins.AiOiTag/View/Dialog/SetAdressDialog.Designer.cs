namespace Automation.Plugin.MDJ.WCS.View.Dialog
{
    partial class SetAdressDialog
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
            this.txtAdress = new DevExpress.XtraEditors.TextEdit();
            this.btnOK = new DevExpress.XtraEditors.CheckButton();
            this.btnCancel = new DevExpress.XtraEditors.CheckButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblIP = new DevExpress.XtraEditors.LabelControl();
            this.lblPort = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdress.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(31, 89);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(84, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "电子标签地址：";
            // 
            // txtAdress
            // 
            this.txtAdress.Location = new System.Drawing.Point(121, 86);
            this.txtAdress.Name = "txtAdress";
            this.txtAdress.Properties.Mask.EditMask = "([1-9]\\d+)|[2-9] ";
            this.txtAdress.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtAdress.Size = new System.Drawing.Size(134, 20);
            this.txtAdress.TabIndex = 1;
            this.txtAdress.ToolTip = "按下确定之前，先按下CONFIRM 按钮";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(31, 122);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "设置";
            this.btnOK.CheckedChanged += new System.EventHandler(this.btnOK_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(180, 122);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "关闭";
            this.btnCancel.CheckedChanged += new System.EventHandler(this.btnCancel_CheckedChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(31, 16);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "控制器IP:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(34, 50);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "端口号：";
            // 
            // lblIP
            // 
            this.lblIP.Location = new System.Drawing.Point(88, 16);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(22, 14);
            this.lblIP.TabIndex = 7;
            this.lblIP.Text = "lblIP";
            // 
            // lblPort
            // 
            this.lblPort.Location = new System.Drawing.Point(88, 49);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(34, 14);
            this.lblPort.TabIndex = 8;
            this.lblPort.Text = "lblPort";
            // 
            // SetAdressDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(292, 166);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtAdress);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "SetAdressDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置地址";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SetAdressDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtAdress.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtAdress;
        private DevExpress.XtraEditors.CheckButton btnOK;
        private DevExpress.XtraEditors.CheckButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblIP;
        private DevExpress.XtraEditors.LabelControl lblPort;
    }
}