using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RestfulWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes

            /*start THIS IS THE TEMPLATE VERSION USED AS DEFAULT */

            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            /*end THIS IS THE TEMPLATE VERSION USED AS DEFAULT */

            /*this is the custom version for your routing skills*/
            config.MapHttpAttributeRoutes();

        }
    }
}
