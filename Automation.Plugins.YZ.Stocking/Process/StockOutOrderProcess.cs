using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Plugins.YZ.Stocking.Dal;
using System.Data;
using DBRabbit;

namespace Automation.Plugins.YZ.Stocking.Process
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
                bool isStock = Ops.ReadSingle<bool>(Global.memoryServiceName_TemporarilySingleData, Global.memoryItemName_StockState);
                if (isStock == true)
                {
                    object obj = AutomationContext.Read(Global.plcServiceName, "Stock_Out_Order_Information");
                    Array array = (Array)obj;
                    if (array.Length == 76 && array.GetValue(75).ToString() == "0")
                    {
                        WriteDataToPLC();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("写出库订单失败！原因：{0}。", ex.Message));
            }
        }

        private void WriteDataToPLC()
        {
            using (TransactionScopeManager TM = new TransactionScopeManager(true, IsolationLevel.RepeatableRead))
            {
                //获取补货数据
                StockTaskDal stockTaskDal = new StockTaskDal();
                StockPositionDal stockPositionDal = new StockPositionDal();
                stockTaskDal.TransactionScopeManager = TM;
                stockPositionDal.TransactionScopeManager = TM;
                DataTable taskTable = stockTaskDal.FindUnStockTask();
                int[] data = new int[76];
                int i = 0;
                foreach (DataRow row in taskTable.Rows)
                {
                    //获取卷烟对应的拆盘位置信息
                    DataTable productPositionTable = stockPositionDal.FindStockPositionByProduct(row["product_code"].ToString());
                    if (productPositionTable.Rows.Count <= 0)
                    {
                        DataTable mixPositionTable = stockPositionDal.FindMixStockPosition();
                        if (mixPositionTable.Rows.Count <= 0)
                        {
                            Logger.Error("发现有烟没有拆盘位，且当前没有配置混合拆盘位！");
                            break;
                        }
                        else
                        {
                            data[i++] = Convert.ToInt32(mixPositionTable.Rows[0]["position_address"]);
                            data[i++] = Convert.ToInt32(row["target_supply_address"]);
                            data[i++] = Convert.ToInt32(row["product_barcode"]);
                            row["origin_position_address"] = Convert.ToInt32(mixPositionTable.Rows[0]["position_address"]);
                            row["status"] = "1";
                        }
                    }
                    else
                    {
                        int j = 0;
                        foreach (DataRow productRow in productPositionTable.Rows)
                        {
                            if (Convert.ToInt32(productRow["quantity"]) > 0)
                            {
                                data[i++] = Convert.ToInt32(productRow["position_address"]);
                                data[i++] = Convert.ToInt32(row["target_supply_address"]);
                                data[i++] = Convert.ToInt32(row["product_barcode"]);
                                row["origin_position_address"] = Convert.ToInt32(productRow["position_address"]);
                                row["status"] = "1";
                                row["storageId"] = productRow["id"];
                                break;
                            }
                            j++;
                        }
                        if (j == productPositionTable.Rows.Count)
                        {
                            break;
                        }
                    }
                }
                if (data[0] > 0)
                {
                    data[75] = 1;
                    //更新状态
                    foreach (DataRow row in taskTable.Rows)
                    {
                        if (Convert.ToInt32(row["status"]) > 0)
                        {
                            stockTaskDal.UpdateSupplyTask(row["id"].ToString(), row["origin_position_address"].ToString());
                            if (Convert.ToInt32(row["storageId"]) > 0)
                            {
                                stockPositionDal.UpdateSupplyPositionStorage(row["storageId"].ToString());
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    //将数据写到PLC
                    if (Ops.Write(Global.plcServiceName, "Stock_Out_Order_Information", data))
                    {
                        TM.Commit();
                        //将订单数据写入日志
                        string msg = "";
                        foreach (var item in data)
                        {
                            msg += item + ",";
                        }
                        Logger.Info(string.Format("写订单成功！数据【{0}】", msg.Substring(0, msg.Length - 1)));
                    }
                }
            }
        }
    }
}
