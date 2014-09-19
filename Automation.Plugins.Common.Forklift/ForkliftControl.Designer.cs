namespace AAutomation.Plugins.Common.Forklift
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
            this.Connection = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ConnectState = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.HandShake = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.RunStatus = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Local = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ManualControl = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Auto = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Alarm = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Warning = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
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
            this.ForkZero = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.UpForkSWLeft = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.UpForkSWRight = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ForkSWLeft = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ForkSWRight = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TravelPos = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.LiftPos = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ForkPosSingle = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ForkPosDouble = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ForkType = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
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
            this.Connection,
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
            this.ForkliftName.Properties.Caption = "堆垛机名称";
            this.ForkliftName.Properties.FieldName = "Name";
            this.ForkliftName.Properties.ReadOnly = true;
            // 
            // Connection
            // 
            this.Connection.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.ConnectState,
            this.HandShake});
            this.Connection.Name = "Connection";
            this.Connection.OptionsRow.AllowSize = false;
            this.Connection.Properties.Caption = "连接情况";
            this.Connection.Properties.FieldName = "isNull";
            this.Connection.Properties.ReadOnly = true;
            // 
            // ConnectState
            // 
            this.ConnectState.Name = "ConnectState";
            this.ConnectState.OptionsRow.AllowSize = false;
            this.ConnectState.Properties.Caption = "是否连接";
            this.ConnectState.Properties.FieldName = "ConnectState";
            this.ConnectState.Properties.ReadOnly = true;
            this.ConnectState.Properties.RowEdit = this.repositoryItemCheckEdit1;
            // 
            // HandShake
            // 
            this.HandShake.Name = "HandShake";
            this.HandShake.OptionsRow.AllowSize = false;
            this.HandShake.Properties.Caption = "握手信号";
            this.HandShake.Properties.FieldName = "HandShake";
            this.HandShake.Properties.ReadOnly = true;
            this.HandShake.Properties.RowEdit = this.repositoryItemCheckEdit1;
            // 
            // RunStatus
            // 
            this.RunStatus.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.Local,
            this.ManualControl,
            this.Auto,
            this.Alarm,
            this.Warning,
            this.State});
            this.RunStatus.Name = "RunStatus";
            this.RunStatus.OptionsRow.AllowSize = false;
            this.RunStatus.Properties.Caption = "巷道堆垛机运行状态";
            this.RunStatus.Properties.FieldName = "isNull";
            this.RunStatus.Properties.ReadOnly = true;
            // 
            // Local
            // 
            this.Local.Name = "Local";
            this.Local.OptionsRow.AllowSize = false;
            this.Local.Properties.Caption = "就地模式";
            this.Local.Properties.FieldName = "Local";
            this.Local.Properties.ReadOnly = true;
            this.Local.Properties.RowEdit = this.repositoryItemCheckEdit1;
            // 
            // ManualControl
            // 
            this.ManualControl.Name = "ManualControl";
            this.ManualControl.OptionsRow.AllowSize = false;
            this.ManualControl.Properties.Caption = "手持模式";
            this.ManualControl.Properties.FieldName = "ManualControl";
            this.ManualControl.Properties.ReadOnly = true;
            this.ManualControl.Properties.RowEdit = this.repositoryItemCheckEdit1;
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
            // Alarm
            // 
            this.Alarm.Name = "Alarm";
            this.Alarm.OptionsRow.AllowSize = false;
            this.Alarm.Properties.Caption = "是否报警";
            this.Alarm.Properties.FieldName = "Alarm";
            this.Alarm.Properties.ReadOnly = true;
            this.Alarm.Properties.RowEdit = this.repositoryItemCheckEdit1;
            // 
            // Warning
            // 
            this.Warning.Name = "Warning";
            this.Warning.OptionsRow.AllowSize = false;
            this.Warning.Properties.Caption = "是否警告";
            this.Warning.Properties.FieldName = "Warning";
            this.Warning.Properties.ReadOnly = true;
            this.Warning.Properties.RowEdit = this.repositoryItemCheckEdit1;
            // 
            // State
            // 
            this.State.Name = "State";
            this.State.OptionsRow.AllowSize = false;
            this.State.Properties.Caption = "工作状态";
            this.State.Properties.FieldName = "StrState";
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
            this.TaskStatus.Properties.Caption = "任务交互状态";
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
            this.Loaded,
            this.ForkZero,
            this.UpForkSWLeft,
            this.UpForkSWRight,
            this.ForkSWLeft,
            this.ForkSWRight,
            this.TravelPos,
            this.LiftPos,
            this.ForkPosSingle,
            this.ForkPosDouble,
            this.ForkType});
            this.ForkliftStatus.Name = "ForkliftStatus";
            this.ForkliftStatus.OptionsRow.AllowSize = false;
            this.ForkliftStatus.Properties.Caption = "堆垛机状态";
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
            // ForkZero
            // 
            this.ForkZero.Height = 17;
            this.ForkZero.Name = "ForkZero";
            this.ForkZero.OptionsRow.AllowSize = false;
            this.ForkZero.Properties.Caption = "货叉是否处于原点";
            this.ForkZero.Properties.FieldName = "ForkZero";
            this.ForkZero.Properties.ReadOnly = true;
            this.ForkZero.Properties.RowEdit = this.repositoryItemCheckEdit1;
            // 
            // UpForkSWLeft
            // 
            this.UpForkSWLeft.Name = "UpForkSWLeft";
            this.UpForkSWLeft.OptionsRow.AllowSize = false;
            this.UpForkSWLeft.Properties.Caption = "上叉是否左复位";
            this.UpForkSWLeft.Properties.FieldName = "UpForkSWLeft";
            this.UpForkSWLeft.Properties.ReadOnly = true;
            this.UpForkSWLeft.Properties.RowEdit = this.repositoryItemCheckEdit1;
            // 
            // UpForkSWRight
            // 
            this.UpForkSWRight.Name = "UpForkSWRight";
            this.UpForkSWRight.OptionsRow.AllowSize = false;
            this.UpForkSWRight.Properties.Caption = "上叉是否右复位";
            this.UpForkSWRight.Properties.FieldName = "UpForkSWRight";
            this.UpForkSWRight.Properties.ReadOnly = true;
            this.UpForkSWRight.Properties.RowEdit = this.repositoryItemCheckEdit1;
            // 
            // ForkSWLeft
            // 
            this.ForkSWLeft.Name = "ForkSWLeft";
            this.ForkSWLeft.OptionsRow.AllowSize = false;
            this.ForkSWLeft.Properties.Caption = "货叉是否到达左侧限位";
            this.ForkSWLeft.Properties.FieldName = "ForkSWLeft";
            this.ForkSWLeft.Properties.ReadOnly = true;
            this.ForkSWLeft.Properties.RowEdit = this.repositoryItemCheckEdit1;
            // 
            // ForkSWRight
            // 
            this.ForkSWRight.Name = "ForkSWRight";
            this.ForkSWRight.OptionsRow.AllowSize = false;
            this.ForkSWRight.Properties.Caption = "货叉是否到达右侧限位";
            this.ForkSWRight.Properties.FieldName = "ForkSWRight";
            this.ForkSWRight.Properties.ReadOnly = true;
            this.ForkSWRight.Properties.RowEdit = this.repositoryItemCheckEdit1;
            // 
            // TravelPos
            // 
            this.TravelPos.Name = "TravelPos";
            this.TravelPos.OptionsRow.AllowSize = false;
            this.TravelPos.Properties.Caption = "当前行走位置";
            this.TravelPos.Properties.FieldName = "TravelPos";
            this.TravelPos.Properties.ReadOnly = true;
            // 
            // LiftPos
            // 
            this.LiftPos.Name = "LiftPos";
            this.LiftPos.OptionsRow.AllowSize = false;
            this.LiftPos.Properties.Caption = "当前升降位置";
            this.LiftPos.Properties.FieldName = "LiftPos";
            this.LiftPos.Properties.ReadOnly = true;
            // 
            // ForkPosSingle
            // 
            this.ForkPosSingle.Name = "ForkPosSingle";
            this.ForkPosSingle.OptionsRow.AllowSize = false;
            this.ForkPosSingle.Properties.Caption = "当前单伸货叉位置";
            this.ForkPosSingle.Properties.FieldName = "ForkPosSingle";
            this.ForkPosSingle.Properties.ReadOnly = true;
            // 
            // ForkPosDouble
            // 
            this.ForkPosDouble.Name = "ForkPosDouble";
            this.ForkPosDouble.OptionsRow.AllowSize = false;
            this.ForkPosDouble.Properties.Caption = "当前双伸货叉位置";
            this.ForkPosDouble.Properties.FieldName = "ForkPosDouble";
            this.ForkPosDouble.Properties.ReadOnly = true;
            // 
            // ForkType
            // 
            this.ForkType.Name = "ForkType";
            this.ForkType.OptionsRow.AllowSize = false;
            this.ForkType.Properties.Caption = "货叉类型";
            this.ForkType.Properties.FieldName = "ForkType";
            this.ForkType.Properties.ReadOnly = true;
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
        private DevExpress.XtraVerticalGrid.PropertyGridControl propertyGridControl1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Connection;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow CurrentTask;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ConnectState;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow HandShake;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow RunStatus;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Local;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ManualControl;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Auto;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Alarm;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Warning;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow State;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TaskStatus;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow GetRequest;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow PutRequest;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow GetFinish;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow PutFinish;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TaskFinish;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ForkliftStatus;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Loaded;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ForkZero;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow UpForkSWLeft;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow UpForkSWRight;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ForkSWLeft;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ForkSWRight;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TravelPos;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow LiftPos;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ForkPosSingle;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ForkPosDouble;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ForkType;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraVerticalGrid.PropertyDescriptionControl propertyDescriptionControl1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ForkliftName;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup skinsRibbonPageGroup;


    }
}
