using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrowdFunding.MVC.Startup))]
namespace CrowdFunding.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
