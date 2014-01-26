using System.Collections.Generic;

namespace FluentSchedule.R.Models
{
    public class TasksViewModel
    {
        public TasksViewModel()
        {
            Schedules = new List<ScheduleModel>();
        }

        public IList<ScheduleModel> Schedules { get; set; }
    }
}