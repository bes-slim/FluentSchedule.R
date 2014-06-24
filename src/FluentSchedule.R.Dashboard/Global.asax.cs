using System;
using System.Web.Mvc;
using System.Web.Routing;
using FluentSchedule.R.Infrastructure;

namespace FluentSchedule.R.Dashboard
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            TaskSchedulerConfig.RegisterTasks();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

        }

        protected void Application_End(object sender, EventArgs e)
        {
            RealtimeTaskEngine.Stop();
        }
    }
}