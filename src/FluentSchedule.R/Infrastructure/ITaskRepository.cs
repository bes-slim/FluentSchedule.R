using FluentSchedule.R.Models;

namespace FluentSchedule.R.Infrastructure
{
    public interface ITaskRepository
    {
        TaskManagerPageModel Get();
    }
}