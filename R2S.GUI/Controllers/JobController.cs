using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using R2S.Data.Models;
using R2S.GUI.Models;
using R2S.Service;

namespace R2S.GUI.Controllers
{
    public class JobController : BaseController
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
        public ActionResult JobStatus()
        {
            int st1 = service.StatisticJobOpen();
            int st2 = service.StatisticJobClosed();

            List<JobModel> l = new List<JobModel>();




            {
                l.Add(new JobModel
                {
                    x1=st1,
                    x2=st2,


                });
            }

            return View(l);
        }
        public async Task<ActionResult> ViewJob()
        {
            ViewBag.Message = "Your products page.";
            //job jo = new job();
            string urlAction = String.Format("/tn.esprit.R2S-web/resources/api/job/statistic/{0}", "OPEN");
            string urlAction1 = String.Format("/tn.esprit.R2S-web/resources/api/job/statistic/{0}", "CLOSED");
            int joi = await GetWSObject<int>(urlAction);
            int joi1 = await GetWSObject<int>(urlAction1);
            ViewBag.res = joi;
            ViewBag.res2 = joi1;
            return View();
        }

    }
}
