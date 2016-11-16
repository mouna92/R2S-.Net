using R2S.GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace R2S.GUI.Controllers.JobField
{
    public class JobFielsController : Controller
    {
        // GET: JobFiels
        public ActionResult Index()
        {
            jobfieldRestModels JFR = new jobfieldRestModels();
            ViewBag.form = JFR.show(); 
            return View();
        }
    }
}