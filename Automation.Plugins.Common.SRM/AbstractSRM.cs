using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition;
using System.Reflection;
using System.IO;
using System.ComponentModel;
using Automation.Core.Util;
using System.Windows.Forms;
using Automation.Core;
using System.Threading.Tasks;

namespace Automation.Plugins.Common.SRM
{
    public abstract class AbstractSRM : ISRM, IPartImportsSatisfiedNotification
    {
        private bool handShake = false;
        private DateTime handShakeTime = DateTime.Now;

        [DescriptionAttribute("堆垛机名称")]
        public string Name { get; set; }

        [DescriptionAttribute("堆垛机全称")]
        public string FullName { get; set; }

        public string PartnerName { get; set; }

        [DescriptionAttribute(@"堆垛机握手信号,3秒内握手信号未发生改变认为通讯中断")]
        public bool HandShake
        {
            get { return handShake; }
            private set
            {
                handShakeTime = handShake == value ? handShakeTime : DateTime.Now;
                handShake = value;
                Ops.Write(Name,"b_O_HandShake", !value);
            }
        }

        [DescriptionAttribute("堆垛机连接状态")]
        public bool ConnectState
        {
            get { return DateTime.Now.Subtract(handShakeTime) < (new TimeSpan(0, 0, 4)); }
        }

        [DescriptionAttribute("堆垛机当前运行模式指示[1：自动模式；0：半自动模式]")]
        public bool Auto { get; protected set; }
        [DescriptionAttribute("堆垛机就地模式指示")]
        public bool Local { get; protected set; }
        [DescriptionAttribute("堆垛机手持控制器指示")]
        public bool ManualControl { get; protected set; }

        [DescriptionAttribute("堆垛机报警状态指示")]
        public bool Alarm { get; protected set; }
        [DescriptionAttribute("堆垛机警告状态指示")]
        public bool Warning { get; protected set; }

        public IList<int> AlarmCodes = new List<int>();
        protected int AlarmCode
        {
            set
            {
                if (value != 0 && !AlarmCodes.Contains(value))
                {
                    AlarmCodes.Add(value);
                    Ops.Write(Name,"b_O_Acknowledge", true);
                }

                if (value == 0 && !Alarm && !Warning)
                {
                    AlarmCodes.Clear();
                }
            }
        }

        [DescriptionAttribute("堆垛机工作状态[0:空闲,无任务；1:等待,有任务；2:定位；3:取货；4:放货；98:维修；99:失效；100:自动]")]
        public int State { get; protected set; }
        [DescriptionAttribute("堆垛机工作状态[0:空闲,无任务；1:等待,有任务；2:定位；3:取货；4:放货；98:维修；99:失效；100:自动]")]
        public string StateName
        {
            get
            {
                switch (State)
                {
                    case 0: return "空闲,无任务";
                    case 1: return "等待,有任务";
                    case 2: return "定位";
                    case 3: return "取货";
                    case 4: return "放货";
                    case 98: return "维修";
                    case 99: return "失效";
                    case 100: return "自动";
                    default: return "无状态";
                }
            }
        }
        [DescriptionAttribute("堆垛机请求取货")]
        public bool GetRequest { get; protected set; }
        [DescriptionAttribute("堆垛机请求放货")]
        public bool PutRequest { get; protected set; }
        [DescriptionAttribute("堆垛机完成取货")]
        public bool GetFinish { get; protected set; }
        [DescriptionAttribute("堆垛机完成放货")]
        public bool PutFinish { get; protected set; }
        [DescriptionAttribute("堆垛机任务完成")]
        public bool TaskFinish { get; protected set; }

        [DescriptionAttribute("堆垛机有货物")]
        public bool Loaded { get; protected set; }
        [DescriptionAttribute("堆垛机当前行走位置，单位mm")]
        public int TravelPos { get; protected set; }
        [DescriptionAttribute("堆垛机当前升降位置，单位mm")]
        public int LiftPos { get; protected set; }

