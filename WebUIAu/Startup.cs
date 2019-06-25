using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebUIAu.Startup))]
namespace WebUIAu
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
