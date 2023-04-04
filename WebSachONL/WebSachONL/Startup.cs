using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSachONL.Startup))]
namespace WebSachONL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
