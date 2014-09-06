using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Plugins.Share.Sorting.Dal;
using System.Data;
using Automation.Service.LED;

namespace Automation.Plugins.Share.Sorting.Process
{
    public class LedInformationProcess : AbstractProcess
    {
        private ChannelDal channelDal = new ChannelDal();

        public override void Initialize()
        {
            Description = "LED屏信息处理线程";
            base.Initialize();
        }

        public override void Execute()
        {
            try
            {
                Show("A");
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("缺烟烟道LED线程处理失败！原因：{0}。", ex.Message));
            }
        }

        private void Show(string groupNo)
        {
            string itemName = "Lack_Cigarette_Channel_Information_" + groupNo;
            object obj = AutomationContext.Read(Global.PLC_SERVICE_NAME, itemName);
            List<string> channels = new List<string>();
            if (obj is Array)
            {
                Array channelAdressArray = (Array)obj;
                foreach (var channelAdress in channelAdressArray)
                {
                    if (channelAdress.ToString() != "0")
                    {
                        channels.Add(channelAdress.ToString());
                    }
                }
                DataTable channelTable = channelDal.FindCigaretteChannelInfo(groupNo == "A" ? 1 : 2);
                itemName = "Real_Time_Inventory_Data_" + groupNo;
                obj = AutomationContext.Read(Global.PLC_SERVICE_NAME, itemName);
                Array channelRemainQuantity = (Array)obj;
                LEDData[] ledDataList = new LEDData[channelTable.Rows.Count];
                for (int i = 0; i < channelTable.Rows.Count; i++)
                {
                    channelTable.Rows[i]["remain_quantity"] = channelRemainQuantity.GetValue(Convert.ToInt32(channelTable.Rows[i]["sort_address"]) - 1);
                    if (channels.Contains(channelTable.Rows[i]["sort_address"].ToString()))
                    {
                        ledDataList[i] = LEDDataFactory(channelTable.Rows[i], true);
                    }
                    else
                    {
                        ledDataList[i] = LEDDataFactory(channelTable.Rows[i], false);
                    }
                }
                Ops.Write(Global.LED_SERVICE_NAME, "ShowData", ledDataList);
            }
        }

        private LEDData LEDDataFactory(DataRow row, bool isLackChannel)
        {
            LEDData ledData = new LEDData();
            ledData.CardNum = Convert.ToInt32(row["led_no"]);
            ledData.ColorFont = isLackChannel ? EQ2008.EQ2008.GREEN : EQ2008.EQ2008.RED;
            ledData.Content = row["remain_quantity"].ToString() + "|" + row["product_name"].ToString();
            ledData.FontName = "@宋体";
            ledData.X = Convert.ToInt32(row["x"]);
            ledData.Y = Convert.ToInt32(row["y"]);
            ledData.Width = Convert.ToInt32(row["width"]);
            ledData.Height = Convert.ToInt32(row["height"]);
            ledData.IsMove = true;
            ledData.MethodType = MethodType.AddSingleText;
            return ledData;
        }
    }
}
