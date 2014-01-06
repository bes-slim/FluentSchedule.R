using System.Diagnostics;
using FluentSchedule.R.Infrastructure;

namespace FluentSchedule.R.Dashboard.Infrastructure.Tasks
{
    public class SampleTask : TaskBase
    {
        public override void OnExecute()
        {
            Debug.WriteLine("Sample task executed.");
        }
    }
}