using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SignalRDatabaseNotification.Startup))]
namespace SignalRDatabaseNotification
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
