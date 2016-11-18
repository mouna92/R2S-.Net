using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace R2S.GUI.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        public ActionResult JobForm()
        {
            return View();
        }
    }
}