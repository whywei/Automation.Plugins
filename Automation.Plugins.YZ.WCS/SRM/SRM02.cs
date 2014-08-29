using System;
using System.ComponentModel.Composition;
using Automation.Common.SRM;

namespace Automation.Plugins.YZ.WCS.SRM
{
    [Export(typeof(ISRM))]
    public class SRM02 : AbstractSRM
    {
        public override void Initialize()
        {
            base.Initialize();
            Name = "2号堆垛机";
        }

        protected override SRMTask ApplyNewTask()
        {
            throw new NotImplementedException();
        }

        protected override bool CancelCurrentTask()
        {
            throw new NotImplementedException();
        }

        protected override bool FinishCurrentTask()
        {
            throw new NotImplementedException();
        }
    }
}
