using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MMCWeb.Startup))]
namespace MMCWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
