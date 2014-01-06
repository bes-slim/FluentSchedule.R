using System.Collections.Generic;

namespace FluentSchedule.R.Models
{
    public class TaskManagerPageModel
    {
        public TaskManagerPageModel()
        {
            Schedules = new List<ScheduleModel>();
        }

        public IList<ScheduleModel> Schedules { get; set; }
    }
}