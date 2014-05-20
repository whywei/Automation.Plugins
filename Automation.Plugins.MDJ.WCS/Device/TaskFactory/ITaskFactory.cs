using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Plugins.MDJ.WCS.Model;

namespace Automation.Plugins.MDJ.WCS.Device.TaskFactory
{
    public interface ITaskFactory
    {
        TaskInfo GetTask(string srmName, int travelPos);

        TaskInfo GetTask(string srmName, int travelPos, int waitingTask);

        TaskInfo GetTask(string srmName, int travelPos, int[] waitingTasks);
    }
}
