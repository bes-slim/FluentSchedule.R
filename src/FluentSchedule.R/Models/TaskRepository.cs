using FluentSchedule.R.Infrastructure;
using FluentScheduler;

namespace FluentSchedule.R.Models
{
    public class TaskRepository : ITaskRepository
    {
        public TasksViewModel Get()
        {
            return TaskManager.AllSchedules.ToPageModel();
        }
    }
}