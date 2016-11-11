using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrowdFundingDemo.Startup))]
namespace CrowdFundingDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
