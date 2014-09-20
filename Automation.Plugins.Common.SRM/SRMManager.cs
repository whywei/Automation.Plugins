using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition;

namespace Automation.Plugins.Common.SRM
{
    [Export]
    public class SRMManager : IPartImportsSatisfiedNotification
    {
        [ImportMany(AllowRecomposition = true)]
        public IEnumerable<ISRM> SRMs { get; private set; }

        public ISRM ActiveSRM { get; set; }

        public void OnImportsSatisfied()
        {
            SRMs.AsParallel().ForAll(s => s.Initialize());       
        }

        public void SelectSRM(string name)
        {
            ActiveSRM = SRMs.Where(s => s.Name == name).Single();
        }

        public void FireHeartbeat(string name)
        {
            SRMs.Where(s => s.Name == name).Single().FireHeartbeat();
        }
    }
}
