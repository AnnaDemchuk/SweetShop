using Autofac;
using Autofac.Integration.Mvc;
using Shop.BLL.Modules;
using Step.WebUI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebUIAu.Models;

namespace WebUIAu
{
 //Anna?124124   
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //9 https://metanit.com/sharp/mvc5/12.4.php инициализация с созданием базы
         //  Database.SetInitializer<ApplicationDbContext>(new AppDbInitializer());
            //

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
