using System.Web.Http;
using Microsoft.Owin;
using Owin;
using Proto.WebApi;
using Proto.WebApi.CompositionRoot;

[assembly: OwinStartup(typeof(Startup))]
namespace Proto.WebApi
{
    public 
        class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            Bootstrapper.Bootstrap(config);

            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}