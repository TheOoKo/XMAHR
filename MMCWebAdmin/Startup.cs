using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DMAHR.Startup))]
namespace DMAHR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
