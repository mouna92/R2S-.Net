﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using R2S.Data.Models;
using R2S.Service;
using R2S.GUI.Models;
using R2S.Service.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;

namespace R2S.GUI.Controllers
{
    public class JobsController : BaseController
    {
        private IJobService _jobService = new JobService();
        private ISkillService _skillService = new SkillService();

        public ActionResult Index(int? skillId)
        {
            if(skillId != null)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:8080/tn.esprit.R2S-web/resources/api/job");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("?skillId=" + skillId).Result; // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    var jobs = response.Content.ReadAsAsync<IEnumerable<job>>().Result;
                    return View(new JobViewModel()
                    {
                        User = CurrentUser,
                        Jobs = jobs
                    });
                }
            }

            skill disabledSkill = new skill() { id = 0, name = "Select a Skill" };

            List<skill> disabledSkills = new List<skill>() { disabledSkill };
            List<skill> list = _skillService.GetMany().ToList();

            list.Insert(0, disabledSkill);


            ViewBag.referee_cin = new SelectList(list, "cin", "firstname", disabledSkills);
            ViewBag.skills = new SelectList(list, "id", "name");

            return View(new JobViewModel() { User = CurrentUser,
                Jobs = _jobService.GetMany().ToList() });
        }

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            job job = _jobService.GetById(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(new JobViewDetailsModel() { User = CurrentUser, Job = job });
        }

        public ActionResult AddReward(int id)
        {
            job job = _jobService.GetById(id);

            if (job == null)
            {
                return HttpNotFound();
            }

            return View(new JobViewDetailsModel() { User = CurrentUser, Job = job });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult AddReward([Bind(Include = "points,progress,job_id")] reward reward)
        {
            if(reward == null)
            {
                return HttpNotFound();
            }

            job job = _jobService.GetById((int)reward.job_id);
            
            if (job == null)
            {
                return HttpNotFound();
            }

            job.rewards.Add(reward);

            _jobService.Update(job);
            _jobService.commit();

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View((new JobViewModel() { User = CurrentUser }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "description,name,salary,status")] job job)
        {
            if (ModelState.IsValid)
            {
                _jobService.Add(job);
                _jobService.commit();
                return RedirectToAction("Index");
            }

            return View(job);
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            job job = _jobService.GetById(id);

            if (job == null)
            {
                return HttpNotFound();
            }
            return View(new JobViewDetailsModel() { User = CurrentUser, Job = job });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,description,name,salary,status")] job job)
        {
            if (ModelState.IsValid)
            {
                _jobService.Update(job);
                _jobService.commit();
                return RedirectToAction("Index");
            }
            return View(job);
        }

        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            job job = _jobService.GetById(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(new JobViewDetailsModel() { User = CurrentUser, Job = job });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(JobViewDetailsModel model, int id)
        {
            job job = _jobService.GetById(id);

            try
            {
                _jobService.Delete(job);
                _jobService.commit();
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message + " " + e.GetBaseException().Message;
                model.Job = job; 
                return View(model);
            }



            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //service.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
