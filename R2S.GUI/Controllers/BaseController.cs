using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using R2S.GUI.Models;

namespace R2S.GUI.Controllers
{
    public class BaseController : Controller
    {
        private UserManager _userManager;

        public UserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<UserManager>(); }
            private set { _userManager = value; }
        }

        public User CurrentUser => UserManager.FindByIdAsync(User.Identity.GetUserId<long>()).Result;
    }
}