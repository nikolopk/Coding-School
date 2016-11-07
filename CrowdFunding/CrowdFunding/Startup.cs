using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrowdFunding.Startup))]
namespace CrowdFunding
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
