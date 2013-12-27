using System.Threading;
using FluentSchedule.R.Infrastructure;

namespace FluentSchedule.R.Dashboard.Infrastructure.Tasks {
    public class HelloRealTimeTask : RealTimeTask {
        protected override void BeforeExcute(object data) {
            TaskHub.Clients.All.TaskExecuting(new { message = "Hello Task executing..", task = ScheduleNames.HelloSchedule });
        }

        protected override void OnExecute() {
            Thread.Sleep(10000);
        }

        protected override void ExcuteProgress(object data) {
            //do nth.
        }

        public override void AfterExcute(object data) {
            TaskHub.Clients.All.TaskExecuted(new { message = "Hello Task executed..", task = ScheduleNames.HelloSchedule });
        }
    }
}