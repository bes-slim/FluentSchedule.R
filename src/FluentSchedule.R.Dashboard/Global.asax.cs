using System;
using System.Web.Mvc;
using System.Web.Routing;
using FluentSchedule.R.Dashboard.App_Start;
using FluentScheduler;

namespace FluentSchedule.R.Dashboard {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {

            AreaRegistration.RegisterAllAreas();

            TaskSchedulerConfig.RegisterTasks();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

        }

        protected void Application_End(object sender, EventArgs e) {

            TaskManager.Stop();

        }
    }
}