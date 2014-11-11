using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BestApp.Startup))]
namespace BestApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
