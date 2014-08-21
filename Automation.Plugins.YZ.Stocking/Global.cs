using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Plugins.YZ.Stocking
{
    public class Global
    {
        public const string yzServiceName = "master";
        public const string memoryServiceName_PSD = "MemoryPermanentSingleDataService";//永久保存的单数据服务
        public const string memoryServiceName_TemporarilySingleData = "MemoryTemporarilySingleDataService";//临时保存的单数据服务
        public const string memoryItemName_SortingState = "IsStart";
        public const string plcServiceName = "YZ_Stock_PLC";
    }
}
