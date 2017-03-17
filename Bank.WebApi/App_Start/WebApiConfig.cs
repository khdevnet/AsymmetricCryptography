using System.Web.Http;
using BankApi.Library.MessageHandlers;

namespace Bank.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            log4net.Config.XmlConfigurator.Configure();
            // Web API configuration and services
            config.MessageHandlers.Add(new DecryptMessageHandler());
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}