        [DescriptionAttribute("堆垛机货叉类型[0：单伸货叉；1：双伸货叉]")]
        public int ForkType { get; protected set; }
        [DescriptionAttribute("堆垛机当前单伸货叉位置，单位mm[货叉向左位置为正值，货叉向右位置为负值]")]
        public int ForkPosSingle { get; protected set; }
        [DescriptionAttribute("堆垛机当前双伸货叉位置，单位mm[货叉向左位置为正值，货叉向右位置为负值]")]
        public int ForkPosDouble { get; protected set; }

        [DescriptionAttribute("堆垛机货叉处于原点位置")]
        public bool ForkZero { get; protected set; }
        [DescriptionAttribute("堆垛机上叉左复位")]
        public bool UpForkSWLeft { get; protected set; }
        [DescriptionAttribute("堆垛机上叉右复位")]
        public bool UpForkSWRight { get; protected set; }
        [DescriptionAttribute("堆垛机货叉到达左侧限位")]
        public bool ForkSWLeft { get; protected set; }
        [DescriptionAttribute("堆垛机货叉到达右侧限位")]
        public bool ForkSWRight { get; protected set; }

        [DescriptionAttribute("堆垛机当前任务")]
        public SRMTask CurrentTask { get; private set;}

        public SRMTask NextTask { get; private set; }

        public Dictionary<string, object> Parameter = new Dictionary<string, object>();

        
        public virtual void Initialize()
        {
            lock (this)
            {
                try
                {
                    Deserialize();
                    if (Parameter.ContainsKey("CurrentTask"))
                    {
                        CurrentTask = Parameter["CurrentTask"] as SRMTask;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(string.Format("SRM ：{0} 初始失败，原因详情：{1}{2}", Name, ex.Message, ex.StackTrace));
                }
            }
        }

        public virtual void Release()
        {
            lock (this)
            {
                try
                {
                    Serialize();
                }
                catch (Exception ex)
                {
                    Logger.Error(string.Format("SRM ：{0} 释放资源失败，原因详情:{1}{2}", Name, ex.Message, ex.StackTrace));
                }
            }
        }


        public virtual void FireHeartbeat()
        {
            this.Scan();
            if (ConnectState == true)
            {
                this.Execute();
            }
        }

        private IList<Task> tasks = new List<Task>();
        public virtual void Scan()
        {
            try
            {
                if (tasks.Count > 0)
                {
                    Task.WaitAll(tasks.ToArray());
                    tasks.Clear();
                }   
                tasks.Add(Task.Factory.StartNew(() => { HandShake = Ops.ReadSingle<bool>(Name, "b_I_HandShake"); }));
                tasks.Add(Task.Factory.StartNew(() => { Auto = Ops.ReadSingle<bool>(Name, "b_I_Auto"); }));
                tasks.Add(Task.Factory.StartNew(() => { Local = Ops.ReadSingle<bool>(Name, "b_I_Local"); }));
                tasks.Add(Task.Factory.StartNew(() => { ManualControl = Ops.ReadSingle<bool>(Name, "b_I_Manual_Control"); }));
                tasks.Add(Task.Factory.StartNew(() => { Alarm = Ops.ReadSingle<bool>(Name, "b_I_Alarm"); }));
                tasks.Add(Task.Factory.StartNew(() => { Warning = Ops.ReadSingle<bool>(Name, "b_I_Warning"); }));
                tasks.Add(Task.Factory.StartNew(() => { AlarmCode = Ops.ReadSingle<int>(Name, "n_I_AlarmCode"); }));
                tasks.Add(Task.Factory.StartNew(() => { State = Ops.ReadSingle<int>(Name, "n_I_State"); }));
                tasks.Add(Task.Factory.StartNew(() => { GetRequest = Ops.ReadSingle<bool>(Name, "b_I_Get_Request"); }));
                tasks.Add(Task.Factory.StartNew(() => { PutRequest = Ops.ReadSingle<bool>(Name, "b_I_Put_Request"); }));
                tasks.Add(Task.Factory.StartNew(() => { GetFinish = Ops.ReadSingle<bool>(Name, "b_I_Get_Finish"); }));
                tasks.Add(Task.Factory.StartNew(() => { PutFinish = Ops.ReadSingle<bool>(Name, "b_I_Put_Finish"); }));
                tasks.Add(Task.Factory.StartNew(() => { TaskFinish = Ops.ReadSingle<bool>(Name, "b_I_Task_Finish"); }));
                tasks.Add(Task.Factory.StartNew(() => { Loaded = Ops.ReadSingle<bool>(Name, "b_I_Loaded"); }));
                tasks.Add(Task.Factory.StartNew(() => { TravelPos = Ops.ReadSingle<int>(Name, "n_I_TravelPos"); }));
                tasks.Add(Task.Factory.StartNew(() => { LiftPos = Ops.ReadSingle<int>(Name, "n_I_LiftPos"); }));
                tasks.Add(Task.Factory.StartNew(() => { ForkPosSingle = Ops.ReadSingle<int>(Name, "n_I_ForkPos_Single"); }));
                tasks.Add(Task.Factory.StartNew(() => { ForkPosDouble = Ops.ReadSingle<int>(Name, "n_I_ForkPos_Double"); }));
                tasks.Add(Task.Factory.StartNew(() => { ForkType = Ops.ReadSingle<int>(Name, "n_I_ForkType"); }));
                tasks.Add(Task.Factory.StartNew(() => { ForkZero = Ops.ReadSingle<bool>(Name, "b_I_Fork_Zero"); }));
                tasks.Add(Task.Factory.StartNew(() => { UpForkSWLeft = Ops.ReadSingle<bool>(Name, "b_I_UpFork_SW_Left"); }));
                tasks.Add(Task.Factory.StartNew(() => { UpForkSWRight = Ops.ReadSingle<bool>(Name, "b_I_UpFork_SW_Right"); }));
                tasks.Add(Task.Factory.StartNew(() => { ForkSWLeft = Ops.ReadSingle<bool>(Name, "b_I_Fork_SW_Left"); }));
                tasks.Add(Task.Factory.StartNew(() => { ForkSWRight = Ops.ReadSingle<bool>(Name, "b_I_Fork_SW_Right"); }));
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("SRM ：{0} Scan 出错，原因详情：{1}{2}", Name, ex.Message, ex.StackTrace));
            }
        }

