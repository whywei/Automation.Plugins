using System.ComponentModel.Composition;
using Automation.Plugins.LPS.Forklift.Rest;
using Automation.Plugins.Common.Forklift;

namespace Automation.Plugins.LPS.Forklift.Forklift
{
    [Export(typeof(IForklift))]
    public class Forklift02 : AbstractForklift
    {
        public Forklift02()
        {
            this.Name = "Forklift02";
        }

        public override void Initialize()
        {
            base.Initialize();
            this.PartnerName = "Forklift02Partner";
        }

        protected override ForkliftTask ApplyNewTask()
        {
            RestClient restClient = new RestClient();
            if (this.CurrentTask == null)
            {
                return restClient.ApplyNewTask(this.Name, 0, 0);
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
