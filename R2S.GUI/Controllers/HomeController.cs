using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using R2S.GUI.Models;

namespace R2S.GUI.Controllers
{
    public class HomeController : Controller
    {
        private UserManager _userManager;
        private RoleManager _roleManager;

        public UserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<UserManager>(); }
            private set { _userManager = value; }
        }
        

        [Authorize(Roles = "Employee")]
        public ActionResult Index()
        {

            var user = UserManager.FindByIdAsync(User.Identity.GetUserId<long>()).Result;
            

            return View(new BaseViewModel() {User = user});
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
    }
}