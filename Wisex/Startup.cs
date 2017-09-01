using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wisex.Startup))]
namespace Wisex
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
