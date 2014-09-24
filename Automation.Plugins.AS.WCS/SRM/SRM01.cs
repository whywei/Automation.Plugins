using System.ComponentModel.Composition;
using Automation.Plugins.AS.WCS.Rest;
using Automation.Plugins.Common.SRM;

namespace Automation.Plugins.AS.WCS.SRM
{
    [Export(typeof(ISRM))]
    public class SRM01 : AbstractSRM
    {
        public SRM01()
        {
            this.Name = "SRM01";
        }

        public override void Initialize()
        {
            base.Initialize();            
            this.PartnerName = "SRM01Partner";
        }

        protected override SRMTask ApplyNewTask()
        {
            RestClient restClient = new RestClient();
            if (this.CurrentTask == null)
            {
                return restClient.ApplyNewTask(this.Name, this.TravelPos, this.LiftPos);
            }
            else
            {
                return restClient.ApplyNewTask(this.Name, this.CurrentTask.TravelPos2, this.CurrentTask.LiftPos2);
            }
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
