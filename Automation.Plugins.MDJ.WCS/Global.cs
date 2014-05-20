using Automation.Plugins.MDJ.WCS.Device;
using Automation.Core;
using System.Collections.Generic;
using Automation.Plugins.MDJ.WCS.Dal;

namespace Automation.Plugins.MDJ.WCS
{
    public class Global
    {
        public const string THOK_WCS_DB_NAME = "master";
        public const string THOK_STOCK_DB_NAME = "master2";

        //托盘高度
        public const double PALLET_HEIGHT = 148.5;

        //入库位置ID
        public const int STOCK_IN_POSITION_ID = 855;
    }
}
