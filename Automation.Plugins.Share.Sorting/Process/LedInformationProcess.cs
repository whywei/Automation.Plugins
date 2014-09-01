using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;
using Automation.Plugins.YZ.Sorting.Dal;
using System.Data;
using Automation.Service.LED;

namespace Automation.Plugins.YZ.Sorting.Process
{
    public class LedInformationProcess : AbstractProcess
    {
        private List<string> groupNos = new List<string> { "A", "B" };
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
                foreach (var groupNo in groupNos)
                {
                    string itemName = "Lack_Cigarette_Channel_Information_" + groupNo;
                    object obj = AutomationContext.Read(Global.plcServiceName, itemName);
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
                        obj = AutomationContext.Read(Global.plcServiceName, itemName);
                        Array channelRemainQuantity = (Array)obj;
                        List<LEDData> ledDataList = new List<LEDData>();
                        foreach (DataRow row in channelTable.Rows)
                        {
                            row["remain_quantity"] = channelRemainQuantity.GetValue(Convert.ToInt32(row["sort_address"]) - 1);
                            if (channels.Contains(row["sort_address"].ToString()))
                            {
                                ledDataList.Add(LEDDataFactory(row, true));
                            }
                            else
                            {
                                ledDataList.Add(LEDDataFactory(row, false));
                            }
                        }
                        Ops.Write("LED", "ShowData", ledDataList);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("缺烟烟道LED线程处理失败！原因：{0}。", ex.Message));
            }
        }

        private LEDData LEDDataFactory(DataRow row, bool isLackChannel)
        {
            LEDData ledData = new LEDData();
            ledData.CardNum = Convert.ToInt32(row["led_no"]);
            ledData.ColorFont = isLackChannel ? EQ2008.EQ2008.RED : EQ2008.EQ2008.GREEN;
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
