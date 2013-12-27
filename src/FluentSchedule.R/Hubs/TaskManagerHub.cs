using FluentScheduler;
using FluentScheduler.Model;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace FluentSchedule.R.Hubs
{
    [HubName("taskManager")]
    public class TaskManagerHub : Hub
    {
        public void RunScheduleImmediately(string scheduleName)
        {
            Schedule schedule = TaskManager.GetSchedule(scheduleName);
            if (schedule != null)
                schedule.Execute();
        }
        public void DeleteTaskImmediately(string scheduleName)
        {
            Schedule schedule = TaskManager.GetSchedule(scheduleName);
            if (schedule != null)
            {
                TaskManager.RemoveTask(scheduleName);
                Clients.All.TaskRemoved(new { task = scheduleName });
            }
        }
    }
}