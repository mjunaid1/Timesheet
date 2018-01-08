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

            config.Routes.MapHttpRoute(
            name: "GetUserCourses",
             routeTemplate: "api/Search/GetUserCourses",
                 defaults: new { controller = "Courses", action = "GetUserCourses" }
        );

            config.Routes.MapHttpRoute(
           name: "AddUserCourses",
            routeTemplate: "api/Search/AddUserCourses",
                defaults: new { controller = "Courses", action = "AddUserCourses" }
       );

            config.Routes.MapHttpRoute(
         name: "GetCourses_Single_User",
          routeTemplate: "api/Search/GetCourses_Single_User",
              defaults: new { controller = "Courses", action = "GetCourses_Single_User" }
     );

            config.Routes.MapHttpRoute(
        name: "GetCourseModules_Single_User",
         routeTemplate: "api/Search/GetCourseModules_Single_User",
             defaults: new { controller = "Courses", action = "GetCourseModules_Single_User" }
    );


            config.Routes.MapHttpRoute(
      name: "GetExams",
       routeTemplate: "api/Search/GetExams",
           defaults: new { controller = "Courses", action = "GetExams" }
  );

            config.Routes.MapHttpRoute(
     name: "InsertExam",
      routeTemplate: "api/Search/InsertExam",
          defaults: new { controller = "Courses", action = "InsertExam" }
 );
            //config.Routes.MapHttpRoute(
            //  name: "getCourses",
            //   routeTemplate: "api/Search/getCourses",
            //       defaults: new { controller = "Courses", action = "getCourses" }
            // );

        }
        
    }
}
