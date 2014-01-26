using System;
using FluentSchedule.R.Hubs;
using Microsoft.AspNet.SignalR;

namespace FluentSchedule.R.Infrastructure
{
    public abstract class RealTimeTask : TaskBase
    {
        protected RealTimeTask()
        {
            TaskHub = GlobalHost.ConnectionManager.GetHubContext<TaskManagerHub>();
        }

        protected IHubContext TaskHub { get; private set; }

        protected Action BeforeExcute = () => { };
        protected Action<ExecutionHandle> ExecuteProgress = handle => { };
        protected Action AfterExcute = () => { };

        public override void OnExecute()
        {
            BeforeExcute();
            OnExecuting();
            AfterExcute();
        }

        protected abstract void OnExecuting();
    }
}