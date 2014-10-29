using Automation.Core;
using Automation.Service.OPC;

namespace Automation.Plugins.LPS.Forklift.Forklift.Service
{
    public class Forklift01PartnerOPCService : AbstractServiceWrapper
    {
        public override void Initialize()
        {
            Description = "1号叉车伙伴OPC服务";
            base.Initialize();
        }

        public override void CreateTargetService()
        {
            Name = "Forklift01Partner";
            this.TargetService = new OPCService(GetConfigFilePath());
        }
    }
}
