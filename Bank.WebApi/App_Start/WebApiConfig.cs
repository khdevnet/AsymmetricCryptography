using System.Web.Http;
using BankApi.Library.MessageHandlers;
using log4net.Config;

namespace Bank.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            XmlConfigurator.Configure();

            // Web API configuration and services
            config.MessageHandlers.Add(new ReceiverCryptographyMessageHandler());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}