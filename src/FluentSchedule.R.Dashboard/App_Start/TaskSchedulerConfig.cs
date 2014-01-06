using System;
using FluentSchedule.R.Dashboard.Infrastructure.Tasks;
using FluentScheduler.Model;

namespace FluentSchedule.R.Dashboard
{
    public class TaskSchedulerConfig
    {
        public static void RegisterTasks()
        {

            RealtimeTaskEngine.Instance
                .InitRegistry(new TaskRegistry())
                .TrackStart(new TrackOptions { HubMethod = "helloStart" }, information => new { message = "Task Started" + information.Name })
                .TrackEnd(new TrackOptions { HubMethod = "helloEnd" }, information => new { message = "Task Ended" + information.Name })
                .HandleErrorWith(TaskManager_UnobservedTaskException);
        }

        static void TaskManager_UnobservedTaskException(TaskExceptionInformation sender, UnhandledExceptionEventArgs e)
        {
            //Log..
        }
    }
}