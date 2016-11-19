using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CF.MVC.Startup))]
namespace CF.MVC
{
    public partial class Startup
    {
        // https://weblog.west-wind.com/posts/2015/Apr/29/Adding-minimal-OWIN-Identity-Authentication-to-an-Existing-ASPNET-MVC-Application
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
