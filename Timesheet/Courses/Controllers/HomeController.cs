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
using System.IO;
using Dropbox.Api.Files;


namespace Courses.Controllers
{
    public class HomeController : Controller
    {
        TimesheetController Repository = new TimesheetController();
        Employees s = new Employees();

           
        public ActionResult Index()
        {
            
            //    c.InsertStudent();

            if (Request.IsAuthenticated)
            {

                s.Username = @User.Identity.GetUserName();

                var r = Repository.CheckUser(s);
                
                    ViewBag.role = r.Role;
                 
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

        public ActionResult Reports()
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

        public ActionResult MyTimeSheet()
        {
            ViewBag.Message = "Your application description page.";

            if (Request.IsAuthenticated)
            {
                s.Username = @User.Identity.GetUserName();

                var r = Repository.CheckUser(s);


                if (r.Role == 2)
                {
                    ViewBag.role = r.Role;
                    return View();
                }
                else
                    return RedirectToAction("Index", "Home");



            }
            else
            {
                return RedirectToAction("Login", "Account");

            }


        }

        public ActionResult TimeEntryPeriod()
        {
            ViewBag.Message = "Your application description page.";

            if (Request.IsAuthenticated)
            {
                s.Username = @User.Identity.GetUserName();

                var r = Repository.CheckUser(s);


                if (r.Role == 2)
                {
                    ViewBag.role = r.Role;
                    return View();
                }
                else
                    return RedirectToAction("Index", "Home");



            }
            else
            {
                return RedirectToAction("Login", "Account");

            }


        }


        public ActionResult TimeEntryPeriod2()
        {
            ViewBag.Message = "Your application description page.";

            if (Request.IsAuthenticated)
            {
                s.Username = @User.Identity.GetUserName();

                var r = Repository.CheckUser(s);


                if (r.Role == 2)
                {
                    ViewBag.role = r.Role;
                    return View();
                }
                else
                    return RedirectToAction("Index", "Home");



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
        
     

       
        
        public ActionResult AddProject()
        {
            ViewBag.Message = "Your Courses Page";
            
            if (Request.IsAuthenticated)
            {
                s.Username = @User.Identity.GetUserName();

                var r = Repository.CheckUser(s);


                if (r.Role == 1)
                {
                    ViewBag.role = r.Role;
                    return View();
                }
                else
                    return RedirectToAction("Index", "Home");



            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }
        public ActionResult AddCompany()
        {
            ViewBag.Message = "Your Module Page";
           

            if (Request.IsAuthenticated)
            {
                s.Username = @User.Identity.GetUserName();

                var r = Repository.CheckUser(s);


                if (r.Role == 1)
                {
                    ViewBag.role = r.Role;
                    return View();
                }
                else
                    return RedirectToAction("Index", "Home");


            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }
        [AllowAnonymous]
        public ActionResult AddEmployees()
        {
            ViewBag.Messgae = "Your User Page";
            

            if (Request.IsAuthenticated)
            {
                s.Username = @User.Identity.GetUserName();

                var r = Repository.CheckUser(s);

                if (r.Role == 1)
                {
                    ViewBag.role = r.Role;
                    return View();
                }
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
        public async Task<ActionResult> AddEmployees(RegisterViewModel model)
        {
            TimesheetRepositrory c = new TimesheetRepositrory();
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



       
        public ActionResult CompanyEmployees()
        {
            ViewBag.Messgae = "Your User Page";


            if (Request.IsAuthenticated)
            {
                s.Username = @User.Identity.GetUserName();

                var r = Repository.CheckUser(s);


                if (r.Role == 1)
                {
                    ViewBag.role = r.Role;
                    return View();
                }
                else
                    return RedirectToAction("Index", "Home");


            }
            else
            {
                return RedirectToAction("Login", "Account");

            }


        }






      

    }
}