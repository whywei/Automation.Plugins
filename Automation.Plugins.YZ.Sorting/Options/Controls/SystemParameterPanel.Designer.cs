namespace Automation.Plugins.YZ.Sorting.Options.Controls
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
            this.txtPackDataPath = new DevExpress.XtraEditors.TextEdit();
            this.txtSortingLineCode = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPackDataPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSortingLineCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(34, 58);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "分拣线编码：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 19);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(96, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "包装机数据地址：";
            // 
            // txtPackDataPath
            // 
            this.txtPackDataPath.Location = new System.Drawing.Point(112, 16);
            this.txtPackDataPath.Name = "txtPackDataPath";
            this.txtPackDataPath.Size = new System.Drawing.Size(265, 20);
            this.txtPackDataPath.TabIndex = 2;
            // 
            // txtSortingLineCode
            // 
            this.txtSortingLineCode.Location = new System.Drawing.Point(112, 55);
            this.txtSortingLineCode.Name = "txtSortingLineCode";
            this.txtSortingLineCode.Size = new System.Drawing.Size(265, 20);
            this.txtSortingLineCode.TabIndex = 3;
            // 
            // SystemParameterPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSortingLineCode);
            this.Controls.Add(this.txtPackDataPath);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "SystemParameterPanel";
            this.Size = new System.Drawing.Size(554, 290);
            ((System.ComponentModel.ISupportInitialize)(this.txtPackDataPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSortingLineCode.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit txtPackDataPath;
        public DevExpress.XtraEditors.TextEdit txtSortingLineCode;
    }
}