        public virtual void Execute()
        {
            try
            {
                //请求新任务
                if (CurrentTask == null && State == 0
                    && Auto && !Local && !ManualControl && !Alarm && TaskFinish)
                {
                    CurrentTask = NextTask ?? ApplyNewTask();
                    NextTask = null;
                }

                if (CurrentTask != null && State == 2 && NextTask == null)
                {
                    NextTask = ApplyNewTask();
                }

                if (CurrentTask != null && !CurrentTask.IsSent)
                {
                    Send();
                    return;
                }
                
                Serialize();

                //请求取货
                if (CurrentTask != null && GetRequest
                    && Auto && !Local && !ManualControl && !Alarm
                    && CurrentTask.TravelPos1 > TravelPos - 10
                    && CurrentTask.TravelPos1 < TravelPos + 10
                    && CurrentTask.LiftPos1 > LiftPos - 10
                    && CurrentTask.LiftPos1 < LiftPos + 10
                    && (!CurrentTask.HasGetRequest || CheckIsPermitGet()))
                {
                    SetGetPermit(true);
                }
  
                //请求放货
                if (CurrentTask != null && PutRequest
                    && Auto && !Local && !ManualControl && !Alarm)
                {
                    if (CurrentTask.GetFinish
                        && CurrentTask.TravelPos2 > TravelPos - 10
                        && CurrentTask.TravelPos2 < TravelPos + 10
                        && CurrentTask.RealLiftPos2 > LiftPos - 120
                        && CurrentTask.RealLiftPos2 < LiftPos
                        && (!CurrentTask.HasPutRequest || CheckIsPermitPut()))
                    {
                        SetPutPermit(true);
                    }

                    if (!CurrentTask.GetFinish
                        && CurrentTask.TravelPos1 > TravelPos - 10
                        && CurrentTask.TravelPos1 < TravelPos + 10
                        && CurrentTask.LiftPos1 > LiftPos - 120
                        && CurrentTask.LiftPos1 < LiftPos)
                    {
                        SetPutPermit(true);
                    }
                }

                //取货完成
                if (CurrentTask != null && GetFinish
                    && Auto && !Local && !ManualControl && !Alarm)
                {
                    if (!CurrentTask.GetFinish)
                    {
                        if (CurrentTask.HasGetRequest)
                        {
                            if (FinishGet())
                            {
                                CurrentTask.GetFinish = true;
                            }
                        }
                        else
                        {
                            CurrentTask.GetFinish = true;
                        }
                    }
                }
                
                if (CurrentTask != null && CurrentTask.GetFinish)
                {
                    SetGetRequest(false);
                    SetGetPermit(false);
                    SetGetFinish(false);
                }
                if (CurrentTask == null)
                {
                    SetGetRequest(false);
                    SetGetPermit(false);
                    SetGetFinish(false);
                }

                Serialize();

                //放货完成
                if (CurrentTask != null && PutFinish
                    && Auto && !Local && !ManualControl && !Alarm
                    && CurrentTask.TravelPos2 > TravelPos - 10
                    && CurrentTask.TravelPos2 < TravelPos + 10
                    && CurrentTask.RealLiftPos2 > LiftPos - 10
                    && CurrentTask.RealLiftPos2 < LiftPos + 10)
                {
                    if (!CurrentTask.PutFinish)
                    {
                        if (CurrentTask.HasPutRequest)
                        {
                            if (FinishPut())
                            {
                                CurrentTask.PutFinish = true;
                            }
                        }
                        else
                        {
                            CurrentTask.PutFinish = true;
                        }
                    }
                }

                if (CurrentTask != null && CurrentTask.PutFinish)
                {
                    SetPutRequest(false);
                    SetPutPermit(false);
                    SetPutFinish(false);
                }
                if (CurrentTask == null)
                {
                    SetPutRequest(false);
                    SetPutPermit(false);
                    SetPutFinish(false);
                }

                Serialize();

                //任务完成
                if (CurrentTask != null && TaskFinish
                    && Auto && !Local && !ManualControl && !Alarm
                    && CurrentTask.GetFinish
                    && CurrentTask.PutFinish
                    && CurrentTask.TravelPos2 > TravelPos - 10
                    && CurrentTask.TravelPos2 < TravelPos + 10
                    && CurrentTask.RealLiftPos2 > LiftPos - 10
                    && CurrentTask.RealLiftPos2 < LiftPos + 10
                    && FinishCurrentTask())
                {
                    CurrentTask = null;
                }

                Serialize();
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("SRM ：{0} Execute 出错，原因详情：{1}{2}", Name, ex.Message, ex.StackTrace));
            }
        }


