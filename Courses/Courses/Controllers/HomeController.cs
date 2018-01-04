using Courses.DataAccess;
using Courses.Models;
using Dropbox.Api;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using System.Net;
using Courses.Entities;
using System.Data;

namespace Courses.Controllers
{
    public class HomeController : Controller
    {
        CoursesRepository Repository = new CoursesRepository();
        Students s = new Students();

      
        public ActionResult Index()
        {
            
            //    c.InsertStudent();

            if (Request.IsAuthenticated)
            {
               

                //var task = Task.Run((Func<Task>)HomeController.Run());
                //task.Wait();

                //Task.Run(Run);
                return View();
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
                s.Username = @User.Identity.GetUserName();

                var r = Repository.CheckUser(s);


                if (r.Role == 1)
                    return View();
                else
                    return RedirectToAction("Index", "Home");


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

                s.Username = @User.Identity.GetUserName();

                var r = Repository.CheckUser(s);


                if (r.Role == 1)
                    return View();
                else
                    return RedirectToAction("Index", "Home");


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
                s.Username = @User.Identity.GetUserName();

                var r = Repository.CheckUser(s);


                if (r.Role == 1)
                    return View();
                else
                    return RedirectToAction("Index", "Home");



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
                s.Username = @User.Identity.GetUserName();

                var r = Repository.CheckUser(s);


                if (r.Role == 1)
                    return View();
                else
                    return RedirectToAction("Index", "Home");


            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }
        [AllowAnonymous]
        public ActionResult AddUser()
        {
            ViewBag.Messgae = "Your User Page";
            

            if (Request.IsAuthenticated)
            {
                s.Username = @User.Identity.GetUserName();

                var r = Repository.CheckUser(s);


                if (r.Role == 1)
                    return View();
                else
                    return RedirectToAction("Index", "Home");


            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }


        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddUser(RegisterViewModel model)
        {
            CoursesRepository c = new CoursesRepository();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                 //   await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    c.UpdateRole(model.Role, model.Email);
                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    //  return RedirectToAction("Index", "Home");
                    ViewBag.msg = "Account Successfully Created..";
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }



        public ActionResult UserCourses()
        {
            ViewBag.Messgae = "Your User Page";
           
            if (Request.IsAuthenticated)
            {
                s.Username = @User.Identity.GetUserName();

                var r = Repository.CheckUser(s);


                if (r.Role == 1)
                    return View();
                else
                    return RedirectToAction("Index", "Home");

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
                s.Username = @User.Identity.GetUserName();

                var r = Repository.CheckUser(s);


                if (r.Role == 1)
                    return View();
                else
                    return RedirectToAction("Index", "Home");


            }
            else
            {
                return RedirectToAction("Login", "Account");

            }


        }


        public ActionResult Modules(int? id)
        {            

            CoursesRepository Repository = new CoursesRepository();
            if (Request.IsAuthenticated)
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                int Id = (int)id;
                List<Modules> data = Repository.GetCourseModules_Single_User(@User.Identity.GetUserName(), Id);

                foreach(var a in data)
                {
                    var path = @"/Courses" + "/" + a.CourseName + "/" + "Modules/" + a.ModuleName;

                    //var task = Task. 
                    //    ((Func<Task>)HomeController.Run(8));
                    //task.Wait();

                    //Task.Run(Run(8));

                }

                ViewBag.CourseId = id;
                return View();


            }
            else
            {
                return RedirectToAction("Login", "Account");

            }

        }


        //static async Task Run()
        //{
        //    using (var dbx = new DropboxClient("M9-AXilUwLAAAAAAAAAAE5oPgmq8_7-AqcHjs9K7a9UixgirDSrxt4RzeRmHEzPD"))
        //    {
             
        //        var full = await dbx.Users.GetCurrentAccountAsync();

        //        Console.WriteLine("{0} - {1}", full.Name.DisplayName, full.Email);


        //        //    await Upload(dbx, @"/MyApp/test", "test.txt", "Testing!");

        //        //  await p.UploadDoc();

        //        using (var abc1 = await dbx.Files.DownloadAsync(@"/Courses/xyz/Modules/Lesson 2/bbc.txt"))
        //        {
        //            //foreach (var a in abc1.Entries)
        //            //{
        //            Console.WriteLine(await abc1.GetContentAsStringAsync() + "  "  );
        //        }
        //        //}

        //        var abc12 = await dbx.Files.ListFolderAsync(@"/Courses/");

        //        //await Upload(dbx, @"/MyApp/test", "test.txt", "Testing!");
        //        Console.ReadLine();
        //    }
        //}


        static async Task Run(int id)
        {
            using (var dbx = new DropboxClient("M9-AXilUwLAAAAAAAAAAE5oPgmq8_7-AqcHjs9K7a9UixgirDSrxt4RzeRmHEzPD"))
            {
                string data = null;

     //           var list = await dbx.Files.ListFolderAsync();

                // show folders then files
                //foreach (var item in list.Entries)
                //{
                    
                //    data = item.Name;
                 
                //}

              

            }
        }

    }
}