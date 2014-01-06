using FluentSchedule.R.Models;
using FluentScheduler.Model;

namespace FluentSchedule.R.Infrastructure
{
    public static class ScheduleExtensions
    {
        public static TaskManagerPageModel ToPageModel(this Schedule[] schedules)
        {
            var result = new TaskManagerPageModel();
            foreach (Schedule schedule in schedules)
            {
                result.Schedules.Add(schedule.ToTaskModel());
            }
            return result;
        }

        public static ScheduleModel ToTaskModel(this Schedule schedule)
        {
            var result = new ScheduleModel
            {
                Name = schedule.Name,
                NextRunTime = schedule.NextRunTime
            };

            return result;
        }
    }
}