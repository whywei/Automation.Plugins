using System;
using Automation.Core;
using System.Data;
using DBRabbit;

namespace Automation.Plugins.Share.Stocking.Process
{
    public class StockInOrderProcess : AbstractProcess
    {
        public override void Initialize()
        {
            Description = "写入库订单线程";
            base.Initialize();
        }

        public override void Execute()
        {
            try
            {
                bool isStock = Ops.ReadSingle<bool>(Global.MemoryTemporarilySingleDataService, Global.MemoryItemNameStockState);
                int[] data = Ops.ReadArray<int>(Global.PLC_SERVICE_NAME, "Stock_In_Order_Information");

                if (isStock == true && data != null && data.Length == 4 && data[3] == 0)
                {
                    using (TransactionScopeManager TM = new TransactionScopeManager(true, IsolationLevel.RepeatableRead))
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("写出库订单失败！原因：{0}。", ex.Message));
            }
        }
    }
}
