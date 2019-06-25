using Autofac;
using Autofac.Integration.Mvc;
using Shop.BLL.Modules;
using Step.WebUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebUIAu
{
    
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Autofac Configuration
            var builder = new ContainerBuilder();
            // builder.RegisterControllers(typeof(Global).Assembly).PropertiesAutowired();
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
            builder.RegisterModule(new ServiceModule());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //
        }
    }
    

}