        public void SetAuto(bool isAuto)
        {
            try
            {
                if (ConnectState == true)
                {
                    Ops.Write(Name, "b_O_Auto", isAuto);
                }
                else
                {
                    Logger.Error(string.Format("SRM ：{0} SetAuto 出错,与堆垛机的连接不正常！", Name));
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("SRM ：{0} SetAuto 出错，原因详情：{1}{2}", Name, ex.Message, ex.StackTrace));
            }
        }

        public void Reset()
        {
            try
            {
                if (ConnectState == true)
                {
                    Ops.Write(Name, "b_O_Reset", true);
                }
                else
                {
                    Logger.Error(string.Format("SRM ：{0} Reset 出错,与堆垛机的连接不正常！", Name));
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("SRM ：{0} Reset 出错，原因详情：{1}{2}", Name, ex.Message, ex.StackTrace));
            }
        }

        protected virtual void Send()
        {
            try
            {
                if (CurrentTask != null && !CurrentTask.IsSent)
                {
                    if (SetCancelTask())
                    {
                        int[] position1 = new int[2];
                        position1[0] = CurrentTask.TravelPos1;
                        position1[1] = CurrentTask.LiftPos1;

                        //取货
                        int[] type1 = new int[1];
                        type1[0] = CurrentTask.CurrentPositionExtension + 1;

                        int[] position2 = new int[2];
                        position2[0] = CurrentTask.TravelPos2;
                        position2[1] = CurrentTask.RealLiftPos2;

                        //放货
                        int[] type2 = new int[1];
                        type2[0] = CurrentTask.NextPositionExtension + 2;

                        Ops.Write(Name, "n_O_Task_Data_Position1", position1);
                        Ops.Write(Name, "n_O_Task_Data_Type1", type1[0]);
                        Ops.Write(Name, "n_O_Task_Data_Position2", position2);
                        Ops.Write(Name, "n_O_Task_Data_Type2", type2[0]);
                        Ops.Write(Name, "b_O_New_Task", true);

                        CurrentTask.IsSent = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("SRM ：{0} Send 出错，原因详情：{1}{2}", Name, ex.Message, ex.StackTrace));
            }
        }

        public virtual void Resend(out string msg)
        {
            try
            {
                if (!ConnectState)
                {
                    msg = "与堆垛机连接已断开,无法重发！";
                    return;
                }

                if (!ForkZero)
                {
                    msg = "堆垛机货叉不在原点,无法重发！";
                    return;
                }

                if (CurrentTask == null || !CurrentTask.IsSent)
                {
                    msg = "当前任务不存在或未发送,无法重发！";
                    return;
                }

                if (SetCancelTask())
                {
                    int[] position1 = new int[2];
                    position1[0] = CurrentTask.TravelPos1;
                    position1[1] = CurrentTask.LiftPos1;

                    //取货
                    int[] type1 = new int[1];
                    type1[0] = CurrentTask.CurrentPositionExtension + 1;

                    if (CurrentTask.GetFinish)
                    {
                        position1[0] = CurrentTask.TravelPos2;
                        position1[1] = CurrentTask.RealLiftPos2;
                        //无操作
                        type1[0] = 0;
                    }

                    int[] position2 = new int[2];
                    position2[0] = CurrentTask.TravelPos2;
                    position2[1] = CurrentTask.RealLiftPos2;

                    //放货
                    int[] type2 = new int[1];
                    type2[0] = CurrentTask.NextPositionExtension + 2;

                    Ops.Write(Name, "n_O_Task_Data_Position1", position1);
                    Ops.Write(Name, "n_O_Task_Data_Type1", type1[0]);
                    Ops.Write(Name, "n_O_Task_Data_Position2", position2);
                    Ops.Write(Name, "n_O_Task_Data_Type2", type2[0]);
                    Ops.Write(Name, "b_O_New_Task", true);

                    CurrentTask.PutFinish = false;
                    msg = "当前任务已重发！";
                }
                else
                {
                    msg = "当前任务重发失败！";
                }
            }
            catch (Exception ex)
            {
                msg = string.Format("SRM ：{0} Resend 出错，原因详情：{1}{2}", Name, ex.Message, ex.StackTrace);
                Logger.Error(msg);
            }
        }
        
        public virtual void Cancel(out string msg)
        {
            try
            {
                if (!ConnectState)
                {
                    msg = "与堆垛机连接已断开,无法取消任务！";
                    return;
                }

                if (!ForkZero)
                {
                    msg = "堆垛机货叉不在原点,无法取消！";
                    return;
                }

                if (CurrentTask != null && !CurrentTask.GetFinish && !CurrentTask.PutFinish)
                {
                    if (SetCancelTask() && CancelCurrentTask())
                    {
                        CurrentTask = null;
                        msg = "当前任务已取消！";
                    }
                    else
                    {
                        msg = "取消失败！";
                    }
                }
                else if (CurrentTask == null)
                {
                    if (SetCancelTask())
                    {
                        msg = "当前任务已取消！";
                    }
                    else
                    {
                        msg = "取消失败！";
                    }
                }
                else if (CurrentTask != null && CurrentTask.GetFinish)
                {
                    msg = "当前任务已取货完成，请处理完故障后选择重发任务！";
                }
                else
                {
                    msg = "当前任务状态错误无法取消！";
                }
            }
            catch (Exception ex)
            {
                msg = string.Format("SRM ：{0} Cancel 出错，原因详情：{1}{2}", Name, ex.Message, ex.StackTrace);
                Logger.Error(msg);
            }
        }
  
        
        protected abstract SRMTask ApplyNewTask();

        protected abstract bool FinishCurrentTask();

        protected abstract bool CancelCurrentTask();


        protected virtual bool CheckIsPermitGet()
        {
            try
            {
                int[] data = new int[] { Convert.ToInt32(CurrentTask.CurrentPositionName), Convert.ToInt32(CurrentTask.ID), 1 };
                int[] states = Ops.ReadArray<int>(PartnerName, "n_O_Get_Request");
                if (states != null
                    && states.Length == 3
                    && states[0] == data[0]
                    && states[1] == data[1]
                    && states[2] == data[2])
                {
                    states = Ops.ReadArray<int>(PartnerName, "n_I_Get_Permit");
                    if (states != null && states.Any(s => s == Convert.ToInt32(CurrentTask.CurrentPositionName)))
                    {
                        return true;
                    }
                }
                else if (states != null
                    && states.Length == 3
                    && states[2] == 0)
                {
                    if (Ops.Write(PartnerName, "n_O_Get_Request", data))
                    {
                        states = Ops.ReadArray<int>(PartnerName, "n_I_Get_Permit");
                        if (states != null && states.Any(s => s == Convert.ToInt32(CurrentTask.CurrentPositionName)))
                        {
                            return true;
                        }
                        states = Ops.ReadArray<int>(PartnerName, "n_I_Get_Permit");
                        if (states != null && states.Any(s => s == Convert.ToInt32(CurrentTask.CurrentPositionName)))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("SRM ：{0} CheckIsPermitGet 出错，原因详情：{1}{2}", Name, ex.Message, ex.StackTrace));
                return false;
            }
        }

        protected virtual bool CheckIsPermitPut()
        {
            try
            {
                int[] data = new int[] { Convert.ToInt32(CurrentTask.NextPositionName) };
                int[] states = Ops.ReadArray<int>(PartnerName, "n_O_Put_Request");
                if (states != null
                    && states.Length == 1
                    && states[0] == data[0])
                {
                    states = Ops.ReadArray<int>(PartnerName, "n_I_Put_Permit");
                    if (states != null && states.Any(s => s == Convert.ToInt32(CurrentTask.NextPositionName)))
                    {
                        return true;
                    }
                }
                else if (states != null
                    && states.Length == 1
                    && states[0] == 0)
                {
                    if (Ops.Write(PartnerName, "n_O_Put_Request", data))
                    {
                        states = Ops.ReadArray<int>(PartnerName, "n_I_Put_Permit");
                        if (states != null && states.Any(s => s == Convert.ToInt32(CurrentTask.NextPositionName)))
                        {
                            return true;
                        }
                        states = Ops.ReadArray<int>(PartnerName, "n_I_Put_Permit");
                        if (states != null && states.Any(s => s == Convert.ToInt32(CurrentTask.NextPositionName)))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("SRM ：{0} CheckIsPermitPut 出错，原因详情：{1}{2}", Name, ex.Message, ex.StackTrace));
                return false;
            }
        }

        protected virtual bool FinishGet()
        {
            try
            {
                if (CurrentTask != null)
                {
                    //取货完成[位置，任务号，标志]
                    int[] data = new int[] { Convert.ToInt32(CurrentTask.CurrentPositionName), Convert.ToInt32(CurrentTask.ID), 1 };

                    Ops.Write(PartnerName, "n_O_Get_Complete", data);
                    Logger.Info("getFinish : " + data.ConvertToString());
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("SRM ：{0} FinishGet 出错，原因详情：{1}{2}", Name, ex.Message, ex.StackTrace));
                return false;
            }            
        }

        protected virtual bool FinishPut()
        {
            try
            {
                if (CurrentTask != null)
                {
                    //放货完成[位置，任务号，任务类型，卷烟条码，总数量，任务数量，长，宽，高，目标位置，标志]
                    int[] data = new int[] { Convert.ToInt32(CurrentTask.NextPositionName),
                        Convert.ToInt32(CurrentTask.ID), Convert.ToInt32(CurrentTask.TaskType),
                        Convert.ToInt32(CurrentTask.Barcode),CurrentTask.Quantity,CurrentTask.TaskQuantity,
                        CurrentTask.Length,CurrentTask.Width,CurrentTask.Height,
                        Convert.ToInt32(CurrentTask.NextTwoPositionName),1 };

                    Ops.Write(PartnerName, "n_O_Put_Complete", data);
                    Logger.Info("putFinish : " + data.ConvertToString());
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("SRM ：{0} FinishPut 出错，原因详情：{1}{2}", Name, ex.Message, ex.StackTrace));
                return false;
            } 
        }

        private void SetGetRequest(bool isPermit)
        {
            Ops.Write(Name, "b_I_Get_Request", isPermit);
        }

        private void SetPutRequest(bool isPermit)
        {
            Ops.Write(Name, "b_I_Put_Request", isPermit);
        }

        private void SetGetPermit(bool isPermit)
        {
            Ops.Write(Name, "b_O_Get_Permit", isPermit);
        }

        private void SetPutPermit(bool isPermit)
        {
            Ops.Write(Name, "b_O_Put_Permit", isPermit);
        }

        private void SetGetFinish(bool isFinish)
        {
            Ops.Write(Name, "b_I_Get_Finish", isFinish);
        }

        private void SetPutFinish(bool isFinish)
        {
            Ops.Write(Name, "b_I_Put_Finish", isFinish);
        }

        private bool SetCancelTask()
        {
            try
            {
                Ops.Write(Name, "b_O_Cancel_Task", true);

                SetGetPermit(false);
                SetGetFinish(false);
                SetPutPermit(false);
                SetPutFinish(false);

                //取货完成[位置，任务号，标志]
                int[] data = new int[] { 0, 0, 1 };
                Ops.Write(PartnerName, "n_O_Get_Complete", data);

                //放货完成[位置，任务号，任务类型，卷烟条码，总数量，任务数量，长，宽，高，目标位置，标志]
                data = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
                Ops.Write(PartnerName, "n_O_Put_Complete", data);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("SRM ：{0} CancelTask 出错，原因详情：{1}{2}", Name, ex.Message, ex.StackTrace));
                return false;
            }
        }       


        public virtual void Serialize()
        {
            if (!Parameter.ContainsKey("CurrentTask"))
            {
                Parameter.Add("CurrentTask", CurrentTask);
            }
            else
            {
                Parameter["CurrentTask"] = CurrentTask;
            }
            SerializableUtil.Serialize(GetSerializeParameterFilePath(), Parameter);
        }

        public virtual void Deserialize()
        {
            Parameter = SerializableUtil.Deserialize<Dictionary<string, object>>(GetSerializeParameterFilePath());
        }

        protected string GetSerializeParameterFilePath()
        {
            var directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            return Path.Combine(directory, "Serialize", "SRM", Name + ".Parameter.Serialize");
        }        

        public void OnImportsSatisfied()
        {
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            Release();
        }


        public override string ToString()
        {
            if (CurrentTask != null)
            {
                return string.Format("SRM：{0} [{1}]", Name, CurrentTask.ToString());
            }

            return string.Format("SRM：{0}", Name);
        }
    }
}
