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
                    maxPackNo = orderDal.FindMaxPackNo(2);
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
                using (TransactionScopeManager TM = new TransactionScopeManager(true, IsolationLevel.ReadCommitted))
                {
                    SortingDal sortingDal = new SortingDal();
                    sortingDal.TransactionScopeManager = TM;

                    DataTable unSortPackNoOnSorting = sortingDal.FindUnSortPackNo(groupNo);
                    count = unSortPackNoOnSorting.Rows.Count;

                    int packNo = sortingDal.FindMaxPackNo(groupNo);
                    DataTable detailTable = orderDal.FindOrderDetailByPackNo(packNo, groupNo);

                    foreach (DataRow row in detailTable.Rows)
                    {
                        int sortNo = sortingDal.FindMaxSortNo();
                        sortingDal.InsertIntoSorting(sortNo + 1, row);
                    }

                    TM.Commit();
                }
            } while (count < 19);
        }
    }
}
