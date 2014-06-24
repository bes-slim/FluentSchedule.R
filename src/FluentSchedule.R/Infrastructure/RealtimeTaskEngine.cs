using System;
using FluentSchedule.R.Hubs;
using FluentScheduler;
using FluentScheduler.Model;
using Microsoft.AspNet.SignalR;

namespace FluentSchedule.R.Infrastructure
{
    public class RealtimeTaskEngine : IRealtimeTaskEngine
    {
        private static readonly Lazy<IRealtimeTaskEngine> LazyEngineInstance =
            new Lazy<IRealtimeTaskEngine>(() => new RealtimeTaskEngine(), true);

        private TrackOptions _endOptions;
        private TrackOptions _startOptions;

        public RealtimeTaskEngine()
        {
            HubContext = GlobalHost.ConnectionManager.GetHubContext<TaskManagerHub>();
        }

        public static IRealtimeTaskEngine Instance
        {
            get { return LazyEngineInstance.Value; }
        }

        public IHubContext HubContext { get; set; }

        public IRealtimeTaskEngine WithRegistry<T>() where T : Registry, new()
        {
            TaskManager.Initialize(new T());

            return this;
        }

        public IRealtimeTaskEngine WithRegistry<T>(T taskRegistry) where T : Registry
        {
            TaskManager.Initialize(taskRegistry);

            return this;
        }

        public IExecutionTrackable OnStart(TrackOptions options, Func<TaskStartScheduleInformation, object> messageBuilder = null)
        {
            _startOptions = options;

            if (messageBuilder != null)
            {
                TaskManager.TaskStart += (sender, e) => HubContext.Clients.All.Invoke(_startOptions.HubMethod, messageBuilder(sender));
            }

            return this;
        }

        public IExecutionTrackable OnEnd(TrackOptions options, Func<TaskEndScheduleInformation, object> messageBuilder = null)
        {
            _endOptions = options;

            if (messageBuilder != null)
            {
                TaskManager.TaskEnd += (sender, e) => HubContext.Clients.All.Invoke(_endOptions.HubMethod, messageBuilder(sender));
            }

            return this;
        }

        public IExecutionTrackable ForAll()
        {
            return this;
        }

        public void HandleErrorWith(GenericEventHandler<TaskExceptionInformation, UnhandledExceptionEventArgs> taskManagerUnobservedTaskException)
        {
            TaskManager.UnobservedTaskException += taskManagerUnobservedTaskException;
        }

        public static void Stop()
        {
            TaskManager.Stop();
        }
    }
}