using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Proto.Web.Startup))]
namespace Proto.Web
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
