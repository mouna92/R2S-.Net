using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using R2S.Data.Models;
using R2S.GUI.Models;
using R2S.Service;

namespace R2S.GUI.Controllers
{
    public class FormCustomizationController : BaseController
    {
        private IJobFieldService _jobFieldService = new JobFieldService();
        private ICandidateFieldService _candidateFieldService = new CandidateFieldService();

        // GET: Settings
        [HttpGet]
        public ActionResult Job()
        {
            return View(new JobFieldViewModel() { User = CurrentUser });
        }

        [HttpGet]
        public ActionResult Candidate()
        {
            return View(new JobFieldViewModel() { User = CurrentUser });
        }

        [HttpPost]
        public ActionResult AddJobFields()
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

        [HttpPost]
        public ActionResult AddCandidateFields()
        {
            string postData = new System.IO.StreamReader(Request.InputStream).ReadToEnd();
            string data = HttpUtility.UrlDecode(postData);
            JObject json = JObject.Parse(data);

            var text = json.GetValue("text");
            var radio = json.GetValue("radio");
            var checkbox = json.GetValue("checkox");

            foreach (var c in checkbox.Values())
            {
                candidatefield field = new candidatefield() { fieldName = c.ToString(), fieldType = jobfield.Checkbox };
                _candidateFieldService.Add(field);
            }
            foreach (var c in text.Values())
            {
                candidatefield field = new candidatefield() { fieldName = c.ToString(), fieldType = jobfield.TextField };
                _candidateFieldService.Add(field);
            }
            foreach (var c in radio.Values())
            {
                candidatefield field = new candidatefield() { fieldName = c.ToString(), fieldType = jobfield.Radiobox };
                _candidateFieldService.Add(field);
            }

            _candidateFieldService.commit();

            return Json("done");
        }
    }
}