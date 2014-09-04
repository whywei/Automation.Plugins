using Automation.Core.Option;
using Automation.Plugins.Share.Stocking.Properties;

namespace Automation.Plugins.Share.Stocking.Options
{
    public class StockParameterOption : AbstractOption
    {
        public override void Initialize()
        {
            this.NodeName = "StockParameterOption";
            this.Caption = "补货系统参数";
            this.Order = 3;
            this.NodeImage = Resources.ParameterOption_16;
            this.ParentNodeName = "";
            base.Initialize();
        }

        public override void OnSelected()
        {
        }
    }
}
