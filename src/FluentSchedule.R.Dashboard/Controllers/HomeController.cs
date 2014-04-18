using System.Web.Mvc;
using FluentSchedule.R.Models;

namespace FluentSchedule.R.Dashboard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ITaskRepository taskRepository = new TaskRepository();
            TasksViewModel viewModel = taskRepository.Get();

            return View(viewModel);
        }
    }
}
