using System.Web.Hosting;
using FluentSchedule.R.Hubs;
using FluentScheduler;
using Microsoft.AspNet.SignalR;

namespace FluentSchedule.R.Infrastructure {
    public abstract class RealTimeTask : ITask, IRegisteredObject {
        private readonly object _lock = new object();
        private bool _shuttingDown;
        protected IHubContext TaskHub { get; private set; }

        protected RealTimeTask() {
            // Register this task with the hosting environment. Allows for a more graceful stop of the task, in the case of IIS shutting down.
            HostingEnvironment.RegisterObject(this);
            TaskHub = GlobalHost.ConnectionManager.GetHubContext<TaskManagerHub>();
        }
        public void Execute() {
            lock (_lock) {
                if (_shuttingDown)
                    return;

                BeforeExcute(null);
                OnExecute();
                AfterExcute(null);
            }
        }

        protected abstract void BeforeExcute(object data);
        protected abstract void ExcuteProgress(object data);
        protected abstract void OnExecute();
        public abstract void AfterExcute(object data);

        public void Stop(bool immediate) {
            // Locking here will wait for the lock in Execute to be released until this code can continue.
            lock (_lock) {
                _shuttingDown = true;
            }
            HostingEnvironment.UnregisterObject(this);
        }
    }
}