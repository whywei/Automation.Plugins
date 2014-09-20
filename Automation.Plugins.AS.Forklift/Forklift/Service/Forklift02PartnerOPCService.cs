using Automation.Core;
using Automation.Service.OPC;

namespace Automation.Plugins.AS.Forklift.Forklift.Service
{
    public class Forklift02PartnerOPCService : AbstractServiceWrapper
    {
        public override void Initialize()
        {
            Description = "2号叉车伙伴OPC服务";
            base.Initialize();
        }

        public override void CreateTargetService()
        {
            Name = "Forklift02Partner";
            this.TargetService = new OPCService(GetConfigFilePath());
        }
    }
}
