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


            config.Routes.MapHttpRoute(
                 name: "AddModules",
                  routeTemplate: "api/Search/AddModules",
                      defaults: new { controller = "Courses", action = "AddModules" }
             );

            config.Routes.MapHttpRoute(
                name: "GetCourses",
                 routeTemplate: "api/Search/GetCourses",
                     defaults: new { controller = "Courses", action = "GetCourses" }
            );

            config.Routes.MapHttpRoute(
               name: "GetModules",
                routeTemplate: "api/Search/GetModules",
                    defaults: new { controller = "Courses", action = "GetModules" }
           );

            config.Routes.MapHttpRoute(
               name: "AddCourseModules",
                routeTemplate: "api/Search/AddCourseModules",
                    defaults: new { controller = "Courses", action = "AddCourseModules" }
           );


            config.Routes.MapHttpRoute(
               name: "GetStudents",
                routeTemplate: "api/Search/GetStudents",
                    defaults: new { controller = "Courses", action = "GetStudents" }
           );


            config.Routes.MapHttpRoute(
              name: "CheckUser",
               routeTemplate: "api/Search/CheckUser",
                   defaults: new { controller = "Courses", action = "CheckUser" }
          );

            config.Routes.MapHttpRoute(
             name: "GetCourseModules",
              routeTemplate: "api/Search/GetCourseModules",
                  defaults: new { controller = "Courses", action = "GetCourseModules" }
         );
            
            //config.Routes.MapHttpRoute(
            //  name: "getCourses",
            //   routeTemplate: "api/Search/getCourses",
            //       defaults: new { controller = "Courses", action = "getCourses" }
            // );

        }
    }
}
