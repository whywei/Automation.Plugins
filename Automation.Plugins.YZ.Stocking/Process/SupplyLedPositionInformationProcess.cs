using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Plugins.YZ.Stocking.Dal;
using System.Data;
using Automation.Service.LED;

namespace Automation.Plugins.YZ.Stocking.Process
{
    public class SupplyLedPositionInformationProcess : AbstractProcess
    {
        private Dictionary<int, int> ledGroup = new Dictionary<int, int>();
        public override void Initialize()
        {
            Description = "出库LED线程";
            base.Initialize();
            string[] ledList = Properties.Settings.Default.LED.Split(';');
            foreach (string led in ledList)
            {
                string[] ledInformation = led.Split(',');
                if (ledInformation.Length == 2)
                {
                    if (ledGroup.ContainsKey(Convert.ToInt32(ledInformation[0])))
                    {
                        ledGroup[Convert.ToInt32(ledInformation[0])] = Convert.ToInt32(ledInformation[1]);
                    }
                    else
                    {
                        ledGroup.Add(Convert.ToInt32(ledInformation[0]), Convert.ToInt32(ledInformation[1]));
                    }
                }
                else
                {
                    Logger.Error("LED配置错误！");
                }
            }
        }

        public override void Execute()
        {
            try
            {
                bool isStock = Ops.ReadSingle<bool>(Global.memoryServiceName_TemporarilySingleData, Global.memoryItemName_StockState);
                if (isStock == true)
                {
                    object obj = AutomationContext.Read(Global.plcServiceName, "Supply_Led_Position_Information");
                    Array array = (Array)obj;
                    for (int i = 0; i < array.Length / 2; i++)
                    {
                        int ledCode = Convert.ToInt32(array.GetValue(i * 2));
                        int quantity = Convert.ToInt32(array.GetValue(i * 2 + 1));
                        if (quantity > 0)
                        {
                            Show(ledCode, quantity);
                        }
                        else
                        {
                            Show(ledCode);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("刷新出库LED失败！原因：{0}。", ex.Message));
            }
        }

        private void Show(int ledCode, int quantity)
        {
            StockTaskDal stockTaskDal = new StockTaskDal();
            if (ledGroup.ContainsKey(ledCode))
            {
                int originPositionAddress = ledGroup[ledCode];
                DataTable taskTable = stockTaskDal.FindSupplyTaskForLED(originPositionAddress, quantity);
                DataRow[] taskRow = taskTable.Select("", "supply_id asc");
                List<LEDData> ledDataList = new List<LEDData>();
                for (int i = 0; i < taskRow.Length && i < 5; i++)
                {
                    ledDataList.Add(LEDDataFactory(ledCode, i, taskRow[i]["product_name"].ToString()));
                }
                Ops.Write("StockLED", "ShowData", ledDataList);
            }
            else
            {
                Logger.Error(string.Format("LED位置编号{0}，有在PLC中配置，但却没有在上位机中配置！", ledCode));
            }
        }

        private void Show(int ledCode)
        {
            List<LEDData> ledDataList = new List<LEDData>();
            ledDataList.Add(LEDDataFactory(ledCode, 0, "当前无补货任务！"));
            Ops.Write("StockLED", "ShowData", ledDataList);
        }

        private LEDData LEDDataFactory(int cardNum, int id, string name)
        {
            LEDData ledData = new LEDData();
            ledData.CardNum = cardNum;
            ledData.ColorFont = EQ2008.EQ2008.RED;
            ledData.Content = name;
            ledData.FontName = "宋体";
            ledData.X = 0;
            ledData.Y = id * 16;
            ledData.Width = 128;
            ledData.Height = 64;
            ledData.IsMove = true;
            ledData.MethodType = MethodType.AddSingleText;
            return ledData;
        }
    }
}
