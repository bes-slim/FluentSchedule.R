using System.Web.Mvc;
using FluentSchedule.R.Models;
using FluentSchedule.R.Repository;

namespace FluentSchedule.R.Dashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskRepository _repository;

        public HomeController()
            : this(new TaskRepository())
        {

        }

        public HomeController(ITaskRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            TasksViewModel viewModel = _repository.Get();

            return View(viewModel);
        }
    }
}
