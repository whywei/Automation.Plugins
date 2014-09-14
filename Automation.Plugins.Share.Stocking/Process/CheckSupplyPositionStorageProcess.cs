using System;
using Automation.Core;
using Automation.Plugins.Share.Stocking.Rest;

namespace Automation.Plugins.Share.Stocking.Process
{
    public class CheckSupplyPositionStorageProcess : AbstractProcess
    {
        public override void Initialize()
        {
            Description = "检查拆盘位置库存线程";
            base.Initialize();  
        }

        public override void Execute()
        {
            try
            {
                bool isStock = Ops.ReadSingle<bool>(Global.MemoryTemporarilySingleDataService, Global.MemoryItemNameStockState);
                if (isStock == true)
                {
                    RestClient restClient = new RestClient();
                    restClient.CheckSupplyPositionStorage();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("检查拆盘位置库存失败！原因：{0}。", ex.Message));
            }
        }
    }
}
