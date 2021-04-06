using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ADSProject.Startup))]
namespace ADSProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
