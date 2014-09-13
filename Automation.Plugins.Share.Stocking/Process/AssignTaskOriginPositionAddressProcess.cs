using System;
using Automation.Core;
using Automation.Plugins.Share.Stocking.Rest;

namespace Automation.Plugins.Share.Stocking.Process
{
    public class AssignTaskOriginPositionAddressProcess : AbstractProcess
    {
        public override void Initialize()
        {
            Description = "分配补货任务出库位置线程";
            base.Initialize();  
        }

        public override void Execute()
        {
            try
            {
                RestClient restClient = new RestClient();
                restClient.AssignTaskOriginPositionAddress();
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("分配补货任务出库位置失败！原因：{0}。", ex.Message));
            }
        }
    }
}
