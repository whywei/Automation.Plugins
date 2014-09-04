using System;
using System.Linq;
using Automation.Core;
using Automation.Plugins.Share.Stocking.Dal;
using System.Data;
using DBRabbit;

namespace Automation.Plugins.Share.Stocking.Process
{
    public class StockOutOrderProcess : AbstractProcess
    {
        public override void Initialize()
        {
            Description = "写出库订单线程";
            base.Initialize();
        }

        public override void Execute()
        {
            try
            {
                bool isStock = Ops.ReadSingle<bool>(Global.MemoryTemporarilySingleDataService, Global.MemoryItemNameStockState);
                int[] data = Ops.ReadArray<int>(Global.PLC_SERVICE_NAME, "Stock_Out_Order_Information");

                if (isStock == true && data != null && data.Length == 76 && data[75] == 0)
                {
                    using (TransactionScopeManager TM = new TransactionScopeManager(true, IsolationLevel.RepeatableRead))
                    {
                        StockTaskDal stockTaskDal = new StockTaskDal();
                        stockTaskDal.TransactionScopeManager = TM;
                        DataTable taskTable = stockTaskDal.FindUnStockTask();

                        int i = 0;
                        data = new int[76];

                        foreach (DataRow row in taskTable.Rows)
                        {
                            if (Convert.ToInt32(row["origin_position_address"]) > 0)
                            {
                                data[i++] = Convert.ToInt32(row["position_address"]);
                                data[i++] = Convert.ToInt32(row["target_supply_address"]);
                                data[i++] = Convert.ToInt32(row["product_barcode"]);
                                stockTaskDal.UpdateStockTaskStatus(row["id"].ToString());
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (i > 0)
                        {
                            data[75] = 1;
                            if (Ops.Write(Global.PLC_SERVICE_NAME, "Stock_Out_Order_Information", data))
                            {
                                TM.Commit();
                                Logger.Info(string.Format("写订单成功！数据【{0}】", data.ConvertToString()));
                            }
                        }
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
