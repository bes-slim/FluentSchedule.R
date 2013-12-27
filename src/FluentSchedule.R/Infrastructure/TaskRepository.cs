using FluentSchedule.R.Models;
using FluentScheduler;

namespace FluentSchedule.R.Infrastructure
{
    public class TaskRepository : ITaskRepository
    {
        public TaskManagerPageModel Get()
        {
            return TaskManager.AllSchedules.ToPageModel();
        }
    }
}