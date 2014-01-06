using System;
using FluentSchedule.R.Hubs;
using FluentScheduler;
using FluentScheduler.Model;
using Microsoft.AspNet.SignalR;

namespace FluentSchedule.R
{
    public class RealtimeTaskEngine : IRealtimeTaskEngine
    {
        private static readonly Lazy<RealtimeTaskEngine> LazyEngineInstance =
            new Lazy<RealtimeTaskEngine>(() => new RealtimeTaskEngine(), true);

        private TrackOptions _endOptions;
        private TrackOptions _startOptions;

        public RealtimeTaskEngine()
        {
            HubContext = GlobalHost.ConnectionManager.GetHubContext<TaskManagerHub>();
        }

        public static RealtimeTaskEngine Instance
        {
            get { return LazyEngineInstance.Value; }
        }

        public IHubContext HubContext { get; set; }

        public RealtimeTaskEngine InitRegistry(Registry taskRegistry)
        {
            TaskManager.Initialize(taskRegistry);
            return this;
        }

        public RealtimeTaskEngine TrackStart(TrackOptions options,
            Func<TaskStartScheduleInformation, object> messageMaker = null)
        {
            _startOptions = options;
            if (messageMaker != null)
                TaskManager.TaskStart +=
                    (sender, e) => HubContext.Clients.All.Invoke(_startOptions.HubMethod, messageMaker(sender));
            return this;
        }

        public RealtimeTaskEngine TrackEnd(TrackOptions options,
            Func<TaskEndScheduleInformation, object> messageMaker = null)
        {
            _endOptions = options;
            if (messageMaker != null)
                TaskManager.TaskEnd +=
                    (sender, e) => HubContext.Clients.All.Invoke(_endOptions.HubMethod, messageMaker(sender));
            return this;
        }

        public void HandleErrorWith(
            GenericEventHandler<TaskExceptionInformation, UnhandledExceptionEventArgs>
                taskManagerUnobservedTaskException)
        {
            TaskManager.UnobservedTaskException += taskManagerUnobservedTaskException;
        }
    }
}