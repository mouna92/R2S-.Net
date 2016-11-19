using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using R2S.Data.Models;
using R2S.Service;

namespace R2S.GUI.Controllers
{
    public class EmailController : Controller
    {
        EmailModelService email = null;
        public EmailController()
        {
             email = new EmailModelService();

        }

        // GET: Email
        public ActionResult Index()
        {
            var e = email.GetMany();
            return View(e.ToList());

        }
        [HttpPost]
        public ActionResult Index(String search)
        {
            var e = email.GetMany().ToList();


            return View(e.Where(m => m.name.Contains(search)));
        }

        // GET: Email/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emailmodel e = email.GetById(id);
            if (e == null)
            {
                return HttpNotFound();
            }
            return View(e);
        }

        // GET: Email/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Email/Create
        [HttpPost]
        
            public ActionResult Create(emailmodel e)
        {

            if (ModelState.IsValid)
            {
                email.Add(e);
                email.commit();
                return RedirectToAction("Index");

            }

            else { return View(e); }

        }

        // GET: Email/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            emailmodel e = email.GetById(id);

            if (e == null)
            {
                return HttpNotFound();
            }
            return View(e);
        }

        // POST: Email/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "id,content,name,recruitmentManager_cin ")] emailmodel e)
        {
            if (ModelState.IsValid)
            {
                email.Update(e);
                email.commit();
                return RedirectToAction("Index");
            }
            return View(e);
        }

        // GET: Email/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emailmodel e = email.GetById(id);
            if (e == null)
            {
                return HttpNotFound();
            }
            return View(e);
        }

        // POST: Email/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            emailmodel e = email.GetById(id);
            email.Delete(e);
            email.commit();
            return RedirectToAction("Index");
        }
        }
    }

