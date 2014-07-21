using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Plugins.YZ.Sorting.Dal;
using System.Data;

namespace Automation.Plugins.YZ.Sorting.Process
{
    public class SortOrderInformationProcess : AbstractProcess
    {
        private List<string> channelGroups = new List<string>() { "A", "B" };
        private SortingDal sortingDal = new SortingDal();
        private OrderDal orderDal = new OrderDal();

        public override void Initialize()
        {
            Description = "分拣订单信息处理线程";
            base.Initialize();
        }

        public override void Execute()
        {
            try
            {
                bool isStart = Ops.ReadSingle<bool>(Global.memoryServiceName_PSD, Global.memoryItemName_SortingState);
                if (isStart)
                {
                    int maxPackNo = orderDal.FindMaxPackNoFromMaster();
                    int sumQuantity = orderDal.FindSumQuantityFromMaster();
                    foreach (string item in channelGroups)
                    {
                        string sortOrderInformation = "Sort_Order_Information_" + item;
                        object readData =AutomationContext.Read(Global.plcServiceName, sortOrderInformation);
                        Array array = (Array)readData;
                        if (array.Length == 226)
                        {
                            string sign = array.GetValue(225).ToString();
                            if (sign == "0")
                            {
                                int groupNo = item == "A" ? 1 : item == "B" ? 2 : 0;
                                int[] writeData = new int[226];
                                int packNo = sortingDal.FindMinUnSortPackNo(groupNo);
                                if (packNo <= maxPackNo)
                                {
                                    DataTable table = sortingDal.FindSortingInformation(packNo, groupNo);
                                    if (table.Rows.Count > 0)
                                    {
                                        int i = 0;
                                        foreach (DataRow row in table.Rows)
                                        {
                                            writeData[i++] = Convert.ToInt32(row["sort_no"]);
                                            writeData[i++] = Convert.ToInt32(row["channel_address"]);
                                            writeData[i++] = Convert.ToInt32(row["remain_quantity"]);
                                            writeData[i++] = Convert.ToInt32(row["customer_order"]);
                                            writeData[i++] = Convert.ToInt32(row["pack_no"]);
                                            writeData[i++] = Convert.ToInt32(row["quantity"]);
                                            writeData[i++] = Convert.ToInt32(row["export_no"]);
                                            writeData[i++] = Convert.ToInt32(row["sort_no"]) == sumQuantity ? 1 : 0;
                                            writeData[i++] = Convert.ToInt32(row["product_code"]);
                                        }
                                        writeData[225] = 1;
                                        bool result = Ops.Write(Global.plcServiceName, sortOrderInformation, writeData);
                                        if (result)
                                        {
                                            string msg = "";
                                            foreach (int data in writeData)
                                            {
                                                msg += data.ToString() + ",";
                                            }
                                            Logger.Info(string.Format("{0}线下单成功。包号[{1}]，数据[{2}]。", item, packNo + 1, msg));
                                            //更新sorting表
                                            sortingDal.UpdateSoringStatus(packNo, groupNo);
                                            //更新主表状态
                                            orderDal.UpdateMasterStatus(packNo);
                                            //向sorting表加入数据
                                            int maxPackNoOnSorting = sortingDal.FindMaxPackNo();
                                            if ((packNo + 10) >= maxPackNoOnSorting && maxPackNoOnSorting <= maxPackNo)
                                            {
                                                DataTable detailTable = orderDal.FindOrderDetailByPackNo(maxPackNoOnSorting + 1);
                                                foreach (DataRow row in detailTable.Rows)
                                                {
                                                    int sortNo = sortingDal.FindMaxSortNo();
                                                    sortingDal.InsertIntoSorting(sortNo + 1, row);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Logger.Error(string.Format("{0}线下单失败。包号[{1}]。", item, packNo + 1));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("下单处理失败。原因：{0}。{1}。", ex.Message, ex.StackTrace));
            }
        }
    }
}
