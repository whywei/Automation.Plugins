using System;
using System.Collections.Generic;
using Automation.Plugins.MDJ.WCS.Dal;
using System.Threading;
using Automation.Plugins.MDJ.WCS.Model;
using Automation.Plugins.MDJ.WCS.Device.TaskFactory;
using System.ComponentModel;
using DBRabbit;
using System.Data;
using Automation.Core;
using Automation.Plugins.MDJ.WCS.Rest;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace Automation.Plugins.MDJ.WCS.Device
{
    [Serializable]
    public class SRM
    {
        private const string memoryServiceName = "MemoryPermanentDataService";
        private const string memoryItemName = "TaskFinishData";

        [DescriptionAttribute("堆垛机名称")]
        public string Name { get; set; }
        private SRMInfo SrmInfo { get;set; }

        public IList<ITaskFactory> TaskFactories = new List<ITaskFactory>();
        [DescriptionAttribute("CurrentTaskFactory")]
        private ITaskFactory CurrentTaskFactory { get; set; }
        [ DescriptionAttribute("堆垛机当前任务")]
        public TaskInfo CurrentTask {get;set;}

        private DateTime handShakeTime = DateTime.Now;
        [DescriptionAttribute("WCS与堆垛机的连接状态")]
        public bool ConnectState
        {
            get { return DateTime.Now.Subtract(handShakeTime) < (new TimeSpan(0,0,4)); }
        }

        private bool handShake = false;
        [DescriptionAttribute(@"WCS与堆垛机握手信号，堆垛机每个周期将b_O_HandShake的值取反写入b_I_HandShake,3秒内握手信号未发生改变认为通讯中断")]
        public bool HandShake
        {
            get { return handShake; }
            private set
            {
                handShakeTime = DateTime.Now;
                handShake = value;
                Write("b_O_HandShake", !value);
            }
        }

        [DescriptionAttribute("堆垛机就地模式指示")]
        public bool Local { get; private set; }
        [DescriptionAttribute("堆垛机手持控制器指示")]
        public bool ManualControl { get; private set; }
        [DescriptionAttribute("堆垛机当前运行模式指示[1:自动模式；0:半自动模式]")]
        public bool Auto { get; private set; }
        [DescriptionAttribute("堆垛机报警状态指示")]
        public bool Alarm { get; private set; }
        [ DescriptionAttribute("堆垛机警告状态指示")]
        public bool Warning { get; private set; }
        [DescriptionAttribute("堆垛机有货物")]
        public bool Loaded { get; private set; }
        [DescriptionAttribute("堆垛机货叉处于原点位置")]
        public bool ForkZero { get; private set; }
        [DescriptionAttribute("堆垛机上叉左复位")]
        public bool UpForkSWLeft { get; private set; }
        [DescriptionAttribute("堆垛机上叉右复位")]
        public bool UpForkSWRight { get; private set; }
        [DescriptionAttribute("堆垛机货叉到达左侧限位")]
        public bool ForkSWLeft { get; private set; }
        [DescriptionAttribute("堆垛机货叉到达右侧限位")]
        public bool ForkSWRight { get; private set; }
        [DescriptionAttribute("堆垛机当前行走位置，单位mm")]
        public int TravelPos { get; private set; }
        [DescriptionAttribute("堆垛机当前升降位置，单位mm")]
        public int LiftPos { get; private set; }
        [DescriptionAttribute("堆垛机当前单伸货叉位置，单位mm[货叉向左位置为正值，货叉向右位置为负值]")]
        public int ForkPosSingle { get; private set; }
        [ DescriptionAttribute("堆垛机当前双伸货叉位置，单位mm[货叉向左位置为正值，货叉向右位置为负值]")]
        public int ForkPosDouble { get; private set; }
        [DescriptionAttribute("堆垛机货叉类型[0:单伸货叉；1:双伸货叉]")]
        public int ForkType { get; private set; }

        public IList<int> AlarmCodes = new List<int>();
        public int AlarmCode
        {
            set
            {
                if (value != 0 && !AlarmCodes.Contains(value))
                {
                    AlarmCodes.Add(value);
                    Write("b_O_Acknowledge", true);
                }

                if (value == 0 && !Alarm && !Warning)
                {
                    AlarmCodes.Clear();
                }
            }
        }

        private bool getRequest = false;
        [DescriptionAttribute("堆垛机向输送机请求取货信号")]
        public bool GetRequest
        {
            get { return getRequest; }
            private set
            {
                if (value && CurrentTask != null)
                {
                    if (CheckPositionTask() 
                        && CurrentTask.TravelPos1 > TravelPos - 10
                        && CurrentTask.TravelPos1 < TravelPos + 10
                        && CurrentTask.LiftPos1 > LiftPos - 10
                        && CurrentTask.LiftPos1 < LiftPos + 10
                        && (!CurrentTask.HasGetRequest || CheckIsAbleGet()))
                    {
                        Write("b_O_Get_Permit", true);
                    }
                }
                getRequest = value;
            }
        }

        private bool CheckPositionTask()
        {
            TaskDal taskDal = new TaskDal();
            if (CurrentTask != null && taskDal.CheckPositionTask(CurrentTask.CurrentPositionID))
            {
                return true;
            }
            else
            {
                Logger.Error(string.Format("{0}取货时检查到当前位置同时存在多个任务或无任务，而当前任务可能是错误或无效任务！",Name));
                return false; 
            }
        }

        private bool putRequest = false;
        [DescriptionAttribute("堆垛机向输送机请求放货信号")]
        public bool PutRequest
        {
            get { return putRequest; }
            private set
            {
                if (value && CurrentTask != null)
                {
                    if (CurrentTask.GetFinish 
                            && CurrentTask.TravelPos2 > TravelPos - 10
                            && CurrentTask.TravelPos2 < TravelPos + 10
                            && CurrentTask.RealLiftPos2 + 80 > LiftPos - 30
                            && CurrentTask.RealLiftPos2 + 80 < LiftPos + 30
                            && ((!CurrentTask.HasPutRequest || (CurrentTask.GetFinish && CheckIsAblePut())))
                        || (!CurrentTask.GetFinish
                            && CurrentTask.TravelPos1 > TravelPos - 10
                            && CurrentTask.TravelPos1 < TravelPos + 10
                            && CurrentTask.LiftPos1 + 80 > LiftPos - 30
                            && CurrentTask.LiftPos1 + 80 < LiftPos + 30))
                    {
                        Write("b_O_Put_Permit", true);
                    }
                }
                putRequest = value;
            }
        }

        private bool getFinish = false;
        [DescriptionAttribute("堆垛机向输送机完成取货信号")]
        public bool GetFinish
        {
            get { return getFinish; }
            private set
            {
                if (value)
                {
                    Write("b_O_Get_Permit", false);
                }
                if (value && CurrentTask != null && !CurrentTask.GetFinish)
                {
                    if (CurrentTask.HasGetRequest)
                    {
                        if (CheckPositionTask() && Auto && !Local && !ManualControl && FinishGet())
                        {
                            CurrentTask.GetFinish = true;
                        }
                    }
                    else
                    {
                        CurrentTask.GetFinish = true;
                    }
                }
                if (CurrentTask != null && CurrentTask.GetFinish)
                {
                    Write("b_I_Get_Finish", false);
                }
                if (CurrentTask == null )
                {
                    Write("b_I_Get_Finish", false);
                }
                getFinish = value;
            }
        }

        private bool putFinish = false;
        [DescriptionAttribute("堆垛机向输送机完成放货信号")]
        public bool PutFinish
        {
            get { return putFinish; }
            private set
            {
                if (value)
                {
                    Write("b_O_Put_Permit", false);
                }
                if (value && CurrentTask != null && CurrentTask.GetFinish && !CurrentTask.PutFinish)
                {
                    if (CurrentTask.HasPutRequest)
                    {
                        if (CurrentTask.TravelPos2 > TravelPos - 10
                            && CurrentTask.TravelPos2 < TravelPos + 10
                            && CurrentTask.RealLiftPos2 > LiftPos - 10
                            && CurrentTask.RealLiftPos2 < LiftPos + 10
                            &&　Auto && !Local && !ManualControl && FinishPut())
                        {
                            CurrentTask.PutFinish = true;
                        }
                    }
                    else
                    {
                        CurrentTask.PutFinish = true;
                    }
                }
                if (value && CurrentTask != null && CurrentTask.PutFinish)
                {
                    Write("b_I_Put_Finish", false);
                }
                if (value && (CurrentTask == null || (!CurrentTask.GetFinish && !CurrentTask.PutFinish && !taskFinish)))
                {
                    Write("b_I_Put_Finish", false);
                }
                putFinish = value;
            }
        }

        private bool taskFinish = false;
        [DescriptionAttribute("堆垛机当前任务完成")]
        public bool TaskFinish
        {
            get { return taskFinish; }
            private set
            {
                if (value
                    && CurrentTask != null
                    && CurrentTask.GetFinish
                    && CurrentTask.PutFinish
                    && CurrentTask.TravelPos2 > TravelPos - 10
                    && CurrentTask.TravelPos2 < TravelPos + 10
                    && CurrentTask.RealLiftPos2 > LiftPos - 10
                    && CurrentTask.RealLiftPos2 < LiftPos + 10
                    && Auto && !Local && !ManualControl
                    )
                {
                    FinishTask();
                }
                taskFinish = value;
            }
        }

        private int state = -1;
        [DescriptionAttribute("堆垛机工作状态[0:空闲,无任务；1:等待,有任务；2:定位；3:取货；4:放货；98:维修；99:失效；100:自动]")]
        public int State
        {
            get { return state; }
            private set
            {
                if (value == 0 && CurrentTask == null)
                {
                    NewTask();
                }
                state = value;
            }
        }
        
        private string strState;
        [DescriptionAttribute("堆垛机工作状态[0:空闲,无任务；1:等待,有任务；2:定位；3:取货；4:放货；98:维修；99:失效；100:自动]")]
        public string StrState
        {
            get 
            {
                switch (state)
                {
                    case 0: strState = "空闲,无任务"; break;
                    case 1: strState = "等待,有任务"; break;
                    case 2: strState = "定位"; break;
                    case 3: strState = "取货"; break;
                    case 4: strState = "放货"; break;
                    case 98: strState = "维修"; break;
                    case 99: strState = "失效"; break;
                    case 100: strState = "自动"; break;
                    default: strState = "无状态"; break;
                }
                return strState;
            }
        }

        public void Init()
        {
            //读取堆垛机信息；
            SRMDal srmDal = new SRMDal();
            SrmInfo = srmDal.GetSrmInfo(Name);            
        }

        public void Scan()
        {
            lock (this)
            {
                if (SrmInfo == null) Init();

                HandShake = Convert.ToBoolean(Read("b_I_HandShake"));
                Auto = Convert.ToBoolean(Read("b_I_Auto"));

                State = Convert.ToInt32(Read("n_I_State"));
                GetRequest = Convert.ToBoolean(Read("b_I_Get_Request"));
                PutRequest = Convert.ToBoolean(Read("b_I_Put_Request"));
                GetFinish = Convert.ToBoolean(Read("b_I_Get_Finish"));
                PutFinish = Convert.ToBoolean(Read("b_I_Put_Finish"));
                TaskFinish = Convert.ToBoolean(Read("b_I_Task_Finish"));

                Local = Convert.ToBoolean(Read("b_I_Local"));
                ManualControl = Convert.ToBoolean(Read("b_I_Manual_Control"));

                Alarm = Convert.ToBoolean(Read("b_I_Alarm"));
                Warning = Convert.ToBoolean(Read("b_I_Warning"));
                AlarmCode = Convert.ToInt32(Read("n_I_AlarmCode"));

                Loaded = Convert.ToBoolean(Read("b_I_Loaded"));
                ForkZero = Convert.ToBoolean(Read("b_I_Fork_Zero"));
                UpForkSWLeft = Convert.ToBoolean(Read("b_I_UpFork_SW_Left"));
                UpForkSWRight = Convert.ToBoolean(Read("b_I_UpFork_SW_Right"));
                ForkSWLeft = Convert.ToBoolean(Read("b_I_Fork_SW_Left"));
                ForkSWRight = Convert.ToBoolean(Read("b_I_Fork_SW_Right"));
                TravelPos = Convert.ToInt32(Read("n_I_TravelPos"));
                LiftPos = Convert.ToInt32(Read("n_I_LiftPos"));
                ForkPosSingle = Convert.ToInt32(Read("n_I_ForkPos_Single"));
                ForkPosDouble = Convert.ToInt32(Read("n_I_ForkPos_Double"));
                ForkType = Convert.ToInt32(Read("n_I_ForkType"));
            }
        }


        public void Initialize()
        {
            if (ConnectState == true)
            {
                Write("b_O_Initialize", true);
            }
        }

        public void SetAuto(bool auto)
        {
            if (ConnectState == true)
            {
                Write("b_O_Auto", auto);
            }            
        }

        public void Reset()
        {
            if (ConnectState == true)
            {
                Write("b_O_Reset", true);
            }
        }

        private Queue<int> WaitingTask = new Queue<int>();

        private void NewTask()
        {
            if (CurrentTask == null && Auto && !Local && !ManualControl && taskFinish)
            {
                TaskDal taskDal = new TaskDal();
                StorageDal storageDal = new StorageDal();

                foreach (var taskFactory in TaskFactories)
                {
                    if (WaitingTask.Count > 0)
                    {
                        CurrentTask = taskFactory.GetTask(Name, this.TravelPos, WaitingTask.Dequeue());
                    }
                    else
                    {
                        CurrentTask = taskFactory.GetTask(Name, this.TravelPos);
                    }

                    if (CurrentTask != null && !CheckPath())
                    {
                        WaitingTask.Enqueue(CurrentTask.ID);
                        CurrentTask = taskFactory.GetTask(Name, this.TravelPos, WaitingTask.ToArray());
                    }

                    if (CurrentTask != null && !CheckPath())
                    {
                        WaitingTask.Enqueue(CurrentTask.ID);
                        CurrentTask = null;
                    }

                    if (CurrentTask != null)
                    {
                        if (Write("b_O_Get_Permit", false)
                            && Write("b_O_Put_Permit", false)
                            && Write("b_I_Get_Finish", false)
                            && Write("b_I_Put_Finish", false)
                            && Write("b_O_Cancel_Task", true)
                            && WriteCancelTaskState())
                        {
                            int storageQuantity = CurrentTask.TaskType == "02"
                                && CurrentTask.NextPositionID == CurrentTask.EndPositionID ?
                                storageDal.GetStorageQuantity(CurrentTask.EndPositionID) : 0;

                            int[] position1 = new int[2];
                            int[] type1 = new int[1];
                            int[] position2 = new int[2];
                            int[] type2 = new int[1];
                            position1[0] = CurrentTask.TravelPos1;
                            position1[1] = CurrentTask.LiftPos1;
                            type1[0] = CurrentTask.CurrentPositionExtension + 1;//取货
                            position2[0] = CurrentTask.TravelPos2;
                            position2[1] = (int)(CurrentTask.LiftPos2 + (storageQuantity * Global.PALLET_HEIGHT));
                            CurrentTask.RealLiftPos2 = position2[1];
                            type2[0] = CurrentTask.NextPositionExtension + 2;//放货

                            Write("n_O_Task_Data_Position1", position1);
                            Write("n_O_Task_Data_Type1", type1[0]);
                            Write("n_O_Task_Data_Position2", position2);
                            Write("n_O_Task_Data_Type2", type2[0]);
                            Write("b_O_New_Task", true);

                            taskDal.UpdateTaskStateToExecuting(CurrentTask.ID);
                            CurrentTaskFactory = taskFactory;
                            break;
                        }
                        else
                        {                            
                            Logger.Error(string.Format("{0} 当前任务 [{1}] 发送失败，可能无法连接到堆垛机或密集库PLC！", Name, CurrentTask.ID));
                            CurrentTask = null;
                        }                        
                    }
                }
            }
        }

        private bool CheckPath()
        {
            if (Name == "SRM01" && CurrentTask.NextPositionName == "1005")
            {
                TaskDal taskDal = new TaskDal();
                string nextTwoPositionName = taskDal.GetTaskNextTwoPosition(CurrentTask.ID);
                int[] data = new int[] { Convert.ToInt32(nextTwoPositionName), 1 };

                object obj1 = Ops.Read(SrmInfo.PlcServiceName, "O_S01_Path_Request");
                if (obj1 is Array)
                {
                    Array arrayObj1 = (Array)obj1;
                    if (arrayObj1.Length == 2
                           && data[0] == Convert.ToInt32(arrayObj1.GetValue(0))
                           && data[1] == Convert.ToInt32(arrayObj1.GetValue(1)))
                    {
                        object obj2 = Ops.Read(SrmInfo.PlcServiceName, "I_S01_Path_Allow");
                        if (obj2 is Array)
                        {
                            Array arrayObj2 = (Array)obj2;
                            if (arrayObj2.Length == 2
                               && data[0] == Convert.ToInt32(arrayObj2.GetValue(0))
                               && data[1] == Convert.ToInt32(arrayObj2.GetValue(1)))
                            {
                                return true;
                            }
                        }
                    }
                    else if (arrayObj1.Length == 2
                           && 0 == Convert.ToInt32(arrayObj1.GetValue(0))
                           && 0 == Convert.ToInt32(arrayObj1.GetValue(1)))
                    {
                        if (Ops.Write(SrmInfo.PlcServiceName, "O_S01_Path_Request", data))
                        {
                            Thread.Sleep(1000);
                            object obj3 = Ops.Read(SrmInfo.PlcServiceName, SrmInfo.GetAllowName);
                            if (obj3 is Array)
                            {
                                Array arrayObj3 = (Array)obj3;
                                if (arrayObj3.Length == 2
                                   && data[0] == Convert.ToInt32(arrayObj3.GetValue(0))
                                   && data[1] == Convert.ToInt32(arrayObj3.GetValue(1)))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                return false;
            }
            else if (Name == "SRM03" && CurrentTask.NextPositionName == "1002")
            {
                TaskDal taskDal = new TaskDal();
                string nextTwoPositionName = taskDal.GetTaskNextTwoPosition(CurrentTask.ID);
                int[] data = new int[] { Convert.ToInt32(nextTwoPositionName), 1 };

                object obj1 = Ops.Read(SrmInfo.PlcServiceName, "O_S03_Path_Request");
                if (obj1 is Array)
                {
                    Array arrayObj1 = (Array)obj1;
                    if (arrayObj1.Length == 2
                           && data[0] == Convert.ToInt32(arrayObj1.GetValue(0))
                           && data[1] == Convert.ToInt32(arrayObj1.GetValue(1)))
                    {
                        object obj2 = Ops.Read(SrmInfo.PlcServiceName, "I_S03_Path_Allow");
                        if (obj2 is Array)
                        {
                            Array arrayObj2 = (Array)obj2;
                            if (arrayObj2.Length == 2
                               && data[0] == Convert.ToInt32(arrayObj2.GetValue(0))
                               && data[1] == Convert.ToInt32(arrayObj2.GetValue(1)))
                            {
                                return true;
                            }
                        }
                    }
                    else if (arrayObj1.Length == 2
                           && 0 == Convert.ToInt32(arrayObj1.GetValue(0))
                           && 0 == Convert.ToInt32(arrayObj1.GetValue(1)))
                    {
                        if (Ops.Write(SrmInfo.PlcServiceName, "O_S03_Path_Request", data))
                        {
                            Thread.Sleep(1000);
                            object obj3 = Ops.Read(SrmInfo.PlcServiceName, SrmInfo.GetAllowName);
                            if (obj3 is Array)
                            {
                                Array arrayObj3 = (Array)obj3;
                                if (arrayObj3.Length == 2
                                   && data[0] == Convert.ToInt32(arrayObj3.GetValue(0))
                                   && data[1] == Convert.ToInt32(arrayObj3.GetValue(1)))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ReSendTask()
        {
            if (ConnectState == true)
            {
                lock (this)
                {
                    if (CurrentTask != null && CurrentTask.GetFinish)
                    {
                        if (Write("b_O_Get_Permit", false)
                            && Write("b_O_Put_Permit", false)
                            && Write("b_I_Get_Finish", false)
                            && Write("b_I_Put_Finish", false)
                            && Write("b_O_Cancel_Task", true)
                            && WriteCancelTaskState())
                        {
                            Thread.Sleep(1000);
                            StorageDal storageDal = new StorageDal();

                            int storageQuantity = CurrentTask.TaskType == "02"
                                        && CurrentTask.NextPositionID == CurrentTask.EndPositionID ?
                                        storageDal.GetStorageQuantity(CurrentTask.EndPositionID) : 0;

                            int[] position1 = new int[2];
                            int[] type1 = new int[1];
                            int[] position2 = new int[2];
                            int[] type2 = new int[1];
                            position1[0] = CurrentTask.TravelPos2;
                            position1[1] = (int)(CurrentTask.LiftPos2 + (storageQuantity * Global.PALLET_HEIGHT));
                            type1[0] = 0;//无操作
                            position2[0] = CurrentTask.TravelPos2;
                            position2[1] = (int)(CurrentTask.LiftPos2 + (storageQuantity * Global.PALLET_HEIGHT));
                            CurrentTask.RealLiftPos2 = position2[1];
                            type2[0] = CurrentTask.NextPositionExtension + 2;//放货

                            Write("n_O_Task_Data_Position1", position1);
                            Write("n_O_Task_Data_Type1", type1[0]);
                            Write("n_O_Task_Data_Position2", position2);
                            Write("n_O_Task_Data_Type2", type2[0]);
                            Write("b_O_New_Task", true);
                            XtraMessageBox.Show("当前任务已重发！");
                        }
                        else
                        {
                            XtraMessageBox.Show("当前任务重发失败，可能无法连接到堆垛机或密集库PLC！");
                        }  
                    }
                    else if (CurrentTask != null && !CurrentTask.GetFinish && !CurrentTask.PutFinish)
                    {
                        if (Write("b_O_Get_Permit", false)
                            && Write("b_O_Put_Permit", false)
                            && Write("b_I_Get_Finish", false)
                            && Write("b_I_Put_Finish", false)
                            && Write("b_O_Cancel_Task", true)
                            && WriteCancelTaskState())
                        {
                            Thread.Sleep(1000);
                            StorageDal storageDal = new StorageDal();

                            int storageQuantity = CurrentTask.TaskType == "02"
                                        && CurrentTask.NextPositionID == CurrentTask.EndPositionID ?
                                        storageDal.GetStorageQuantity(CurrentTask.EndPositionID) : 0;

                            int[] position1 = new int[2];
                            int[] type1 = new int[1];
                            int[] position2 = new int[2];
                            int[] type2 = new int[1];
                            position1[0] = CurrentTask.TravelPos1;
                            position1[1] = CurrentTask.LiftPos1;
                            type1[0] = CurrentTask.CurrentPositionExtension + 1;//取货
                            position2[0] = CurrentTask.TravelPos2;
                            position2[1] = (int)(CurrentTask.LiftPos2 + (storageQuantity * Global.PALLET_HEIGHT));
                            CurrentTask.RealLiftPos2 = position2[1];
                            type2[0] = CurrentTask.NextPositionExtension + 2;//放货

                            Write("n_O_Task_Data_Position1", position1);
                            Write("n_O_Task_Data_Type1", type1[0]);
                            Write("n_O_Task_Data_Position2", position2);
                            Write("n_O_Task_Data_Type2", type2[0]);
                            Write("b_O_New_Task", true);
                            XtraMessageBox.Show("当前任务已重发！");
                        }
                        else
                        {
                            XtraMessageBox.Show("当前任务重发失败，可能无法连接到堆垛机或密集库PLC！");
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("当前任务不存在，或不可重发！");
                    }
                }
            }
        }

        public void CancelTask()
        {
            if (ConnectState == true)
            {
                lock (this)
                {
                    if (CurrentTask != null && !CurrentTask.GetFinish)
                    {
                        if (Write("b_O_Get_Permit", false)
                            && Write("b_O_Put_Permit", false)
                            && Write("b_I_Get_Finish", false)
                            && Write("b_I_Put_Finish", false)
                            && Write("b_O_Cancel_Task", true)
                            && WriteCancelTaskState())
                        {
                            TaskDal taskDal = new TaskDal();
                            taskDal.UpdateTaskStateToWaiting(CurrentTask.ID);
                            CurrentTask = null;
                            CurrentTaskFactory = null;
                            XtraMessageBox.Show("当前任务已取消！");
                        }
                        else
                        {
                            XtraMessageBox.Show("当前任务取消失败，可能无法连接到堆垛机或密集库PLC！");
                        }                      
                    }
                    else if (CurrentTask != null && CurrentTask.GetFinish)
                    {
                        XtraMessageBox.Show("当前任务已取货完成，请处理完故障后选择重发任务！");
                    }
                    else
                    {
                        XtraMessageBox.Show("当前任务不存在，或不可取消！");
                    }
                }
            }
        }

        private void FinishTask()
        {
            try
            {
                if (CurrentTask != null)
                {
                    using (TransactionScopeManager TM = new TransactionScopeManager(true, IsolationLevel.Serializable))
                    {
                        TaskDal taskDal = new TaskDal();
                        PositionDal positionDal = new PositionDal();

                        taskDal.TransactionScopeManager = TM;
                        positionDal.TransactionScopeManager = TM;

                        positionDal.UpdateHasGoodsToFalse(CurrentTask.CurrentPositionID);
                        positionDal.UpdateHasGoodsToTrue(CurrentTask.NextPositionID);

                        taskDal.UpdateTaskPosition(CurrentTask.ID, CurrentTask.NextPositionID);
                        taskDal.UpdateTaskPositionStateToArrived(CurrentTask.ID);
                        taskDal.UpdateTaskStateToWaiting(CurrentTask.ID);                        

                        if (CurrentTask.NextPositionID == CurrentTask.EndPositionID
                            && (CurrentTask.TaskType == "03" || CurrentTask.EndPositionType != "03")
                            && (CurrentTask.TaskType == "03" || CurrentTask.EndPositionType != "04"))//小品种，异型烟，由手持PDA完成；
                        {
                            if (CurrentTask.TaskType == "02")
                            {
                                string orderType = taskDal.GetOrderType(CurrentTask.ID);
                                string orderID = taskDal.GetOrderID(CurrentTask.ID);
                                int allotID = taskDal.GetAllotID(CurrentTask.ID);
                                string originCellCode = taskDal.GetOriginCellCode(CurrentTask.ID);
                                string targetCellCode = taskDal.GetTargetCellCode(CurrentTask.ID);
                                string originStorageCode = taskDal.GetOriginStorageCode(CurrentTask.ID);
                                string targetStorageCode = taskDal.GetTargetStorageCode(CurrentTask.ID);

                                RestClient rest = new RestClient();
                                if (!rest.FinishTask(CurrentTask.ID, orderType, orderID, allotID,originCellCode,targetCellCode, originStorageCode, targetStorageCode))
                                {
                                    Logger.Error(string.Format("{0} 完成[{1}]任务失败！", Name, CurrentTask.ID));
                                    return;
                                }
                                else
                                {
                                    taskDal.UpdateTaskStateToExecuted(CurrentTask.ID);
                                }
                            }
                            else
                            {
                                if (!Ops.Write(memoryServiceName, memoryItemName, CurrentTask.ID))
                                {
                                    Logger.Error(string.Format("{0} 完成[{1}]任务失败！", Name, CurrentTask.ID));
                                    return;
                                }
                            }
                        }
                        TM.Commit();

                        CurrentTask = null;
                        CurrentTaskFactory = null;                        
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("SRM.FinishTask 出错，原因：" + ex.Message + "/n" + ex.StackTrace);
            }
        }


        private object Read(string itemName)
        {
            //实现读出堆垛机状态值； 
            object obj = Ops.Read(Name, itemName);
            obj = ObjectUtil.GetObject(obj);
            return obj;
        }

        private bool Write(string itemName,object value)
        {
            //实现写状态值到堆垛机；
            return Ops.Write(Name, itemName, value);
        }


        private bool CheckIsAbleGet()
        {
            //读取许可状态；（取许可）；
            return ReadAbleGetState(CurrentTask.CurrentPositionName); ;
        }       
        
        private bool ReadAbleGetState(string positionName)
        {
            int[] data = new int[] { Convert.ToInt32(positionName), 1 };
            object obj1 = Ops.Read(SrmInfo.PlcServiceName, SrmInfo.GetRequestName);
            if (obj1 is Array)
            {
                Array arrayObj1 = (Array)obj1;
                if (arrayObj1.Length == 2
                       && data[0] == Convert.ToInt32(arrayObj1.GetValue(0))
                       && data[1] == Convert.ToInt32(arrayObj1.GetValue(1)))
                {
                    object obj2 = Ops.Read(SrmInfo.PlcServiceName, SrmInfo.GetAllowName);
                    if (obj2 is Array)
                    {
                        Array arrayObj2 = (Array)obj2;
                        if (arrayObj2.Length == 2
                           && data[0] == Convert.ToInt32(arrayObj2.GetValue(0))
                           && data[1] == Convert.ToInt32(arrayObj2.GetValue(1)))
                        {
                            return true;
                        }
                    }
                }
                else if (arrayObj1.Length == 2
                       && 0 == Convert.ToInt32(arrayObj1.GetValue(0))
                       && 0 == Convert.ToInt32(arrayObj1.GetValue(1)))
                {
                    if (Ops.Write(SrmInfo.PlcServiceName, SrmInfo.GetRequestName, data))
                    {
                        Thread.Sleep(1000);
                        object obj3 = Ops.Read(SrmInfo.PlcServiceName, SrmInfo.GetAllowName);
                        if (obj3 is Array)
                        {
                            Array arrayObj3 = (Array)obj3;
                            if (arrayObj3.Length == 2
                               && data[0] == Convert.ToInt32(arrayObj3.GetValue(0))
                               && data[1] == Convert.ToInt32(arrayObj3.GetValue(1)))
                            {
                                return true;
                            }
                        }
                    }
                }
            }          
            return false;
        }

        private bool FinishGet()
        {
            try
            {
                if (CurrentTask != null)
                {
                    WriteFinishGetState(CurrentTask.CurrentPositionName);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Logger.Error("SRM.FinishGet 出错，原因：" + ex.Message + "/n" + ex.StackTrace);
            }
            return false;
        }

        private void WriteFinishGetState(string positionName)
        {
            int[] data = new int[] { Convert.ToInt32(positionName), 1 };
            Ops.Write(SrmInfo.PlcServiceName, SrmInfo.GetCompleteName, data);

            string msg = "getFinish : ";
            for (int i = 0; i < data.Length; i++)
                msg += string.Format("[{0}]", data[i]);
            Logger.Info(msg);
        }


        private bool CheckIsAblePut()
        {
            //读取许可状态；（放许可）；
            return ReadAblePutState(CurrentTask.NextPositionName);
        }

        private bool ReadAblePutState(string positionName)
        {
            int[] data = new int[] { Convert.ToInt32(positionName), 1 };
            object obj1 = Ops.Read(SrmInfo.PlcServiceName, SrmInfo.PutRequestName);
            if (obj1 is Array)
            {
                Array arrayObj1 = (Array)obj1;
                if (arrayObj1.Length == 2
                   && data[0] == Convert.ToInt32(arrayObj1.GetValue(0))
                   && data[1] == Convert.ToInt32(arrayObj1.GetValue(1)))
                {
                    object obj2 = Ops.Read(SrmInfo.PlcServiceName, SrmInfo.PutAllowName);
                    if (obj2 is Array)
                    {
                        Array arrayObj2 = (Array)obj2;
                        if (arrayObj2.Length == 2
                           && data[0] == Convert.ToInt32(arrayObj2.GetValue(0))
                           && data[1] == Convert.ToInt32(arrayObj2.GetValue(1)))
                        {
                            return true;
                        }
                    }
                }
                else if (arrayObj1.Length == 2
                       && 0 == Convert.ToInt32(arrayObj1.GetValue(0))
                       && 0 == Convert.ToInt32(arrayObj1.GetValue(1)))
                {
                    if (Ops.Write(SrmInfo.PlcServiceName, SrmInfo.PutRequestName, data))
                    {
                        Thread.Sleep(1000);
                        object obj3 = Ops.Read(SrmInfo.PlcServiceName, SrmInfo.PutAllowName);
                        if (obj3 is Array)
                        {
                            Array arrayObj3 = (Array)obj3;
                            if (arrayObj3.Length == 2
                               && data[0] == Convert.ToInt32(arrayObj3.GetValue(0))
                               && data[1] == Convert.ToInt32(arrayObj3.GetValue(1)))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private bool FinishPut()
        {
            try
            {
                if (CurrentTask != null)
                {
                    if (CurrentTask.NextPositionID == CurrentTask.EndPositionID)
                    {
                        WriteFinishPutState(CurrentTask.NextPositionName, "0");
                    }
                    else
                    {
                        TaskDal taskDal = new TaskDal();
                        string nextPositionName = taskDal.GetTaskNextTwoPosition(CurrentTask.ID);
                        WriteFinishPutState(CurrentTask.NextPositionName, nextPositionName);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Logger.Error("SRM.FinishPut 出错，原因：" + ex.Message + "/n" + ex.StackTrace);
            }
            return false;
        }

        private void WriteFinishPutState(string positionName, string nextPositionName)
        {
            int[] data = new int[] { Convert.ToInt32(positionName), CurrentTask.ID, CurrentTask.TaskQuantity, CurrentTask.Length, CurrentTask.Width, CurrentTask.Height, Convert.ToInt32(nextPositionName), 1 };
            Ops.Write(SrmInfo.PlcServiceName, SrmInfo.PutCompleteName, data);

            string msg = "putFinish : ";
            for (int i = 0; i < data.Length; i++)
                msg += string.Format("[{0}]", data[i]);
            Logger.Info(msg);
        }


        private bool WriteCancelTaskState()
        {
            int[] data = new int[] { 1 };
            return Ops.Write(SrmInfo.PlcServiceName, SrmInfo.CancelTaskName, data[0]);
        }

        public override string ToString()
        {
            if (CurrentTask != null )
            {
                return string.Format("{0} 堆垛机 ： [{1}]",Name,CurrentTask.ToString());
            }

            return string.Format("{0} 堆垛机",Name);
        }
    }
}
