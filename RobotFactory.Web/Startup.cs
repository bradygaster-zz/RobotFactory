using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RobotFactory.Web.Startup))]
namespace RobotFactory.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
