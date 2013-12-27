using FluentScheduler;

namespace FluentSchedule.R.Dashboard.Infrastructure.Tasks {
    public class TaskRegistry : Registry {
        public TaskRegistry() {

            Schedule<SampleTask>().WithName(ScheduleNames.SampleSchedule)
                .ToRunEvery(1).Minutes();

            Schedule<HelloRealTimeTask>().WithName(ScheduleNames.HelloSchedule)
                .ToRunEvery(30).Seconds();
        }
    }
}