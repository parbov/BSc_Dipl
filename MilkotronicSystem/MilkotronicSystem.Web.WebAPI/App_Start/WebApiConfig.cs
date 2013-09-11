using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MilkotronicSystem.Web.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "PcbsApi",
                routeTemplate: "api/pcbs/{action}",
                defaults: new { controller="pcbs" }
                );

            config.Routes.MapHttpRoute(
                name: "UsersApi",
                routeTemplate:"api/users/{action}",
                defaults: new
                {
                    controller = "users"
                }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
