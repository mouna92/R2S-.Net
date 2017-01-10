﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using R2S.Data.Models;
using R2S.GUI.Models;
using R2S.Service;

namespace R2S.GUI.Controllers
{
    public class UsersController : BaseController
    {
        private IUserService _service = new UserService();


        // GET: users
        public ActionResult Index(string role = null)
        {
            var users = (IEnumerable<user>)null;

            if (role != null)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:8090/tn.esprit.R2S-web/resources/api/users");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("?role=" + role).Result; // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    users = response.Content.ReadAsAsync<IEnumerable<user>>().Result;
                }
            }

            if (users == null)
            {
                users = _service.GetMany();
            }

            return View(new UsersIndexViewModel() { User = CurrentUser, Users = users.ToList() });
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
            return View(new UsersDetailsViewModel() { User = CurrentUser, NewUser = user });
        }

        // GET: users/Create
        public ActionResult Create()
        {
            List<user> list = _service.GetMany().ToList();
            user disabledUser = new user() { cin = 0, firstname = "Select a Referer" };

            List<user> disabledUsers = new List<user>() { disabledUser };

            list.Insert(0, disabledUser);


            ViewBag.referee_cin = new SelectList(list, "cin", "firstname", disabledUsers);

            return View(new UsersDetailsViewModel() { User = CurrentUser });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsersDetailsViewModel model
             /*[Bind(
                  Include =
                      "cin,active,city,country,state,street,birthday,email,firstname,gender,lastname,password,tel,username,referee_cin"
              )] user user*/)
        {
            var user = new user();
            if (ModelState.IsValid)
            {
                user.cin = Convert.ToInt64(Request["cin"]);
                user.active = Request["active"] == "1";
                user.city = Request["city"];
                user.country = Request["country"];
                user.state = Request["state"];
                user.street = Request["street"];
                user.birthday = Convert.ToDateTime(Request["birthday"]);
                user.email = Request["email"];
                user.firstname = Request["firstname"];
                user.lastname = Request["lastname"];
                user.gender = Request["gender"];
                user.password = Request["password"];
                user.username = Request["username"];
                user.tel = Request["tel"];
                user.referee_cin = Convert.ToInt32(Request["referee_cin"]);


                MyPasswordHasher hasher = new MyPasswordHasher();

                switch (Request["role"])
                {
                    case "Employee":
                        Employee employe = new Employee()
                        {
                            cin = user.cin,
                            firstname = user.firstname,
                            lastname = user.lastname,
                            username = user.username,
                            password = hasher.HashPassword(user.password).ToLower(),
                            birthday = user.birthday,
                            email = user.email,
                            gender = user.gender,
                            country = user.country,
                            city = user.city,
                            state = user.state,
                            street = user.street,
                            tel = user.tel,
                            credibility = 0,
                            active = true
                        };

                        _service.Add(employe);

                        break;

                    case "Candidate":
                        Candidate candidate = new Candidate()
                        {
                            cin = user.cin,
                            firstname = user.firstname,
                            lastname = user.lastname,
                            username = user.username,
                            password = hasher.HashPassword(user.password).ToLower(),
                            birthday = user.birthday,
                            email = user.email,
                            gender = user.gender,
                            country = user.country,
                            city = user.city,
                            state = user.state,
                            street = user.street,
                            tel = user.tel,
                            referee_cin = user.referee_cin,
                            active = true
                        };
                        _service.Add(candidate);
                        break;

                    case "RecruitmentManager":
                        RecruitementManager recruitementManager = new RecruitementManager()
                        {
                            cin = user.cin,
                            firstname = user.firstname,
                            lastname = user.lastname,
                            username = user.username,
                            password = hasher.HashPassword(user.password).ToLower(),
                            birthday = user.birthday,
                            email = user.email,
                            gender = user.gender,
                            country = user.country,
                            city = user.city,
                            state = user.state,
                            street = user.street,
                            tel = user.tel,
                            active = true
                        };
                        _service.Add(recruitementManager);
                        break;

                    default:
                        break;
                }
                //_service.Add(user);
                try
                {
                    _service.commit();
                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message + " " + e.GetBaseException().Message;
                    ViewBag.referee_cin = new SelectList(_service.GetMany(), "cin", "firstname");
                    return View();
                }


                return RedirectToAction("Index");
            }

            ViewBag.referee_cin = new SelectList(_service.GetMany(), "cin", "firstname");
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
            ViewBag.referee_cin = new SelectList(_service.GetMany(), "cin", "firstname");

            return View(new UsersDetailsViewModel() { User = CurrentUser, NewUser = user });
        }

        // POST: users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(
                 Include =
                     "cin,active,city,country,state,street,birthday,email,firstname,gender,lastname,password,tel,username,referee_cin"
             )] user NewUser)
        {
            if (ModelState.IsValid)
            {
                _service.Update(NewUser);
                _service.commit();
                return RedirectToAction("Index");
            }
            ViewBag.referee_cin = new SelectList(_service.GetMany(), "cin", "firstname");
            return View(NewUser);
        }

        // GET: users/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user NewUser = _service.GetById(id);
            if (NewUser == null)
            {
                return HttpNotFound();
            }
            return View(new UsersDetailsViewModel() { User = CurrentUser, NewUser = NewUser });
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

        [HttpPost, ActionName("ChangeState")]
        public ActionResult ChangeState(int id, Boolean state)
        {
            user user = _service.GetById(id);
            user.active = state;
            _service.Update(user);
            _service.commit();

            return Content("success");
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