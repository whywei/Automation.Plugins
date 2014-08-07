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
                bool isStart = Ops.ReadSingle<bool>(Global.memoryServiceName_TemporarilySingleData, Global.memoryItemName_SortingState);
                if (isStart)
                {
                    //A线
                    WriteSortOrderInformationToPLC(1);
                    //B线
                    WriteSortOrderInformationToPLC(2);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("下单处理失败。原因：{0}。{1}。", ex.Message, ex.StackTrace));
            }
        }

        public void WriteSortOrderInformationToPLC(int groupNo)
        {
            string sortOrderInformation = "Sort_Order_Information_" + (groupNo == 1 ? "A" : groupNo == 2 ? "B" : "");
            object readData = AutomationContext.Read(Global.plcServiceName, sortOrderInformation);
            Array array = (Array)readData;
            if (array.Length == 226)
            {
                string sign = array.GetValue(225).ToString();
                if (sign == "0")
                {
                    int[] writeData = new int[226];
                    int packNo = sortingDal.FindMinUnSortPackNo(groupNo);
                    int maxPackNo = orderDal.FindMaxPackNoFromMaster(groupNo);
                    if (packNo > 0 && packNo <= maxPackNo)
                    {
                        int maxSortNo = -1;
                        if (packNo == maxPackNo)
                        {
                            maxSortNo = sortingDal.FindMaxSortNo(groupNo);
                        }
                        DataTable table = sortingDal.FindSortingInformation(groupNo);
                        if (table.Rows.Count > 0)
                        {
                            int i = 0;
                            string sortNos = "-1,";
                            foreach (DataRow row in table.Rows)
                            {
                                sortNos += row["sort_no"].ToString() + ",";
                                writeData[i++] = Convert.ToInt32(row["sort_no"]);
                                writeData[i++] = Convert.ToInt32(row["channel_address"]);
                                writeData[i++] = Convert.ToInt32(row["remain_quantity"]);
                                writeData[i++] = Convert.ToInt32(row["customer_order"]);
                                writeData[i++] = Convert.ToInt32(row["pack_no"]);
                                writeData[i++] = Convert.ToInt32(row["quantity"]);
                                writeData[i++] = Convert.ToInt32(row["export_no"]);
                                writeData[i++] = Convert.ToInt32(row["sort_no"]) == maxSortNo ? 1 : 0;
                                writeData[i++] = Convert.ToInt32(row["piece_barcode"]);
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
                                Logger.Info(string.Format("{0}线下单成功。包号[{1}]，数据[{2}]。", groupNo == 1 ? "A" : groupNo == 2 ? "B" : "", packNo, msg));
                                //更新sorting表
                                sortNos = sortNos.Substring(0, sortNos.Length - 1);
                                sortingDal.UpdateSoringStatus(sortNos);
                                //更新主表状态
                                int isSortMaxPackNo = sortingDal.FindIsSortMaxPackNo(groupNo);
                                orderDal.UpdateMasterStatus(isSortMaxPackNo);
                            }
                            else
                            {
                                Logger.Error(string.Format("{0}线下单失败。包号[{1}]。", groupNo == 1 ? "A" : groupNo == 2 ? "B" : "", packNo + 1));
                            }
                        }
                    }
                }
            }
        }
    }
}
