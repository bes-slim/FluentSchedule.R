using System.Web.Mvc;
using FluentSchedule.R.Infrastructure;

namespace FluentSchedule.R.Dashboard.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            ITaskRepository taskRepository = new TaskRepository();
            return View(taskRepository.Get());
        }
    }
}
