using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PametniParking.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Ukloni XML format - koristimo samo JSON
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Spreci beskonacne petlje pri serijalizaciji (npr. A->B->A)
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }
    }
}
