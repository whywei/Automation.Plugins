using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Plugins.Share.Sorting.Dal;
using System.Data;
using DBRabbit;

namespace Automation.Plugins.Share.Sorting.Process
{
    public class SortOrderInformationProcess : AbstractProcess
    {
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
                bool isStart = Ops.ReadSingle<bool>(Global.MemoryTemporarilySingleDataService, Global.MemoryItemNameSortState);
                if (isStart)
                {
                    //A线
                    WriteSortOrderInformationToPLC(1);
                    //B线
                    // WriteSortOrderInformationToPLC(2);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("下单处理失败。原因：{0}。{1}。", ex.Message, ex.StackTrace));
            }
        }

        public void WriteSortOrderInformationToPLC(int groupNo)
        {
            string groupName = Enum.GetName(typeof(Group), groupNo);
            string sortOrderInformation = string.Format("Sort_Order_Information_{0}", groupName);
            int sign = Ops.ReadSingle<int>(Global.PLC_SERVICE_NAME, sortOrderInformation + "_Sign");

            if (sign != 0)
            {
                return;
            }

            using (TransactionScopeManager TM = new TransactionScopeManager(true, IsolationLevel.ReadCommitted))
            {
                sortingDal.TransactionScopeManager = TM;
                orderDal.TransactionScopeManager = TM;

                int[] writeData = new int[226];

                int maxPackNo = orderDal.FindMaxPackNo(groupNo);

                DataTable table = sortingDal.FindSortingInformation(groupNo);
                if (table.Rows.Count > 0)
                {
                    int i = 0;
                    foreach (DataRow row in table.Rows)
                    {
                        bool isEnd = Convert.ToInt32(row["pack_no"]) == maxPackNo 
                            && Convert.ToInt32(row["sort_no"]) == sortingDal.FindMaxSortNo(groupNo);

                        writeData[i++] = Convert.ToInt32(row["sort_no"]);
                        writeData[i++] = Convert.ToInt32(row["channel_address"]);
                        writeData[i++] = Convert.ToInt32(row["remain_quantity"]);
                        writeData[i++] = Convert.ToInt32(row["customer_order"]);
                        writeData[i++] = Convert.ToInt32(row["pack_no"]);
                        writeData[i++] = Convert.ToInt32(row["quantity"]);
                        writeData[i++] = Convert.ToInt32(row["export_no"]);
                        writeData[i++] = isEnd ? 1 : 0;
                        writeData[i++] = Convert.ToInt32(row["piece_barcode"]);

                        sortingDal.UpdateSoringStatus(row["sort_no"].ToString());
                        orderDal.UpdateMasterStatus(Convert.ToInt32(row["pack_no"]));
                    }

                    writeData[225] = 1;
                    
                    if (Ops.Write(Global.PLC_SERVICE_NAME, sortOrderInformation, writeData))
                    {
                        TM.Commit();
                        Logger.Info(string.Format("{0}线下单成功。数据[{1}]。", groupName,writeData.ConvertToString()));
                    }
                    else
                    {
                        Logger.Error(string.Format("{0}线下单失败。", groupName));
                    }
                }
            }
        }
    }
}
