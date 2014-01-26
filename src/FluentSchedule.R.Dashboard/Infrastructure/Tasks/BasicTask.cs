using System.Diagnostics;
using FluentSchedule.R.Infrastructure;

namespace FluentSchedule.R.Dashboard.Infrastructure.Tasks
{
    public class BasicTask : TaskBase
    {
        public override void OnExecute()
        {
            Debug.WriteLine("Basic task executed.");
        }
    }
}