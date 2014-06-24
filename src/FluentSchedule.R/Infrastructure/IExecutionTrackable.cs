using System;
using FluentScheduler;
using FluentScheduler.Model;

namespace FluentSchedule.R.Infrastructure
{
    public interface IExecutionTrackable : IEditorInvisible
    {
        IExecutionTrackable OnStart(TrackOptions options, Func<TaskStartScheduleInformation, object> messageBuilder = null);

        IExecutionTrackable OnEnd(TrackOptions options, Func<TaskEndScheduleInformation, object> messageBuilder = null);

        void HandleErrorWith(GenericEventHandler<TaskExceptionInformation, UnhandledExceptionEventArgs> taskManagerUnobservedTaskException);
    }
}