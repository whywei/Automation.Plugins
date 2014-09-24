using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition;
using DotSpatial.Controls;

namespace Automation.Plugins.Common.SRM
{
    [Export]
    public class SRMManager : IPartImportsSatisfiedNotification
    {
        [Import]
        public AppManager App { get; set; }

        [ImportMany(AllowRecomposition = true)]
        public IEnumerable<ISRM> SRMs { get; private set; }

        public ISRM ActiveSRM { get; set; }

        public void OnImportsSatisfied()
        {
            App.ExtensionsActivated += new EventHandler(App_ExtensionsActivated);                
        }

        private  void App_ExtensionsActivated(object sender, EventArgs e)
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
