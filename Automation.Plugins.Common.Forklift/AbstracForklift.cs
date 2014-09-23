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

namespace Automation.Plugins.Common.Forklift
{
    public abstract class AbstractForklift : IForklift, IPartImportsSatisfiedNotification
    {
        [DescriptionAttribute("叉车名称")]
        public string Name { get; set; }
        [DescriptionAttribute("叉车全称")]
        public string FullName { get; set; }

        public string PartnerName { get; set; }

        [DescriptionAttribute("叉车当前运行模式指示[1：自动模式；0：手动模式]")]
        public bool Auto { get; set; }

        [DescriptionAttribute("叉车当前工作状态[0:空闲,无任务；1:等待,有任务；2:定位；3:取货；4:放货；]")]
        public int State { get; set; }
        [DescriptionAttribute("叉车当前工作状态[0:空闲,无任务；1:等待,有任务；2:定位；3:取货；4:放货；]")]
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
                    default: return "未可识别状态";
                }
            }
        }

        [DescriptionAttribute("叉车请求取货")]
        public bool GetRequest { get; set; }
        [DescriptionAttribute("叉车请求放货")]
        public bool PutRequest { get; set; }
        [DescriptionAttribute("叉车充许取货")]
        public bool GetPermit { get; protected set; }
        [DescriptionAttribute("叉车充许放货")]
        public bool PutPermit { get; protected set; }
        [DescriptionAttribute("叉车完成取货")]
        public bool GetFinish { get; set; }
        [DescriptionAttribute("叉车完成放货")]
        public bool PutFinish { get; set; }
        [DescriptionAttribute("叉车任务完成")]
        public bool TaskFinish { get; set; }

        [DescriptionAttribute("堆垛机当前任务")]
        public ForkliftTask CurrentTask { get; protected set; }

        public ForkliftTask NextTask { get; private set; }

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
                        CurrentTask = Parameter["CurrentTask"] as ForkliftTask;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(string.Format("Forklift ：{0} 初始失败，原因详情：{1}{2}", Name, ex.Message, ex.StackTrace));
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
                    Logger.Error(string.Format("Forklift ：{0} 释放资源失败，原因详情:{1}{2}", Name, ex.Message, ex.StackTrace));
                }
            }
        }


        public virtual void FireHeartbeat()
        {
            this.Execute();
        }

        public virtual void Execute()
        {
            try
            {
                //请求新任务
                if (CurrentTask == null && Auto)
                {
                    CurrentTask = NextTask ?? ApplyNewTask();
                    NextTask = null;
                    State = 2;
                }

                if (CurrentTask != null && State == 2 && NextTask == null)
                {
                    NextTask = ApplyNewTask();
                }

                Serialize();

                //请求取货
                if (CurrentTask != null && GetRequest && Auto                     
                    && (!CurrentTask.HasGetRequest || CheckIsPermitGet()))
                {
                    SetGetPermit(true);
                    State = 3;
                }
  
                //请求放货
                if (CurrentTask != null && PutRequest && Auto)
                {
                    if (CurrentTask.GetFinish
                        && (!CurrentTask.HasPutRequest || CheckIsPermitPut()))
                    {
                        SetPutPermit(true);
                        State = 4;
                    }
                }

                //取货完成
                if (CurrentTask != null && GetFinish && Auto)
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
                        State = 2;
                    }
                }
                
                if (CurrentTask != null && CurrentTask.GetFinish)
                {
                    GetRequest = false;
                    SetGetPermit(false);
                    SetGetFinish(false);
                }
                if (CurrentTask == null)
                {
                    GetRequest = false;
                    SetGetPermit(false);
                    SetGetFinish(false);
                }

                Serialize();

                //放货完成
                if (CurrentTask != null && PutFinish && Auto)
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
                        State = 1;
                    }
                }

                if (CurrentTask != null && CurrentTask.PutFinish)
                {
                    PutRequest = false;
                    SetPutPermit(false);
                    SetPutFinish(false);
                }
                if (CurrentTask == null)
                {
                    PutRequest = false;
                    SetPutPermit(false);
                    SetPutFinish(false);
                }

                Serialize();

                //任务完成
                if (CurrentTask != null && TaskFinish && Auto 
                    && CurrentTask.GetFinish
                    && CurrentTask.PutFinish
                    && FinishCurrentTask())
                {
                    CurrentTask = null;
                    TaskFinish = false;
                    State = 0;
                }

                Serialize();
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("Forklift ：{0} Execute 出错，原因详情：{1}{2}", Name, ex.Message, ex.StackTrace));
            }
        }


        public void SetAuto(bool isAuto)
        {
            try
            {
                Auto = isAuto;
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("Forklift ：{0} SetAuto 出错，原因详情：{1}{2}", Name, ex.Message, ex.StackTrace));
            }
        }
        
        public virtual void Cancel(out string msg)
        {
            try
            {
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
                msg = string.Format("Forklift ：{0} Cancel 出错，原因详情：{1}{2}", Name, ex.Message, ex.StackTrace);
                Logger.Error(msg);
            }
        }
  
        
        protected abstract ForkliftTask ApplyNewTask();

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
                    Ops.Write(PartnerName, "n_O_Get_Request", data);
                }
                return false;
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("Forklift ：{0} CheckIsPermitGet 出错，原因详情：{1}{2}", Name, ex.Message, ex.StackTrace));
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
                    Ops.Write(PartnerName, "n_O_Put_Request", data);
                }
                return false;
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("Forklift ：{0} CheckIsPermitPut 出错，原因详情：{1}{2}", Name, ex.Message, ex.StackTrace));
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
                Logger.Error(string.Format("Forklift ：{0} FinishGet 出错，原因详情：{1}{2}", Name, ex.Message, ex.StackTrace));
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
                Logger.Error(string.Format("Forklift ：{0} FinishPut 出错，原因详情：{1}{2}", Name, ex.Message, ex.StackTrace));
                return false;
            } 
        }


        private void SetGetPermit(bool isPermit)
        {
            GetPermit = isPermit;
        }

        private void SetPutPermit(bool isPermit)
        {
            PutPermit = isPermit;
        }

        private void SetGetFinish(bool isFinish)
        {
            GetFinish = isFinish;
        }

        private void SetPutFinish(bool isFinish)
        {
            PutFinish = isFinish;
        }

        private bool SetCancelTask()
        {
            try
            {
                GetRequest = false;
                PutRequest = false;

                SetGetPermit(false);
                SetGetFinish(false);
                SetPutPermit(false);
                SetPutFinish(false);

                //取货完成[位置，任务号，标志]
                int[] data = new int[] { 0, 0, 1 };
                Ops.Write(PartnerName, "n_O_Get_Complete", data);
                Logger.Info("cancelTask : " + data.ConvertToString());

                //放货完成[位置，任务号，任务类型，卷烟条码，总数量，任务数量，长，宽，高，目标位置，标志]
                data = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
                Ops.Write(PartnerName, "n_O_Put_Complete", data);
                Logger.Info("cancelTask : " + data.ConvertToString());
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("Forklift ：{0} CancelTask 出错，原因详情：{1}{2}", Name, ex.Message, ex.StackTrace));
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
            return Path.Combine(directory, "Serialize", "Forklift", Name + ".Parameter.Serialize");
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
                return string.Format("Forklift：{0} [{1}]", Name, CurrentTask.ToString());
            }

            return string.Format("Forklift：{0}", Name);
        }
    }
}
