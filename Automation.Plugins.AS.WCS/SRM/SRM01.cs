using System;
using System.ComponentModel.Composition;
using Automation.Common.SRM;
using Automation.Plugins.AS.WCS.Rest;

namespace Automation.Plugins.AS.WCS.SRM
{
    [Export(typeof(ISRM))]
    public class SRM01 : AbstractSRM
    {
        public override void Initialize()
        {
            base.Initialize();
            this.Name = "SRM01";
            this.PartnerName = "SRM01Partner";
        }

        protected override SRMTask ApplyNewTask()
        {
            RestClient restClient = new RestClient();
            return restClient.ApplyNewTask(this.Name, this.TravelPos, this.LiftPos);
        }

        protected override bool CancelCurrentTask()
        {
            RestClient restClient = new RestClient();
            return restClient.CancelCurrentTask(this.Name, this.CurrentTask);
        }

        protected override bool FinishCurrentTask()
        {
            RestClient restClient = new RestClient();
            return restClient.FinishCurrentTask(this.Name, this.CurrentTask);
        }
    }
}
