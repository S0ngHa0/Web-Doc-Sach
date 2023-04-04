using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Đồ_án_của_Thái.Startup))]
namespace Đồ_án_của_Thái
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
