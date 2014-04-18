using FluentScheduler;
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
}