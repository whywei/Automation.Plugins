using Automation.Core;
using Automation.Service.OPC;

namespace Automation.Plugins.AS.Stocking.Service
{
    public class StockingOPCService : AbstractServiceWrapper
    {
        public override void Initialize()
        {
            Description = "补货OPC服务[AB]";
            base.Initialize();
        }

        public override void CreateTargetService()
        {
            Name = "StockPLC";
            this.TargetService = new OPCService(GetConfigFilePath());
        }
    }
}
