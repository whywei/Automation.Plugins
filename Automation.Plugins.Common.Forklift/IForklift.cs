using System.ComponentModel;

namespace Automation.Plugins.Common.Forklift
{
    public interface IForklift
    {
        [DescriptionAttribute("叉车名称")]
        string Name { get; set; }
        [DescriptionAttribute("叉车全称")]
        string FullName { get; set; }

        string PartnerName { get; set; }

        [DescriptionAttribute("叉车当前运行模式指示[1：自动模式；0：手动模式]")]
        bool Auto { get; set; }

        [DescriptionAttribute("叉车当前工作状态[0:空闲,无任务；1:等待,有任务；2:定位；3:取货；4:放货；]")]
        int State { get; }
        [DescriptionAttribute("叉车当前工作状态[0:空闲,无任务；1:等待,有任务；2:定位；3:取货；4:放货；]")]
        string StateName { get; }

        [DescriptionAttribute("叉车请求取货")]
        bool GetRequest { get; set; }
        [DescriptionAttribute("叉车请求放货")]
        bool PutRequest { get; set; }
        [DescriptionAttribute("叉车充许取货")]
        bool GetPermit { get; }
        [DescriptionAttribute("叉车充许放货")]
        bool PutPermit { get;}
        [DescriptionAttribute("叉车完成取货")]
        bool GetFinish { get; set; }
        [DescriptionAttribute("叉车完成放货")]
        bool PutFinish { get; set; }
        [DescriptionAttribute("叉车任务完成")]
        bool TaskFinish { get; set; }

        [DescriptionAttribute("堆垛机当前任务")]
        ForkliftTask CurrentTask { get;}

        void Initialize();
        void Release();

        void FireHeartbeat();
        void Execute();

        void SetAuto(bool auto);
        void Cancel(out string msg);        
    }
}
