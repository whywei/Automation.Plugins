using System.ComponentModel;

namespace Automation.Plugins.Common.SRM
{
    public interface ISRM
    {
        [DescriptionAttribute("堆垛机名称")]
        string Name { get; set; }

        [DescriptionAttribute(@"堆垛机握手信号,3秒内握手信号未发生改变认为通讯中断")]
        bool HandShake { get; }

        [DescriptionAttribute("堆垛机连接状态")]
        bool ConnectState { get; }

        [DescriptionAttribute("堆垛机当前运行模式指示[1：自动模式；0：半自动模式]")]
        bool Auto { get;}
        [DescriptionAttribute("堆垛机就地模式指示")]
        bool Local { get; }
        [DescriptionAttribute("堆垛机手持控制器指示")]
        bool ManualControl { get; }

        [DescriptionAttribute("堆垛机报警状态指示")]
        bool Alarm { get; }
        [DescriptionAttribute("堆垛机警告状态指示")]
        bool Warning { get; }

        [DescriptionAttribute("堆垛机工作状态[0:空闲,无任务；1:等待,有任务；2:定位；3:取货；4:放货；98:维修；99:失效；100:自动]")]
        int State { get; }
        [DescriptionAttribute("堆垛机工作状态[0:空闲,无任务；1:等待,有任务；2:定位；3:取货；4:放货；98:维修；99:失效；100:自动]")]
        string StateName { get; }
        [DescriptionAttribute("堆垛机请求取货")]
        bool GetRequest { get;  }
        [DescriptionAttribute("堆垛机请求放货")]
        bool PutRequest { get;  }
        [DescriptionAttribute("堆垛机完成取货")]
        bool GetFinish { get; }
        [DescriptionAttribute("堆垛机完成放货")]
        bool PutFinish { get; }
        [DescriptionAttribute("堆垛机任务完成")]
        bool TaskFinish { get; }

        [DescriptionAttribute("堆垛机有货物")]
        bool Loaded { get; }
        [DescriptionAttribute("堆垛机当前行走位置，单位mm")]
        int TravelPos { get; }
        [DescriptionAttribute("堆垛机当前升降位置，单位mm")]
        int LiftPos { get; }

        [DescriptionAttribute("堆垛机货叉类型[0：单伸货叉；1：双伸货叉]")]
        int ForkType { get; }
        [DescriptionAttribute("堆垛机当前单伸货叉位置，单位mm[货叉向左位置为正值，货叉向右位置为负值]")]
        int ForkPosSingle { get; }
        [DescriptionAttribute("堆垛机当前双伸货叉位置，单位mm[货叉向左位置为正值，货叉向右位置为负值]")]
        int ForkPosDouble { get;}

        [DescriptionAttribute("堆垛机货叉处于原点位置")]
        bool ForkZero { get; }
        [DescriptionAttribute("堆垛机上叉左复位")]
        bool UpForkSWLeft { get; }
        [DescriptionAttribute("堆垛机上叉右复位")]
        bool UpForkSWRight { get; }
        [DescriptionAttribute("堆垛机货叉到达左侧限位")]
        bool ForkSWLeft { get; }
        [DescriptionAttribute("堆垛机货叉到达右侧限位")]
        bool ForkSWRight { get; }

        void Initialize();
        void Release();

        void FireHeartbeat();
        void Scan();
        void Execute();

        void SetAuto(bool auto);
        void Reset();
        void Resend(out string msg);
        void Cancel(out string msg);        
    }
}
