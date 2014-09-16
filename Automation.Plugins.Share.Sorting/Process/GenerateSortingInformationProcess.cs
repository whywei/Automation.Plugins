using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using System.Data;
using Automation.Plugins.Share.Sorting.Dal;
using DBRabbit;

namespace Automation.Plugins.Share.Sorting.Process
{
    public class GenerateSortingInformationProcess : AbstractProcess
    {
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
                bool isStart = Ops.ReadSingle<bool>(Global.MemoryTemporarilySingleDataService, Global.MemoryItemNameSortState);
                if (isStart)
                {
                    //A线
                    int maxPackNo = orderDal.FindMaxPackNo(1);
                    InsertIntoSorting(1, maxPackNo);
                    //B线
                    //maxPackNo = orderDal.FindMaxPackNo(2);
                    //InsertIntoSorting(2, maxPackNo);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("生成下单数据失败！原因：{0}。明细：{1}。", ex.Message, ex.StackTrace));
            }
        }

        public void InsertIntoSorting(int groupNo, int maxPackNo)
        {
            do
            {
                SortingDal sortingDal = new SortingDal();
                DataTable unSortPackNoOnSorting = sortingDal.FindUnSortPackNo(groupNo);
                
                int packNo = sortingDal.FindMaxPackNo(groupNo);
                DataTable detailTable = orderDal.FindOrderDetailByPackNo(packNo, groupNo);
                if (unSortPackNoOnSorting.Rows.Count > 19 || detailTable.Rows.Count <= 0)
                    break;
                foreach (DataRow row in detailTable.Rows)
                {
                    int remainquantity = orderDal.FindRemainquantity(packNo, row["channel_code"].ToString());
                    int sortNo = sortingDal.FindMaxSortNo();
                    sortingDal.InsertIntoSorting(sortNo + 1, remainquantity, row);
                }
            }
            while (true);
        }
    }
}
