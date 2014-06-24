using FluentSchedule.R.Infrastructure;
using FluentSchedule.R.Models;
using FluentScheduler;

namespace FluentSchedule.R.Repository
{
    public class TaskRepository : ITaskRepository
    {
        public TasksViewModel Get()
        {
            return TaskManager.AllSchedules.ToPageModel();
        }
    }
}