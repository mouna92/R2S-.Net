using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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