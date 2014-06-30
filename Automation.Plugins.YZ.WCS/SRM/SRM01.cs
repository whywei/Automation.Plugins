using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core.SRM;
using System.ComponentModel.Composition;

namespace Automation.Plugins.YZ.WCS.SRM
{
    [Export(typeof(ISRM))]
    public class SRM01 : AbstractSRM
    {
        public override void Initialize()
        {
            base.Initialize();
            Name = "1号堆垛机";
        }

        protected override void FinishCurrentTask()
        {
            throw new NotImplementedException();
        }

        protected override SRMTask RequestNewTask()
        {
            throw new NotImplementedException();
        }

        protected override bool UpdateTaskStateToWaiting()
        {
            throw new NotImplementedException();
        }
    }
}
