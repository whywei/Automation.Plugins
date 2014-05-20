using System;
using Automation.Core;
using Automation.Plugins.MDJ.WCS.Dal;
using Automation.Plugins.MDJ.WCS.Rest;

namespace Automation.Plugins.MDJ.WCS.Process.Pallet
{
    public class EmptyPalletStackRequestProcess : AbstractProcess
    {
        private const string plcServiceName = "THOKPLC";
        private const string I_Empty_Pallet_Stack_Request = "I_Empty_Pallet_Stack_Request";
        private const string O_Empty_Pallet_Stack_Process_Complete = "O_Empty_Pallet_Stack_Process_Complete";

        public override void Initialize()
        {
            Description = "处理空托盘叠垛请求";
            base.Initialize();
        }

        //拆垛完成后生成，请求生成叠空托盘任务；
        public override void Execute()
        {
            try
            {
                object state = AutomationContext.Read(plcServiceName, I_Empty_Pallet_Stack_Request);
                object obj = ObjectUtil.GetObject(state);
                string positionName = obj != null ? obj.ToString() : "";

                if (positionName != string.Empty && positionName != "0")
                {
                    RestClient rest = new RestClient();
                    if (rest.CreateNewTaskForEmptyPalletStack(positionName))
                    {
                        AutomationContext.Write(plcServiceName, O_Empty_Pallet_Stack_Process_Complete, Convert.ToInt32(positionName));
                        Logger.Info(string.Format("EmptyPalletStackRequest : 位置[{0}]生成叠托盘任务成功！", positionName));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("EmptyPalletStackRequestProcess 出错，原因：" + ex.Message + "/n" + ex.StackTrace);
            }
        }
    }
}