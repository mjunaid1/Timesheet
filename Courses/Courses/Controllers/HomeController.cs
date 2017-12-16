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
        public ActionResult newIndex()
        {
            ViewBag.Message = "Your HOME PAGE";

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
        public ActionResult Login()
        {
            ViewBag.Message = "Your Login PAGE";
            return View();
        }
    }
}