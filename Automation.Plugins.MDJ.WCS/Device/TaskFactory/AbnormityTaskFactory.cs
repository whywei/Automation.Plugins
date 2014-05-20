using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Plugins.MDJ.WCS.Model;
using Automation.Plugins.MDJ.WCS.Dal;

namespace Automation.Plugins.MDJ.WCS.Device.TaskFactory
{
    [Serializable]
    public class AbnormityTaskFactory : ITaskFactory
    {
        public TaskInfo GetTask(string srmName, int travelPos)
        {
            TaskDal taskDal = new TaskDal();
            return taskDal.GetNewAbnormityTask(srmName);
        }

        public TaskInfo GetTask(string srmName, int travelPos, int waitingTask)
        {
            TaskDal taskDal = new TaskDal();
            return taskDal.GetNewAbnormityTask(srmName);
        }

        public TaskInfo GetTask(string srmName, int travelPos, int[] waitingTasks)
        {
            TaskDal taskDal = new TaskDal();
            return taskDal.GetNewAbnormityTask(srmName);
        }
    }
}
