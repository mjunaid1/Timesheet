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
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult USER()
        {
            ViewBag.Message = "Your User PAGE";

            return View();
        }

        public ActionResult Admin()
        {
            ViewBag.Message = "Your Admin PAGE";

            return View();
        }
        
        public ActionResult Course()
        {
            ViewBag.Message = "Your Courses Page";
            return View();
        }
        public ActionResult Module()
        {
            ViewBag.Message = "Your Module Page";
            return View();
        }
        public ActionResult AddUser()
        {
            ViewBag.Messgae = "Your User Page";
                return View();
        }

        public ActionResult UserCourses()
        {
            ViewBag.Messgae = "Your User Page";
            return View();
        }
        public ActionResult CourseModule()
        {
            ViewBag.Messgae = "Your User Page";
            return View();
        }

    }
}