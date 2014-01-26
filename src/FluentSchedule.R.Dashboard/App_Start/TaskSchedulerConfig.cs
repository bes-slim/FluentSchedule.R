using System;
using FluentSchedule.R.Dashboard.Infrastructure.Tasks;
using FluentSchedule.R.Infrastructure;
using FluentScheduler.Model;

namespace FluentSchedule.R.Dashboard
{
    public class TaskSchedulerConfig
    {
        public static void RegisterTasks()
        {

            RealtimeTaskEngine.Instance
                .WithRegistry<TaskRegistry>()
                .ForAll()
                .OnStart(new TrackOptions { HubMethod = "taskExecuting" }, information => new ExecutionHandle
                {
                    message = "Execting " + information.Name,
                    task = information.Name
                })
                .OnEnd(new TrackOptions { HubMethod = "taskExecuted" }, information => new ExecutionHandle
                {
                    message = "Executed..",
                    task = information.Name
                })
                .HandleErrorWith(TaskManager_UnobservedTaskException);
        }

        public static void TaskManager_UnobservedTaskException(TaskExceptionInformation sender, UnhandledExceptionEventArgs e)
        {

        }
    }
}