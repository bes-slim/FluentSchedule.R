using System.Threading;
using FluentSchedule.R.Infrastructure;

namespace FluentSchedule.R.Dashboard.Infrastructure.Tasks
{
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
}