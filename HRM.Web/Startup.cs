using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRM.Web.Startup))]
namespace HRM.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
            
        }
    }
}
