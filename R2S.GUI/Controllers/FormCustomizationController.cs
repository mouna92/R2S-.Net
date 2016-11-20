using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using R2S.GUI.Models;

namespace R2S.GUI.Controllers
{
    public class FormCustomizationController : BaseController
    {
        // GET: FormCustomization
        public ActionResult Job()
        {
            return View(new JobFieldViewModel() {User = CurrentUser});
        }
    }
}