
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(WebUIAu.Startup))]
namespace WebUIAu
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
        //public static Func<UserManager<AppUser, int>> UserManagerFactory { get; private set; }

        //public void Configuration(IAppBuilder app)
        //{
        //    // Configure the db context, user manager and signin manager to use a single instance per request
        //    //app.CreatePerOwinContext(ApplicationDbContext.Create);
        //    //app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
        //    //app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
        //    app.UseCookieAuthentication(new CookieAuthenticationOptions
        //    {
        //        AuthenticationType = "ApplicationCookie",
        //        LoginPath = new PathString("/auth/login")
        //    });
        //    UserManagerFactory = () =>
        //    {
        //        var usermanager = new ApplicationUserManager(new CustomUserStore(new ApplicationDbContext()));
        //        // добавляем при необходимости валидацию!!!
        //        usermanager.UserValidator = new UserValidator<AppUser, int>(usermanager)
        //        {
        //            AllowOnlyAlphanumericUserNames = false
        //        };

        //        return usermanager;
        //    };

        //}
    }
}
