using FluentSchedule.R.Models;
using FluentScheduler.Model;

namespace FluentSchedule.R.Infrastructure {
    public static class ScheduleExtensions {
        public static TaskManagerPageModel ToPageModel(this Schedule[] schedules) {
            TaskManagerPageModel result = new TaskManagerPageModel();
            foreach (Schedule schedule in schedules) {
                result.Schedules.Add(schedule.ToTaskModel());
            }
            return result;
        }

        public static ScheduleModel ToTaskModel(this Schedule schedule) {
            ScheduleModel result = new ScheduleModel {
                Name = schedule.Name,
                NextRunTime = schedule.NextRunTime
            };

            return result;
        }
    }
}