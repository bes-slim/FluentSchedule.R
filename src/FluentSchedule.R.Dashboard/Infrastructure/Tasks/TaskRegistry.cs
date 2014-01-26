using FluentScheduler;

namespace FluentSchedule.R.Dashboard.Infrastructure.Tasks
{
    public class TaskRegistry : Registry
    {
        public TaskRegistry()
        {
            Schedule<BasicTask>().WithName(TaskNames.Sample)
                .ToRunEvery(1)
                .Minutes();

            Schedule<HelloTask>().WithName(TaskNames.Hello)
                .ToRunEvery(30)
                .Seconds();

            Schedule<DoSomethingTask>().WithName(TaskNames.DoSomething)
                .ToRunEvery(50)
                .Seconds();
        }
    }
}