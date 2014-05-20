using System;
using Automation.Plugins.MDJ.WCS.Dal;
using Automation.Core;
using Automation.Plugins.MDJ.WCS.Rest;

namespace Automation.Plugins.MDJ.WCS.Process.Pallet
{
    public class EmptyPalletSupplyRequestProcess : AbstractProcess
    {
        private const string plcServiceName = "THOKPLC";
        private const string I_Empty_Pallet_Supply_Request = "I_Empty_Pallet_Supply_Request";
        private const string O_Empty_Pallet_Supply_Process_Complete = "O_Empty_Pallet_Supply_Process_Complete";

        public override void Initialize()
        {
            Description = "处理空托盘出库请求";
            base.Initialize();
        }

        //需要空托盘出库时，请求生成空托盘出库任务；
        public override void Execute()
        {
            try
            {
                object state = AutomationContext.Read(plcServiceName, I_Empty_Pallet_Supply_Request);
                object obj = ObjectUtil.GetObject(state);
                string positionName = obj != null ? obj.ToString() : "";

                if (positionName != string.Empty && positionName != "0")
                {
                    RestClient rest = new RestClient();
                    if (rest.CreateNewTaskForEmptyPalletSupply(positionName))
                    {
                        AutomationContext.Write(plcServiceName, O_Empty_Pallet_Supply_Process_Complete, positionName);
                        Logger.Info(string.Format("EmptyPalletSupplyRequest : 位置[{0}] 生成托盘出库任务成功！", positionName));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("EmptyPalletSupplyRequestProcess 出错，原因：" + ex.Message + "/n" + ex.StackTrace);
            }
        }
    }
}