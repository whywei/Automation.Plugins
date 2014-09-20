using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition;
using Automation.Core;

namespace Automation.Plugins.Common.Forklift
{
    [Export]
    public class ForkliftManager : IPartImportsSatisfiedNotification
    {
        [ImportMany(AllowRecomposition = true)]
        public IEnumerable<IForklift> Forklifts { get; private set; }

        public IForklift ActiveForklift { get; set; }

        public void OnImportsSatisfied()
        {
            Forklifts.AsParallel().ForAll(s => s.Initialize());       
        }

        public void SelectForklift(string name)
        {
            ActiveForklift = Forklifts.Where(s => s.Name == name).FirstOrDefault();
            if (ActiveForklift == null)
            {
                Logger.Error("SelectForklift : 设置的叉车名称不正确，请检查参数设置！");
            }
        }

        public void FireHeartbeat()
        {
            if (ActiveForklift != null)
            {
                ActiveForklift.FireHeartbeat();
            }
        }
    }
}
