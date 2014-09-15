using Automation.Core;
using Automation.Service.OPC;

namespace Automation.Plugins.AS.WCS.SRM.Service
{
    public class SRM01PartnerOPCService : AbstractServiceWrapper
    {
        public override void Initialize()
        {
            Description = "1号堆垛机伙伴OPC服务";
            base.Initialize();
        }

        public override void CreateTargetService()
        {
            Name = "SRM01Partner";
            this.TargetService = new OPCService(GetConfigFilePath());
        }
    }
}
