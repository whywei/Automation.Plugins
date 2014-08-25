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
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtSupplyPosition = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtHttpUrl = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtPackDataPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSortingLineCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplyPosition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHttpUrl.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(47, 91);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "分拣线编码：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(23, 54);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(96, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "包装机数据地址：";
            // 
            // txtPackDataPath
            // 
            this.txtPackDataPath.Location = new System.Drawing.Point(125, 51);
            this.txtPackDataPath.Name = "txtPackDataPath";
            this.txtPackDataPath.Size = new System.Drawing.Size(265, 20);
            this.txtPackDataPath.TabIndex = 2;
            // 
            // txtSortingLineCode
            // 
            this.txtSortingLineCode.Location = new System.Drawing.Point(125, 88);
            this.txtSortingLineCode.Name = "txtSortingLineCode";
            this.txtSortingLineCode.Size = new System.Drawing.Size(265, 20);
            this.txtSortingLineCode.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(11, 17);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(108, 14);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "补货缓存位置编号：";
            // 
            // txtSupplyPosition
            // 
            this.txtSupplyPosition.Location = new System.Drawing.Point(125, 14);
            this.txtSupplyPosition.Name = "txtSupplyPosition";
            this.txtSupplyPosition.Size = new System.Drawing.Size(265, 20);
            this.txtSupplyPosition.TabIndex = 5;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(69, 128);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(51, 14);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "HttpUrl：";
            // 
            // txtHttpUrl
            // 
            this.txtHttpUrl.Location = new System.Drawing.Point(125, 125);
            this.txtHttpUrl.Name = "txtHttpUrl";
            this.txtHttpUrl.Size = new System.Drawing.Size(265, 20);
            this.txtHttpUrl.TabIndex = 7;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(396, 17);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(110, 14);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "多个位置时用“,”分割";
            // 
            // SystemParameterPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtHttpUrl);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtSupplyPosition);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtSortingLineCode);
            this.Controls.Add(this.txtPackDataPath);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "SystemParameterPanel";
            this.Size = new System.Drawing.Size(554, 290);
            ((System.ComponentModel.ISupportInitialize)(this.txtPackDataPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSortingLineCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplyPosition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHttpUrl.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit txtPackDataPath;
        public DevExpress.XtraEditors.TextEdit txtSortingLineCode;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.TextEdit txtSupplyPosition;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.TextEdit txtHttpUrl;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}
