using System.Web.Mvc;
using FluentSchedule.R.Models;
using FluentSchedule.R.Repository;

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
