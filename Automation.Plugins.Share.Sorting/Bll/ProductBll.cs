using System;
using Automation.Plugins.Share.Sorting.Dal;
using System.Data;
using Automation.Core;

namespace Automation.Plugins.Share.Sorting.Bll
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
                string name=table.Rows[i]["product_name"].ToString().Trim();
                productName[i] =  name.Length > 13 ? name.Substring(0, 13) : name;
            }
            Ops.Write(Global.PLC_SERVICE_NAME, "Cigarette_Barcode_Information", barCode);
            Ops.Write(Global.PLC_SERVICE_NAME, "Cigarette_Name_Information", productName);
        }
    }
}
