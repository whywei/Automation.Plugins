﻿using System;
using System.Collections.Generic;
using System.Linq;
using Automation.Core;
using Automation.Plugins.Share.Stocking.Dal;
using System.Data;
using Automation.Service.LED;
using Automation.Plugins.Share.Stocking.Properties;

namespace Automation.Plugins.Share.Stocking.Process
{
    public class SupplyLedPositionInformationProcess : AbstractProcess
    {
        private Dictionary<int, string> ledSqls = new Dictionary<int, string>();

        public override void Initialize()
        {
            Description = "刷出库LED线程";
            LoadLedConfig();
            base.Initialize();  
        }

        public override void Execute()
        {
            try
            {
               // bool isStock = Ops.ReadSingle<bool>(Global.MemoryTemporarilySingleDataService, Global.MemoryItemNameStockState);
                object obj = AutomationContext.Read(Global.MemoryTemporarilySingleDataService, Global.MemoryItemNameStockState);
                bool isStock = obj == null ? false : Convert.ToBoolean(obj);
                if (isStock == true)
                {
                    //var ledPositionInfo = Ops.ReadArray<int>(Global.PLC_SERVICE_NAME, "Supply_Led_Position_Information")
                    //    .ConvertToNewArray(2);

                    //foreach (var item in ledPositionInfo)
                    //{
                    //    int ledNo = item[0];
                    //    int quantity = item[1];
                    //    if (quantity > 0)
                    //    {
                    //        Show(ledNo, quantity);
                    //    }
                    //    else
                    //    {
                    //        Show(ledNo);
                    //    }
                    //}
                    obj = AutomationContext.Read(Global.PLC_SERVICE_NAME, "Supply_Led_Position_Information");
                    Array array = (Array)obj;
                    for (int i = 0; i < array.Length / 2; i++)
                    {
                        int ledNo = Convert.ToInt32(array.GetValue(i * 2));
                        int quantity = Convert.ToInt32(array.GetValue(i * 2 + 1));
                        if (quantity > 0)
                        {
                            Show(ledNo, quantity);
                        }
                        else
                        {
                            Show(ledNo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("刷新出库LED失败！原因：{0}。", ex.Message));
            }
        }

        private void Show(int ledNo, int quantity)
        {
            StockTaskDal stockTaskDal = new StockTaskDal();
            DataTable table = stockTaskDal.FindStockTaskForLED(ledSqls[ledNo], quantity);

            if (ledSqls.ContainsKey(ledNo))
            {
                DataRow[] taskRow = table.Select("", "id asc");
                LEDData[] ledDataList = new LEDData[taskRow.Length > 6 ? 6 : taskRow.Length];
                for (int i = 0; i < taskRow.Length && i < 6; i++)
                {
                    ledDataList[i] = CreateLEDData(ledNo, i, taskRow[i]["product_name"].ToString());
                }
                Ops.Write(Global.LED_SERVICE_NAME, "ShowData", ledDataList);
            }
            else
            {
                Logger.Error(string.Format("LED位置编号{0}，有在PLC中配置，但却没有在上位机中配置！", ledNo));
            }
        }

        private void Show(int ledCode)
        {
            LEDData[] ledDataList = new LEDData[1];
            ledDataList[0] = CreateLEDData(ledCode, 0, "当前无补货任务！");
            Ops.Write(Global.LED_SERVICE_NAME, "ShowData", ledDataList);
        }

        private LEDData CreateLEDData(int cardNum, int id, string name)
        {
            LEDData ledData = new LEDData();
            ledData.CardNum = cardNum;
            ledData.ColorFont = id == 0 ? EQ2008.EQ2008.GREEN : EQ2008.EQ2008.RED;
            ledData.Content = name;
            ledData.FontName = "宋体";
            ledData.SingleText.FontInfo.iFontSize = 9;
            ledData.X = 0;
            ledData.Y = id * 16;
            ledData.Width = 128;
            ledData.Height = 16;
            ledData.IsMove = false;
            ledData.MethodType = MethodType.AddSingleText;
            return ledData;
        }

        private void LoadLedConfig()
        {
            ledSqls = Settings.Default.LedSqls.AsEnumerable().ToDictionary(l => Convert.ToInt32(l.Split(':')[0]), l => l.Split(':')[1]);
        }
    }
}
