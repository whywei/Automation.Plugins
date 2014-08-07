using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using System.Data;
using Automation.Plugins.YZ.Sorting.Dal;

namespace Automation.Plugins.YZ.Sorting.Process
{
    public class GenerateSortingInformationProcess : AbstractProcess
    {
        private SortingDal sortingDal = new SortingDal();
        private OrderDal orderDal = new OrderDal();

        public override void Initialize()
        {
            Description = "生成下单数据线程";
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
                    int maxPackNo = orderDal.FindMaxPackNoFromMaster(1);
                    InsertIntoSorting(1, maxPackNo);
                    //B线
                    maxPackNo = orderDal.FindMaxPackNoFromMaster(2);
                    InsertIntoSorting(2, maxPackNo);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("生成下单数据失败！原因：{0}。明细：{1}。", ex.Message, ex.StackTrace));
            }
        }

        public void InsertIntoSorting(int groupNo, int maxPackNo)
        {
            int count = 0;
            do
            {
                DataTable unSortPackNoOnSorting = sortingDal.FindUnSortPackNo(groupNo);
                count = unSortPackNoOnSorting.Rows.Count;
                int packNo;
                if (count > 0)
                {
                    packNo = Convert.ToInt32(unSortPackNoOnSorting.Rows[0]["pack_no"]);
                }
                else
                {
                    packNo = sortingDal.FindMaxPackNo(groupNo);

                }
                if (packNo < maxPackNo)
                {
                    DataTable detailTable = orderDal.FindOrderDetailByPackNo(packNo, groupNo);
                    foreach (DataRow row in detailTable.Rows)
                    {
                        int sortNo = sortingDal.FindMaxSortNo();
                        sortingDal.InsertIntoSorting(sortNo + 1, row);
                    }
                }
                else
                {
                    break;
                }
            } while (count < 19);
        }
    }
}
