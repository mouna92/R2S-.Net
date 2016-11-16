using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using R2S.Data.Models;
using R2S.Service;

namespace R2S.GUI.Controllers
{
    public class JobsController : Controller
    {
        private IJobService service = new JobService();

        // GET: jobs
        public ActionResult Index()
        {
            return View(service.GetMany().ToList());
        }

        // GET: jobs/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            job job = service.GetById(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: jobs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,description,name,salary,status")] job job)
        {
            if (ModelState.IsValid)
            {
                service.Add(job);
                service.commit();
                return RedirectToAction("Index");
            }

            return View(job);
        }

        // GET: jobs/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            job job = service.GetById(id);

            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,description,name,salary,status")] job job)
        {
            if (ModelState.IsValid)
            {
                service.Update(job);
                service.commit();
                return RedirectToAction("Index");
            }
            return View(job);
        }

        // GET: jobs/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            job job = service.GetById(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            job job = service.GetById(id);
            service.Delete(job);
            service.commit();
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
