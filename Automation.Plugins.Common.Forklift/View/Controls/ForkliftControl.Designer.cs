namespace Automation.Plugins.Common.Forklift.View.Controls
{
    partial class ForkliftControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.propertyGridControl1 = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ForkliftName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.RunStatus = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Auto = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.State = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TaskStatus = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.CurrentTask = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.GetRequest = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.GetFinish = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.PutRequest = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.PutFinish = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TaskFinish = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ForkliftStatus = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Loaded = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.propertyDescriptionControl1 = new DevExpress.XtraVerticalGrid.PropertyDescriptionControl();
            this.skinsRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.splitContainerControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1052, 545);
            this.panelControl1.TabIndex = 0;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(2, 2);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1048, 541);
            this.splitContainerControl1.SplitterPosition = 509;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.propertyGridControl1);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.propertyDescriptionControl1);
            this.splitContainerControl2.Panel2.MinSize = 70;
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(509, 541);
            this.splitContainerControl2.SplitterPosition = 70;
            this.splitContainerControl2.TabIndex = 1;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // propertyGridControl1
            // 
            this.propertyGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridControl1.Location = new System.Drawing.Point(0, 0);
            this.propertyGridControl1.Name = "propertyGridControl1";
            this.propertyGridControl1.OptionsBehavior.PropertySort = DevExpress.XtraVerticalGrid.PropertySort.NoSort;
            this.propertyGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.propertyGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.ForkliftName,
            this.RunStatus,
            this.TaskStatus,
            this.ForkliftStatus});
            this.propertyGridControl1.Size = new System.Drawing.Size(509, 466);
            this.propertyGridControl1.TabIndex = 1;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // ForkliftName
            // 
            this.ForkliftName.Name = "ForkliftName";
            this.ForkliftName.OptionsRow.AllowSize = false;
            this.ForkliftName.Properties.Caption = "叉车名称";
            this.ForkliftName.Properties.FieldName = "Name";
            this.ForkliftName.Properties.ReadOnly = true;
            // 
            // RunStatus
            // 
            this.RunStatus.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.Auto,
            this.State});
            this.RunStatus.Name = "RunStatus";
            this.RunStatus.OptionsRow.AllowSize = false;
            this.RunStatus.Properties.Caption = "运行状态";
            this.RunStatus.Properties.FieldName = "isNull";
            this.RunStatus.Properties.ReadOnly = true;
            // 
            // Auto
            // 
            this.Auto.Name = "Auto";
            this.Auto.OptionsRow.AllowSize = false;
            this.Auto.Properties.Caption = "自动模式";
            this.Auto.Properties.FieldName = "Auto";
            this.Auto.Properties.ReadOnly = true;
            this.Auto.Properties.RowEdit = this.repositoryItemCheckEdit1;
            // 
            // State
            // 
            this.State.Name = "State";
            this.State.OptionsRow.AllowSize = false;
            this.State.Properties.Caption = "工作状态";
            this.State.Properties.FieldName = "StateName";
            this.State.Properties.ReadOnly = true;
            // 
            // TaskStatus
            // 
            this.TaskStatus.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.CurrentTask,
            this.GetRequest,
            this.GetFinish,
            this.PutRequest,
            this.PutFinish,
            this.TaskFinish});
            this.TaskStatus.Name = "TaskStatus";
            this.TaskStatus.OptionsRow.AllowSize = false;
            this.TaskStatus.Properties.Caption = "任务状态";
            this.TaskStatus.Properties.FieldName = "isNull";
            this.TaskStatus.Properties.ReadOnly = true;
            // 
            // CurrentTask
            // 
            this.CurrentTask.Name = "CurrentTask";
            this.CurrentTask.OptionsRow.AllowSize = false;
            this.CurrentTask.Properties.Caption = "当前任务";
            this.CurrentTask.Properties.FieldName = "CurrentTask";
            this.CurrentTask.Properties.ReadOnly = true;
            // 
            // GetRequest
            // 
            this.GetRequest.Name = "GetRequest";
            this.GetRequest.OptionsRow.AllowSize = false;
            this.GetRequest.Properties.Caption = "是否请求取货";
            this.GetRequest.Properties.FieldName = "GetRequest";
            this.GetRequest.Properties.ReadOnly = true;
            this.GetRequest.Properties.RowEdit = this.repositoryItemCheckEdit1;
            // 
            // GetFinish
            // 
            this.GetFinish.Height = 17;
            this.GetFinish.Name = "GetFinish";
            this.GetFinish.OptionsRow.AllowSize = false;
            this.GetFinish.Properties.Caption = "是否完成取货";
            this.GetFinish.Properties.FieldName = "GetFinish";
            this.GetFinish.Properties.ReadOnly = true;
            this.GetFinish.Properties.RowEdit = this.repositoryItemCheckEdit1;
            // 
            // PutRequest
            // 
            this.PutRequest.Height = 17;
            this.PutRequest.Name = "PutRequest";
            this.PutRequest.OptionsRow.AllowSize = false;
            this.PutRequest.Properties.Caption = "是否请求放货";
            this.PutRequest.Properties.FieldName = "PutRequest";
            this.PutRequest.Properties.ReadOnly = true;
            this.PutRequest.Properties.RowEdit = this.repositoryItemCheckEdit1;
            // 
            // PutFinish
            // 
            this.PutFinish.Name = "PutFinish";
            this.PutFinish.OptionsRow.AllowSize = false;
            this.PutFinish.Properties.Caption = "是否完成放货";
            this.PutFinish.Properties.FieldName = "PutFinish";
            this.PutFinish.Properties.ReadOnly = true;
            this.PutFinish.Properties.RowEdit = this.repositoryItemCheckEdit1;
            // 
            // TaskFinish
            // 
            this.TaskFinish.Name = "TaskFinish";
            this.TaskFinish.OptionsRow.AllowSize = false;
            this.TaskFinish.Properties.Caption = "当前任务是否完成";
            this.TaskFinish.Properties.FieldName = "TaskFinish";
            this.TaskFinish.Properties.ReadOnly = true;
            this.TaskFinish.Properties.RowEdit = this.repositoryItemCheckEdit1;
            // 
            // ForkliftStatus
            // 
            this.ForkliftStatus.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.Loaded});
            this.ForkliftStatus.Name = "ForkliftStatus";
            this.ForkliftStatus.OptionsRow.AllowSize = false;
            this.ForkliftStatus.Properties.Caption = "叉车状态";
            this.ForkliftStatus.Properties.FieldName = "isNull";
            this.ForkliftStatus.Properties.ReadOnly = true;
            // 
            // Loaded
            // 
            this.Loaded.Height = 17;
            this.Loaded.Name = "Loaded";
            this.Loaded.OptionsRow.AllowSize = false;
            this.Loaded.Properties.Caption = "是否有货物";
            this.Loaded.Properties.FieldName = "Loaded";
            this.Loaded.Properties.ReadOnly = true;
            this.Loaded.Properties.RowEdit = this.repositoryItemCheckEdit1;
            // 
            // propertyDescriptionControl1
            // 
            this.propertyDescriptionControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyDescriptionControl1.Location = new System.Drawing.Point(0, 0);
            this.propertyDescriptionControl1.Name = "propertyDescriptionControl1";
            this.propertyDescriptionControl1.PropertyGrid = this.propertyGridControl1;
            this.propertyDescriptionControl1.Size = new System.Drawing.Size(509, 70);
            this.propertyDescriptionControl1.TabIndex = 1;
            this.propertyDescriptionControl1.TabStop = false;
            // 
            // skinsRibbonPageGroup
            // 
            this.skinsRibbonPageGroup.Name = "skinsRibbonPageGroup";
            this.skinsRibbonPageGroup.ShowCaptionButton = false;
            this.skinsRibbonPageGroup.Text = "Skins";
            // 
            // ForkliftControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "ForkliftControl";
            this.Size = new System.Drawing.Size(1052, 545);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow CurrentTask;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow RunStatus;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Auto;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow State;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TaskStatus;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow GetRequest;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow PutRequest;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow GetFinish;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow PutFinish;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TaskFinish;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ForkliftStatus;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Loaded;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraVerticalGrid.PropertyDescriptionControl propertyDescriptionControl1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ForkliftName;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup skinsRibbonPageGroup;
        public DevExpress.XtraVerticalGrid.PropertyGridControl propertyGridControl1;


    }
}
