namespace Automation.Plugins.AS.WCS.Options.Controls
{
    partial class SystemParameterPanel
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtHttpUrl = new DevExpress.XtraEditors.TextEdit();
            this.txtSRMCount = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHttpUrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSRMCount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(45, 22);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "HttpUrl：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(24, 66);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "堆垛机数量：";
            // 
            // txtHttpUrl
            // 
            this.txtHttpUrl.Location = new System.Drawing.Point(101, 19);
            this.txtHttpUrl.Name = "txtHttpUrl";
            this.txtHttpUrl.Size = new System.Drawing.Size(359, 20);
            this.txtHttpUrl.TabIndex = 2;
            // 
            // txtSRMCount
            // 
            this.txtSRMCount.Location = new System.Drawing.Point(101, 63);
            this.txtSRMCount.Name = "txtSRMCount";
            this.txtSRMCount.Properties.Mask.EditMask = "n0";
            this.txtSRMCount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSRMCount.Size = new System.Drawing.Size(359, 20);
            this.txtSRMCount.TabIndex = 3;
            // 
            // SystemParameterPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSRMCount);
            this.Controls.Add(this.txtHttpUrl);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "SystemParameterPanel";
            this.Size = new System.Drawing.Size(521, 270);
            ((System.ComponentModel.ISupportInitialize)(this.txtHttpUrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSRMCount.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit txtHttpUrl;
        public DevExpress.XtraEditors.TextEdit txtSRMCount;
    }
}
