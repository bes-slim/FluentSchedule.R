FluentSchedule.R
================

[FluentScheduler](https://github.com/jgeurts/FluentScheduler) + [SignalR](https://github.com/jgeurts/FluentScheduler) = FluentSchedule.R

Real-time dashboard that built on [FluentScheduler](https://github.com/jgeurts/FluentScheduler) scheduling framework.

##Basic Sample##

**Define Job**
```cs
 public class DoSomethingTask : RealTimeTask
    {
        public DoSomethingTask()
        {
            BeforeExcute = () => TaskHub.Clients.All.TaskExecuting(new ExecutionHandle
            {
                message = "DoSomething Task executing..",
                task = TaskNames.DoSomething
            });

            AfterExcute = () => TaskHub.Clients.All.TaskExecuted(new ExecutionHandle
            {
                message = "HDoSomethingello Real Time Task executed..",
                task = TaskNames.DoSomething
            });

            ExecuteProgress = handle => { /*Do sth*/};
        }

        protected override void OnExecuting()
        {
            Thread.Sleep(10000);
        }
    }
```

**Register Job**
```cs
 public class TaskRegistry : Registry
    {
        public TaskRegistry()
        {
            Schedule<DoSomethingTask>().WithName("DoSomethingTask")
                .ToRunEvery(50)
                .Seconds();
        }
    }

```
**Configure FluentSchedule.R**
```cs

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
            //log
        }
    }
```

```cs
 protected void Application_Start()
        {
           //..
            TaskSchedulerConfig.RegisterTasks();
          //...
        }

        protected void Application_End(object sender, EventArgs e)
        {
            RealtimeTaskEngine.Stop();
        }
```


Sample application hosted at [AppHarbor](https://appharbor.com/) : [fluentschedulrdashboard](http://fluentschedulrdashboard.apphb.com/Home/Index)
