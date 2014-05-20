using System;
using System.Collections.Generic;
using Automation.Plugin.MDJ.WCS.Device.TaskFactory;
using Automation.Core.Util;

namespace Automation.Plugin.MDJ.WCS.Device
{
    [Serializable]
    public class SRMSerializer
    {
        public IDictionary<string, SRM> SRMS = new Dictionary<string, SRM>();

        public void Initialize()
        {
            if (!SRMS.ContainsKey("SRM01"))
            {
                SRMS.Add("SRM01", new SRM() { Name = "SRM01" });
            }

            if (!SRMS.ContainsKey("SRM02"))
            {
                SRMS.Add("SRM02", new SRM() { Name = "SRM02" });
            }

            if (!SRMS.ContainsKey("SRM03"))
            {
                SRMS.Add("SRM03", new SRM() { Name = "SRM03" });
            }

            if (!SRMS.ContainsKey("SRM04"))
            {
                SRMS.Add("SRM04", new SRM() { Name = "SRM04" }); 
            }

            foreach (SRM srm in SRMS.Values)
            {
                srm.TaskFactories.Clear();
            }

            SRMS["SRM03"].TaskFactories.Add(new AbnormityTaskFactory());
            SRMS["SRM01"].TaskFactories.Add(new SmallSpeciesTaskFactory());

            SRMS["SRM01"].TaskFactories.Add(new DefaultTaskFactory());
            SRMS["SRM02"].TaskFactories.Add(new DefaultTaskFactory());
            SRMS["SRM03"].TaskFactories.Add(new DefaultTaskFactory());
            SRMS["SRM04"].TaskFactories.Add(new DefaultTaskFactory());

            Serialize();                
        }

        public void Serialize()
        {
            SerializableUtil.Serialize(@"d:\SRM.sl", this);
        }

        public static SRMSerializer Deserialize()
        {
            return SerializableUtil.Deserialize<SRMSerializer>(@"d:\SRM.sl");
        }

        public void Scan(string SRMName)
        {
            if (SRMS.ContainsKey(SRMName))
            {
                SRMS[SRMName].Scan();
            }
        }        
    }
}
