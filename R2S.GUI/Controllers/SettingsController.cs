using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using R2S.Data.Models;
using R2S.GUI.Models;
using R2S.Service;

namespace R2S.GUI.Controllers
{
    public class SettingsController : BaseController
    {
        private IJobFieldService _jobFieldService =  new JobFieldService();

        // GET: Settings
        [HttpGet]
        public ActionResult JobForm()
        {
            return View(new JobFieldViewModel() { User = CurrentUser });
        }

        [HttpPost]
        public ActionResult Add()
        {
            string postData = new System.IO.StreamReader(Request.InputStream).ReadToEnd();
            string data = HttpUtility.UrlDecode(postData);
            JObject json = JObject.Parse(data);

            var text = json.GetValue("text");
            var radio = json.GetValue("radio");
            var checkbox = json.GetValue("checkox");

            foreach (var c in checkbox.Values())
            {
                jobfield field = new jobfield() { fieldName = c.ToString(), fieldType = jobfield.Checkbox };
                _jobFieldService.Add(field);
            }
            foreach (var c in text.Values())
            {
                jobfield field = new jobfield() { fieldName = c.ToString(), fieldType = jobfield.TextField };
                _jobFieldService.Add(field);
            }
            foreach (var c in radio.Values())
            {
                jobfield field = new jobfield() { fieldName = c.ToString(), fieldType = jobfield.Radiobox };
                _jobFieldService.Add(field);
            }

            _jobFieldService.commit();

            return Json("done");
        }
    }
}