using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_Doc_Sach.Startup))]
namespace Web_Doc_Sach
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
