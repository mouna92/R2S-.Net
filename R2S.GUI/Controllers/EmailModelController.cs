using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using R2S.Data.Models;
using R2S.Service;

namespace R2S.GUI.Controllers
{
    public class EmailModelController : Controller
    {
        IEmailModelService email;
        public EmailModelController(IEmailModelService email)
        {
            this.email = email;
        }
        // GET: EmailModel
        public ActionResult Index()
        {
            var e = email.GetMany();
            return View(e);
        }

        // GET: EmailModel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmailModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmailModel/Create
        [HttpPost]
        
        public ActionResult Create(emailmodel e)
        {

            if (ModelState.IsValid)
            {
                email.Add(e);
                return RedirectToAction("Index");

            }

            else { return View(email);}

        }

        // GET: EmailModel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmailModel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmailModel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmailModel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
