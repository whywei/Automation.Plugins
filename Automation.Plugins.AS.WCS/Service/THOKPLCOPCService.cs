using Automation.Core;
using Automation.Service.OPC;

namespace Automation.Plugins.AS.WCS.Service
{
    public class THOKPLCOPCService : AbstractServiceWrapper
    {
        public override void Initialize()
        {
            Description = "THOKPLC WCS OPC服务";
            base.Initialize();
        }

        public override void CreateTargetService()
        {
            Name = "THOKPLC";
            this.TargetService = new OPCService(GetConfigFilePath());
        }
    }
}
