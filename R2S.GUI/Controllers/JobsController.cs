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

namespace R2S.GUI.Controllers
{
    public class JobsController : BaseController
    {
        private IJobService _jobService = new JobService();

        public ActionResult Index()
        {
            return View(new JobViewModel() { User = CurrentUser, Jobs = _jobService.GetMany().ToList() });
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
