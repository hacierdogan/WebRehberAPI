using Newtonsoft.Json.Serialization;
using Rehber.API.Attributes;
using Rehber.API.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Rehber.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Web API sistemsel hata mesajı attribute'u
            config.Filters.Add(new ApiExceptionAttribute());

            //Web API Login ve Yetkilendirme
            config.MessageHandlers.Add(new APIKeyHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Formati duzenle
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            //Basliklari kucuk harfe cevir
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
