using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using R2S.Data.Models;
using R2S.Service.Interfaces;
using R2S.Service;
using R2S.GUI.Models;

namespace R2S.GUI.Controllers
{
    public class SkillsController : BaseController
    {
        private ISkillService _skillService = new SkillService();

        // GET: Skills
        public ActionResult Index()
        {
            return View(new SkillsViewModel() { User = CurrentUser, Skills = _skillService.GetMany().ToList() });
        }

        // GET: Skills/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            skill skill = _skillService.GetById((int)id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(new SkillsViewDetailsModel() { User = CurrentUser, Skill = skill});
        }

        // GET: Skills/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] skill skill)
        {
            if (ModelState.IsValid)
            {
                _skillService.Add(skill);
                _skillService.commit();
                
                return RedirectToAction("Index");
            }

            return View(new SkillsViewDetailsModel() { User = CurrentUser, Skill = skill });
        }

        // GET: Skills/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            skill skill = _skillService.GetById((int)id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(new SkillsViewDetailsModel() { User = CurrentUser, Skill = skill });
        }

        // POST: Skills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] skill skill)
        {
            if (ModelState.IsValid)
            {
                _skillService.Update(skill);
                _skillService.commit();
                return RedirectToAction("Index");
            }
            return View(new SkillsViewDetailsModel() { User = CurrentUser, Skill = skill });
        }

        // GET: Skills/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            skill skill = _skillService.GetById((int)id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(new SkillsViewDetailsModel() { User = CurrentUser, Skill = skill });
        }

        // POST: Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            skill skill = _skillService.GetById((int)id);
            _skillService.Delete(skill);
            _skillService.commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
