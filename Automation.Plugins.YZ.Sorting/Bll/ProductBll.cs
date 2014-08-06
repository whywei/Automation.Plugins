using System;
using Automation.Plugins.YZ.Sorting.Dal;
using System.Data;
using Automation.Core;

namespace Automation.Plugins.YZ.Sorting.Bll
{
    public class ProductBll
    {
        public void WriteProductInfoToPLC()
        {
            ChannelDal channelDal = new ChannelDal();
            DataTable table = channelDal.FindAllProduct();
            int[] barCode = new int[table.Rows.Count];
            string[] productName = new string[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                barCode[i] = Convert.ToInt32(table.Rows[i]["piece_barcode"]);
                productName[i] = table.Rows[i]["product_name"].ToString().Substring(0, 13);
            }
            Ops.Write(Global.plcServiceName, "Cigarette_Barcode_Information", barCode);
            Ops.Write(Global.plcServiceName, "Cigarette_Name_Information", productName);
        }
    }
}
