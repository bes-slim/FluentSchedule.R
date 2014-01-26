using System;
using System.ComponentModel;
using FluentScheduler;
using FluentScheduler.Model;
using Microsoft.AspNet.SignalR;

namespace FluentSchedule.R.Infrastructure
{
    public interface IRealtimeTaskEngine : IExecutionTrackable
    {
        IHubContext HubContext { get; set; }

        IRealtimeTaskEngine WithRegistry<T>() where T : Registry, new();

        IRealtimeTaskEngine WithRegistry<T>(T taskRegistry) where T : Registry;

        IExecutionTrackable ForAll();
    }

    public interface IExecutionTrackable : IEditorInvisible
    {
        IExecutionTrackable OnStart(TrackOptions options, Func<TaskStartScheduleInformation, object> messageMaker = null);

        IExecutionTrackable OnEnd(TrackOptions options, Func<TaskEndScheduleInformation, object> messageMaker = null);

        void HandleErrorWith(GenericEventHandler<TaskExceptionInformation, UnhandledExceptionEventArgs> taskManagerUnobservedTaskException);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IEditorInvisible
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        string ToString();

        [EditorBrowsable(EditorBrowsableState.Never)]
        int GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        bool Equals(object obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        Type GetType();
    }
}