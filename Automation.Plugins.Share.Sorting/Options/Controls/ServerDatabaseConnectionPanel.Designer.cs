namespace Automation.Plugins.YZ.Sorting.Options.Controls
{
    partial class ServerDatabaseConnectionPanel
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.propertyGridControl1 = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.IP = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.DataBaseName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.User = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Password = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ConfirmPassword = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnTestConneection = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.panelControl4);
            this.panelControl2.Controls.Add(this.panelControl3);
            this.panelControl2.Location = new System.Drawing.Point(3, 3);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(342, 299);
            this.panelControl2.TabIndex = 20;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.panelControl1);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(2, 2);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(338, 254);
            this.panelControl4.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.propertyGridControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(334, 250);
            this.panelControl1.TabIndex = 0;
            // 
            // propertyGridControl1
            // 
            this.propertyGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridControl1.Location = new System.Drawing.Point(2, 2);
            this.propertyGridControl1.Name = "propertyGridControl1";
            this.propertyGridControl1.OptionsBehavior.PropertySort = DevExpress.XtraVerticalGrid.PropertySort.NoSort;
            this.propertyGridControl1.OptionsBehavior.ResizeRowValues = false;
            this.propertyGridControl1.RecordWidth = 128;
            this.propertyGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3});
            this.propertyGridControl1.RowHeaderWidth = 72;
            this.propertyGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.IP,
            this.DataBaseName,
            this.User,
            this.Password,
            this.ConfirmPassword});
            this.propertyGridControl1.Size = new System.Drawing.Size(330, 246);
            this.propertyGridControl1.TabIndex = 0;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.PasswordChar = '*';
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            this.repositoryItemTextEdit2.PasswordChar = '*';
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // IP
            // 
            this.IP.Height = 40;
            this.IP.Name = "IP";
            this.IP.OptionsRow.AllowMove = false;
            this.IP.OptionsRow.AllowSize = false;
            this.IP.Properties.Caption = "服务器名";
            this.IP.Properties.FieldName = "IP";
            this.IP.Properties.ShowUnboundExpressionMenu = true;
            // 
            // DataBaseName
            // 
            this.DataBaseName.Height = 40;
            this.DataBaseName.Name = "DataBaseName";
            this.DataBaseName.OptionsRow.AllowMove = false;
            this.DataBaseName.OptionsRow.AllowSize = false;
            this.DataBaseName.Properties.Caption = "数据库名";
            this.DataBaseName.Properties.FieldName = "DataBaseName";
            // 
            // User
            // 
            this.User.Height = 40;
            this.User.Name = "User";
            this.User.OptionsRow.AllowMove = false;
            this.User.OptionsRow.AllowSize = false;
            this.User.Properties.Caption = "登录名称";
            this.User.Properties.FieldName = "User";
            // 
            // Password
            // 
            this.Password.Height = 40;
            this.Password.Name = "Password";
            this.Password.OptionsRow.AllowMove = false;
            this.Password.OptionsRow.AllowSize = false;
            this.Password.Properties.Caption = "登录密码";
            this.Password.Properties.FieldName = "Password";
            this.Password.Properties.RowEdit = this.repositoryItemTextEdit2;
            // 
            // ConfirmPassword
            // 
            this.ConfirmPassword.Appearance.Options.UseTextOptions = true;
            this.ConfirmPassword.Height = 40;
            this.ConfirmPassword.Name = "ConfirmPassword";
            this.ConfirmPassword.OptionsRow.AllowMove = false;
            this.ConfirmPassword.OptionsRow.AllowMoveToCustomizationForm = false;
            this.ConfirmPassword.OptionsRow.AllowSize = false;
            this.ConfirmPassword.Properties.Caption = "确认密码";
            this.ConfirmPassword.Properties.FieldName = "ConfirmPassword";
            this.ConfirmPassword.Properties.RowEdit = this.repositoryItemTextEdit1;
            this.ConfirmPassword.Properties.ShowUnboundExpressionMenu = true;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnSave);
            this.panelControl3.Controls.Add(this.btnTestConneection);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(2, 256);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(338, 41);
            this.panelControl3.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(188, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "保存修改";
            // 
            // btnTestConneection
            // 
            this.btnTestConneection.Location = new System.Drawing.Point(59, 9);
            this.btnTestConneection.Name = "btnTestConneection";
            this.btnTestConneection.Size = new System.Drawing.Size(75, 23);
            this.btnTestConneection.TabIndex = 3;
            this.btnTestConneection.Text = "测试连接";
            // 
            // ServerDatabaseConnectionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Name = "ServerDatabaseConnectionPanel";
            this.Size = new System.Drawing.Size(685, 389);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow IP;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow User;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Password;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ConfirmPassword;
        public DevExpress.XtraVerticalGrid.PropertyGridControl propertyGridControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        public DevExpress.XtraEditors.SimpleButton btnSave;
        public DevExpress.XtraEditors.SimpleButton btnTestConneection;
        public DevExpress.XtraVerticalGrid.Rows.EditorRow DataBaseName;
        private DevExpress.XtraEditors.PanelControl panelControl1;

    }
}
