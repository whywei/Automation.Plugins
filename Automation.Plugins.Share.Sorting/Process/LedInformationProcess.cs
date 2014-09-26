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
                Show(1);
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("缺烟烟道LED线程处理失败！原因：{0}。", ex.Message));
            }
        }

        private void Show(int groupNo)
        {
            string groupName = Enum.GetName(typeof(Group), groupNo);
            object[] lackCigaretteChannelAdressArray = Ops.ReadArray<object>(Global.PLC_SERVICE_NAME, "Lack_Cigarette_Channel_Information_" + groupName);
            object[] remainQuantityArray = Ops.ReadArray<object>(Global.PLC_SERVICE_NAME, "Real_Time_Inventory_Data_" + groupName);
            DataTable channelTable = channelDal.FindCigaretteChannelInfo(groupNo);
            DataTable channelTable2 = channelDal.FindCigaretteChannelInfo2(groupNo);//
            LEDData[] ledDataList = new LEDData[channelTable.Rows.Count + channelTable2.Rows.Count];
            for (int i = 0; i < channelTable.Rows.Count; i++)
            {
                channelTable.Rows[i]["remain_quantity"] = remainQuantityArray[Convert.ToInt32(channelTable.Rows[i]["sort_address"]) - 1].ToString() == "0" ? channelTable.Rows[i]["quantity"] : Convert.ToInt32(remainQuantityArray[Convert.ToInt32(channelTable.Rows[i]["sort_address"]) - 1]) - 1;
                if (lackCigaretteChannelAdressArray[Convert.ToInt32(channelTable.Rows[i]["sort_address"]) - 1].ToString() != "0")
                {
                    ledDataList[i] = LEDDataFactory(channelTable.Rows[i], true);
                }
                else
                {
                    ledDataList[i] = LEDDataFactory(channelTable.Rows[i], false);
                }
            }
            for (int i = 0; i < channelTable2.Rows.Count; i++)
            {
                channelTable2.Rows[i]["remain_quantity"] = remainQuantityArray[Convert.ToInt32(channelTable2.Rows[i]["sort_address"]) - 1].ToString() == "0" ? channelTable2.Rows[i]["quantity"] : Convert.ToInt32(remainQuantityArray[Convert.ToInt32(channelTable2.Rows[i]["sort_address"]) - 1]) - 1;
                if (lackCigaretteChannelAdressArray[Convert.ToInt32(channelTable2.Rows[i]["sort_address"]) - 1].ToString() != "0")
                {
                    ledDataList[channelTable.Rows.Count + i] = LEDDataFactory(channelTable2.Rows[i], true);
                }
                else
                {
                    ledDataList[channelTable.Rows.Count + i] = LEDDataFactory(channelTable2.Rows[i], false);
                }
            }
            Ops.Write(Global.LED_SERVICE_NAME, "ShowData", ledDataList);
        }

        private LEDData LEDDataFactory(DataRow row, bool isLackChannel)
        {
            string text = (Convert.ToInt32(row["quantity"]) > 0 && row["product_name"].ToString().Trim().Length > 0) ? row["remain_quantity"].ToString() + "|" + row["product_name"].ToString() : "无";
            LEDData ledData = new LEDData();
            ledData.CardNum = Convert.ToInt32(row["led_no"]);
            ledData.ColorFont = isLackChannel ? EQ2008.EQ2008.GREEN : EQ2008.EQ2008.RED;
            ledData.Content = text;
            ledData.FontName = "@宋体";
            ledData.SingleText.FontInfo.iFontSize = 9;
            ledData.X = Convert.ToInt32(row["x"]);
            ledData.Y = Convert.ToInt32(row["y"]);
            ledData.Width = Convert.ToInt32(row["width"]);
            ledData.Height = Convert.ToInt32(row["height"]);
            ledData.IsMove = text.Length > 6 ? true : false;
            ledData.MethodType = MethodType.AddSingleText;
            return ledData;
        }
    }
}
