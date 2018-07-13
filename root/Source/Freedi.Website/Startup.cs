using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Freedi.Website.Startup))]
namespace Freedi.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
