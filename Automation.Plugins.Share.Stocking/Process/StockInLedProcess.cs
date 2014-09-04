using System;
using Automation.Core;

namespace Automation.Plugins.Share.Stocking.Process
{
    public class StockInLedProcess : AbstractProcess
    {
        public override void Initialize()
        {
            Description = "刷入库LED线程";
            base.Initialize();  
        }

        public override void Execute()
        {
            try
            {
                bool isStock = Ops.ReadSingle<bool>(Global.MemoryTemporarilySingleDataService, Global.MemoryItemNameStockState);
                if (isStock == true)
                {
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("刷新出库LED失败！原因：{0}。", ex.Message));
            }
        }
    }
}
