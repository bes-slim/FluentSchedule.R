using System;
using FluentScheduler;
using FluentScheduler.Model;
using Microsoft.AspNet.SignalR;

namespace FluentSchedule.R
{
    public interface IRealtimeTaskEngine
    {
        IHubContext HubContext { get; set; }
        RealtimeTaskEngine InitRegistry(Registry taskRegistry);

        RealtimeTaskEngine TrackStart(TrackOptions options,
            Func<TaskStartScheduleInformation, object> messageMaker = null);

        RealtimeTaskEngine TrackEnd(TrackOptions options, Func<TaskEndScheduleInformation, object> messageMaker = null);

        void HandleErrorWith(
            GenericEventHandler<TaskExceptionInformation, UnhandledExceptionEventArgs>
                taskManagerUnobservedTaskException);
    }
}