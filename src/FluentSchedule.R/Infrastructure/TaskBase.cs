using System.Web.Hosting;
using FluentScheduler;

namespace FluentSchedule.R.Infrastructure
{
    public abstract class TaskBase : ITask, IRegisteredObject
    {
        private readonly object _lock = new object();
        private bool _shuttingDown;

        protected TaskBase()
        {
            HostingEnvironment.RegisterObject(this);
        }

        public void Execute()
        {
            lock (_lock)
            {
                if (_shuttingDown)
                {
                    return;
                }

                OnExecute();
            }
        }


        public void Stop(bool immediate)
        {
            lock (_lock)
            {
                _shuttingDown = true;
            }

            HostingEnvironment.UnregisterObject(this);
        }

        public abstract void OnExecute();
    }
}