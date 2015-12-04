using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShawApplication.Web.Startup))]
namespace ShawApplication.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
