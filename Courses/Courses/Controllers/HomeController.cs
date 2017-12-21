using Courses.DataAccess;
using Dropbox.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Courses.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //CoursesRepository c = new CoursesRepository();
            //    c.InsertStudent();

            if (Request.IsAuthenticated)
            {
                return View();

                var task = Task.Run((Func<Task>)HomeController.Run);
                task.Wait();

                Task.Run(Run);

            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

          

            if (Request.IsAuthenticated)
            {
                return View();

                

            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

          
            if (Request.IsAuthenticated)
            {
                return View();

           

            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }
        
        public ActionResult USER()
        {
            ViewBag.Message = "Your User PAGE";

          

            if (Request.IsAuthenticated)
            {
                return View();

             
            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }

        public ActionResult Admin()
        {
            ViewBag.Message = "Your Admin PAGE";

            

            if (Request.IsAuthenticated)
            {
                return View();

              

            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }
        
        public ActionResult Course()
        {
            ViewBag.Message = "Your Courses Page";
          
            if (Request.IsAuthenticated)
            {
                return View();

               

            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }
        public ActionResult Module()
        {
            ViewBag.Message = "Your Module Page";
           

            if (Request.IsAuthenticated)
            {
                return View();


            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }
        public ActionResult AddUser()
        {
            ViewBag.Messgae = "Your User Page";
            

            if (Request.IsAuthenticated)
            {
                return View();

       
            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }

        public ActionResult UserCourses()
        {
            ViewBag.Messgae = "Your User Page";
           
            if (Request.IsAuthenticated)
            {
                return View();

            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }
        public ActionResult CourseModule()
        {
            ViewBag.Messgae = "Your User Page";


            if (Request.IsAuthenticated)
            {
                return View();

              
            }
            else
            {
                return RedirectToAction("Login", "Account");

            }


        }


        static async Task Run()
        {
            using (var dbx = new DropboxClient("M9-AXilUwLAAAAAAAAAAE5oPgmq8_7-AqcHjs9K7a9UixgirDSrxt4RzeRmHEzPD"))
            {
             
                var full = await dbx.Users.GetCurrentAccountAsync();

                Console.WriteLine("{0} - {1}", full.Name.DisplayName, full.Email);


                //    await Upload(dbx, @"/MyApp/test", "test.txt", "Testing!");

                //  await p.UploadDoc();

                using (var abc1 = await dbx.Files.DownloadAsync(@"/Courses/xyz/Modules/Lesson 2/bbc.txt"))
                {
                    //foreach (var a in abc1.Entries)
                    //{
                    Console.WriteLine(await abc1.GetContentAsStringAsync() + "  "  );
                }
                //}


                //await Upload(dbx, @"/MyApp/test", "test.txt", "Testing!");
                Console.ReadLine();
            }
        }
    }
}