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
    public class UsersController : Controller
    {
        private IUserService _service = new UserService();
        // GET: users
        public ActionResult Index()
        {
            var users = _service.GetMany();
            return View(users.ToList());
        }

        // GET: users/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _service.GetById(id);
            user user = _service.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: users/Create
        public ActionResult Create()
        {
            ViewBag.referee_cin = new SelectList(_service.GetMany(), "cin", "user_role");
            return View();
        }

        // POST: users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cin,user_role,active,city,country,state,street,birthday,email,firstname,gender,lastname,password,tel,username,referee_cin")] user user)
        {
            if (ModelState.IsValid)
            {
                _service.Add(user);
                _service.commit();
                return RedirectToAction("Index");
            }

            ViewBag.referee_cin = new SelectList(_service.GetMany(), "cin", "user_role", user.referee_cin);
            return View(user);
        }

        // GET: users/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = _service.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.referee_cin = new SelectList(_service.GetMany(), "cin", "user_role", user.referee_cin);
            return View(user);
        }

        // POST: users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cin,user_role,active,city,country,state,street,birthday,email,firstname,gender,lastname,password,tel,username,referee_cin")] user user)
        {
            if (ModelState.IsValid)
            {
                _service.Update(user);
                return RedirectToAction("Index");
            }
            ViewBag.referee_cin = new SelectList(_service.GetMany(), "cin", "user_role", user.referee_cin);
            return View(user);
        }

        // GET: users/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = _service.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = _service.GetById(id);
           _service.Delete(user);
            _service.commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //_service.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
