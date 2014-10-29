namespace Automation.Plugins.LPS.Forklift.Options.Controls
{
    partial class HTTPParameterControl
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
            this.txtHTTP = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHTTP.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(28, 22);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(43, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "HTTP：";
            // 
            // txtHTTP
            // 
            this.txtHTTP.Location = new System.Drawing.Point(77, 19);
            this.txtHTTP.Name = "txtHTTP";
            this.txtHTTP.Size = new System.Drawing.Size(300, 20);
            this.txtHTTP.TabIndex = 1;
            // 
            // HTTPParameterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtHTTP);
            this.Controls.Add(this.labelControl1);
            this.Name = "HTTPParameterControl";
            this.Size = new System.Drawing.Size(432, 234);
            ((System.ComponentModel.ISupportInitialize)(this.txtHTTP.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit txtHTTP;
    }
}
