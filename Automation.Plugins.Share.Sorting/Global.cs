using System.ComponentModel.Composition;
using Automation.Plugins.Share.Sorting.Properties;

namespace Automation.Plugins.Share.Sorting
{
    public class Global
    {
       [Export("SortLineCode", typeof(string))]
       private static string SortLineCode = Settings.Default.Sorting_Line_Code;

       public const string SERVER_DATABASE_NAME = "ServerDB";
       public const string SORTING_DATABASE_NAME = "SortDB";
       public const string PLC_SERVICE_NAME = "SortPLC";
       public const string LED_SERVICE_NAME = "SortLED";

       public const string MemoryPermanentSingleDataService = "MemoryPermanentSingleDataService";
       public const string MemoryTemporarilySingleDataService = "MemoryTemporarilySingleDataService";
       public const string MemoryItemNameSortState = "IsStart";       
    }

    public enum Group
    {
        A = 1,
        B = 2,
        C = 3,
        D = 4
    }
}
