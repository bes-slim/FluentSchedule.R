using System.Threading;
using FluentSchedule.R.Infrastructure;

namespace FluentSchedule.R.Dashboard.Infrastructure.Tasks
{
    public class HelloTask : RealTimeTask
    {
        protected override void OnExecuting()
        {
            Thread.Sleep(10000);
        }
    }
}