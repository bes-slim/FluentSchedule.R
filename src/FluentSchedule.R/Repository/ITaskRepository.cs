using FluentSchedule.R.Models;

namespace FluentSchedule.R.Repository
{
    public interface ITaskRepository
    {
        TasksViewModel Get();
    }
}