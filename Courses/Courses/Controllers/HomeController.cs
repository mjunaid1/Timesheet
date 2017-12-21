using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Courses.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
          //  CoursesRepository c = new CoursesRepository();
            //     c.InsertStudent();

            if (Request.IsAuthenticated)
            {
                return View();

                //var task = Task.Run((Func<Task>)HomeController.Run);
                //task.Wait();

                //Task.Run(Run);

            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            //  CoursesRepository c = new CoursesRepository();
            //     c.InsertStudent();

            if (Request.IsAuthenticated)
            {
                return View();

                //var task = Task.Run((Func<Task>)HomeController.Run);
                //task.Wait();

                //Task.Run(Run);

            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            //  CoursesRepository c = new CoursesRepository();
            //     c.InsertStudent();

            if (Request.IsAuthenticated)
            {
                return View();

                //var task = Task.Run((Func<Task>)HomeController.Run);
                //task.Wait();

                //Task.Run(Run);

            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }
        
        public ActionResult USER()
        {
            ViewBag.Message = "Your User PAGE";

            //  CoursesRepository c = new CoursesRepository();
            //     c.InsertStudent();

            if (Request.IsAuthenticated)
            {
                return View();

                //var task = Task.Run((Func<Task>)HomeController.Run);
                //task.Wait();

                //Task.Run(Run);

            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }

        public ActionResult Admin()
        {
            ViewBag.Message = "Your Admin PAGE";

            //  CoursesRepository c = new CoursesRepository();
            //     c.InsertStudent();

            if (Request.IsAuthenticated)
            {
                return View();

                //var task = Task.Run((Func<Task>)HomeController.Run);
                //task.Wait();

                //Task.Run(Run);

            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }
        
        public ActionResult Course()
        {
            ViewBag.Message = "Your Courses Page";
            //  CoursesRepository c = new CoursesRepository();
            //     c.InsertStudent();

            if (Request.IsAuthenticated)
            {
                return View();

                //var task = Task.Run((Func<Task>)HomeController.Run);
                //task.Wait();

                //Task.Run(Run);

            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }
        public ActionResult Module()
        {
            ViewBag.Message = "Your Module Page";
            //  CoursesRepository c = new CoursesRepository();
            //     c.InsertStudent();

            if (Request.IsAuthenticated)
            {
                return View();

                //var task = Task.Run((Func<Task>)HomeController.Run);
                //task.Wait();

                //Task.Run(Run);

            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }
        public ActionResult AddUser()
        {
            ViewBag.Messgae = "Your User Page";
            //  CoursesRepository c = new CoursesRepository();
            //     c.InsertStudent();

            if (Request.IsAuthenticated)
            {
                return View();

                //var task = Task.Run((Func<Task>)HomeController.Run);
                //task.Wait();

                //Task.Run(Run);

            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }

        public ActionResult UserCourses()
        {
            ViewBag.Messgae = "Your User Page";
            //  CoursesRepository c = new CoursesRepository();
            //     c.InsertStudent();

            if (Request.IsAuthenticated)
            {
                return View();

                //var task = Task.Run((Func<Task>)HomeController.Run);
                //task.Wait();

                //Task.Run(Run);

            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }
        public ActionResult CourseModule()
        {
            ViewBag.Messgae = "Your User Page";
            //  CoursesRepository c = new CoursesRepository();
            //     c.InsertStudent();

            if (Request.IsAuthenticated)
            {
                return View();

                //var task = Task.Run((Func<Task>)HomeController.Run);
                //task.Wait();

                //Task.Run(Run);

            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }

    }
}