using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Courses
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);


            config.Routes.MapHttpRoute(
                     name: "AddCourse",
                      routeTemplate: "api/Search/AddCourse",
                          defaults: new { controller = "Courses", action = "AddCourse" }
              );


             
      



        }
    }
}
