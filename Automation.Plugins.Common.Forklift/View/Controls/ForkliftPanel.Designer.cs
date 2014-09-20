namespace Automation.Plugins.Common.Forklift.View.Controls
{
    partial class ForkliftPanel
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
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.propertyGridControl1 = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.rProductName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rOriginCellName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rTargetCellName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rPiecesQutity = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rBarQuantity = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.forkliftControl1 = new Automation.Plugins.Common.Forklift.View.Controls.ForkliftControl();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControl1)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(699, 473);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.propertyGridControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(670, 467);
            this.xtraTabPage1.Text = "任务信息";
            // 
            // propertyGridControl1
            // 
            this.propertyGridControl1.Appearance.BandBorder.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.propertyGridControl1.Appearance.BandBorder.Options.UseFont = true;
            this.propertyGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridControl1.Font = new System.Drawing.Font("Tahoma", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.propertyGridControl1.Location = new System.Drawing.Point(0, 0);
            this.propertyGridControl1.Name = "propertyGridControl1";
            this.propertyGridControl1.RecordWidth = 142;
            this.propertyGridControl1.RowHeaderWidth = 58;
            this.propertyGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rProductName,
            this.rOriginCellName,
            this.rTargetCellName,
            this.rPiecesQutity,
            this.rBarQuantity});
            this.propertyGridControl1.Size = new System.Drawing.Size(670, 467);
            this.propertyGridControl1.TabIndex = 1;
            // 
            // rProductName
            // 
            this.rProductName.Height = 60;
            this.rProductName.Name = "rProductName";
            this.rProductName.Properties.Caption = "卷烟名称";
            this.rProductName.Properties.FieldName = "ProductName";
            this.rProductName.Properties.ReadOnly = true;
            // 
            // rOriginCellName
            // 
            this.rOriginCellName.Height = 60;
            this.rOriginCellName.Name = "rOriginCellName";
            this.rOriginCellName.Properties.Caption = "起始位置";
            this.rOriginCellName.Properties.FieldName = "OriginCellName";
            this.rOriginCellName.Properties.ReadOnly = true;
            // 
            // rTargetCellName
            // 
            this.rTargetCellName.Height = 60;
            this.rTargetCellName.Name = "rTargetCellName";
            this.rTargetCellName.Properties.Caption = "目标位置";
            this.rTargetCellName.Properties.FieldName = "TargetCellName";
            this.rTargetCellName.Properties.ReadOnly = true;
            // 
            // rPiecesQutity
            // 
            this.rPiecesQutity.Height = 60;
            this.rPiecesQutity.Name = "rPiecesQutity";
            this.rPiecesQutity.Properties.Caption = "数量(件)";
            this.rPiecesQutity.Properties.FieldName = "PiecesQutity";
            this.rPiecesQutity.Properties.ReadOnly = true;
            // 
            // rBarQuantity
            // 
            this.rBarQuantity.Height = 60;
            this.rBarQuantity.Name = "rBarQuantity";
            this.rBarQuantity.Properties.Caption = "数量(条)";
            this.rBarQuantity.Properties.FieldName = "BarQuantity";
            this.rBarQuantity.Properties.ReadOnly = true;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.forkliftControl1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(670, 467);
            this.xtraTabPage2.Text = "状态信息";
            // 
            // forkliftControl1
            // 
            this.forkliftControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.forkliftControl1.Forklift = null;
            this.forkliftControl1.Location = new System.Drawing.Point(0, 0);
            this.forkliftControl1.Name = "forkliftControl1";
            this.forkliftControl1.Size = new System.Drawing.Size(670, 467);
            this.forkliftControl1.TabIndex = 0;
            // 
            // ForkliftPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "ForkliftPanel";
            this.Size = new System.Drawing.Size(699, 473);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControl1)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private ForkliftControl forkliftControl1;
        private DevExpress.XtraVerticalGrid.PropertyGridControl propertyGridControl1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rProductName;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rOriginCellName;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rPiecesQutity;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rBarQuantity;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rTargetCellName;
    }
}
