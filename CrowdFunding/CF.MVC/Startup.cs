using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CF.MVC.Startup))]
namespace CF.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
