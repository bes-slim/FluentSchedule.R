using System;

namespace FluentSchedule.R.Models
{
    public class ScheduleModel
    {
        public DateTime NextRunTime { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}