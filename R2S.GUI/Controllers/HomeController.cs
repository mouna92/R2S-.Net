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
    public class HomeController : BaseController
    {
        
        [Authorize(Roles = "RecruitmentManager, ChiefHumanRessource")]
        public ActionResult Index()
        {
            return View(new BaseViewModel() {User = CurrentUser });
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