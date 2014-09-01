using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Plugins.YZ.Sorting.Dal;
using System.Data;
using DBRabbit;

namespace Automation.Plugins.YZ.Sorting.Process
{
    public class PackageNumbersInformationProcess : AbstractProcess
    {
        private List<int> export = new List<int>() { 1, 2 };
        public override void Initialize()
        {
            Description = "分发包装数据线程";
            base.Initialize();
        }

        public override void Execute()
        {
            ExportPackDal exportPackDal = new ExportPackDal();
            OrderDal orderDal = new OrderDal();
            foreach (int item in export)
            {
                string itemName="Package_Numbers_Information_0"+item.ToString();
                int packNo = Ops.ReadSingle<int>(Global.plcServiceName, itemName);
                if (packNo > 0)
                { 
                    //包号不存在
                    if (!exportPackDal.PackNoIsExist(packNo))
                    {
                        using (TransactionScopeManager TM = new TransactionScopeManager(true, IsolationLevel.ReadCommitted))
                        {
                            exportPackDal.TransactionScopeManager = TM;
                            orderDal.TransactionScopeManager = TM;
                            //将数据导入包装机数据表
                            string condition = string.Format("WHERE A.pack_no={0}", packNo);
                            DataTable packData = orderDal.FindPackData(condition);
                            foreach (DataRow row in packData.Rows)
                            {
                                row["export_no"] = item;
                                exportPackDal.InsertIntoExportPack(row);
                            }
                            //更新完成时间
                            orderDal.UpdateFinishTime(packNo);
                            //换线处理
                            int maxPackNo = orderDal.FindMaxPackNoInDeliverLine(packNo);
                            if (packNo == maxPackNo)
                            {
                                if (Ops.Write(Global.plcServiceName, "Chang_Route_Sign", 1))
                                {
                                    TM.Commit();
                                }
                            }
                            else
                            {
                                TM.Commit();
                            }
                        }
                    }
                    Ops.Write(Global.plcServiceName, itemName, "0");
                }
            }
        }
    }
}
