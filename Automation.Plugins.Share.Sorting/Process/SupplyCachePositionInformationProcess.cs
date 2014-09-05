using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Plugins.Share.Sorting.Rest;

namespace Automation.Plugins.Share.Sorting.Process
{
    public class SupplyCachePositionInformationProcess : AbstractProcess
    {
        string[] supplyCachePositionList = null;
        public override void Initialize()
        {
            Description = "生成补货计划";
            base.Initialize();
            string strPosition = Properties.Settings.Default.Supply_Cache_Position.Trim();
            if (strPosition.Length <= 0)
            {
                Logger.Error("没有读到补货缓存位置编号，请配置！");
            }
            else
            {
               supplyCachePositionList = strPosition.Split(',');
            }
        }

        public override void Execute()
        {
            try
            {
                object obj = AutomationContext.Read(Global.PLC_SERVICE_NAME, "Supply_Cache_Position_Information");
                Array array = (Array)obj;
                for (int i = 0; i < array.Length / 2; i++)
                {
                    string position = array.GetValue(i * 2).ToString();
                    int quantity = Convert.ToInt32(array.GetValue(i * 2 + 1));
                    if (supplyCachePositionList.Contains(position) && quantity > 0)
                    {
                        RestClient restClient = new RestClient();
                        restClient.CreateNewSupplyTask(position, quantity);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("生成补货计划失败！原因：{0}。", ex.Message));
            }
        }
    }
}
