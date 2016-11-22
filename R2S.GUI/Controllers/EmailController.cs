using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using R2S.Data.Models;
using R2S.Service;

namespace R2S.GUI.Controllers
{
    public class EmailController : Controller
    {
        public static string parse;

        
        EmailModelService email = null;
        JobService job = null;
        UserService user = null;

        public EmailController()
        {
            email = new EmailModelService();
            job = new JobService();
            user = new UserService();
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

            else
            {
                return View(e);
            }

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

        public async Task<string> GetWSObjectEmail<T>(string uriActionString)
        {
            T returnValue =
                default(T);
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:8080/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync(uriActionString);
                    response.EnsureSuccessStatusCode();
                    return ((HttpResponseMessage) response).Content.ReadAsStringAsync().Result;
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.GetBaseException().Message);
                throw (e);
            }
        }

        public async Task<string> ParseEmail(long idModel , long idUser, long idJo)
        {

            
            ViewBag.Message = "Your products page.";
            string urlAction = String.Format("/tn.esprit.R2S-web/resources/api/email-model/parse/{0}/{1}/{2}", idModel, idUser, idJo);
            String joi = await GetWSObjectEmail<String>(urlAction);
            parse = joi;
            return joi;
            //return View();
        }
        
        public async Task<ActionResult> AffichModel(long? mail, long? idUser, long? jo)
        {
            var a = mail;
            ViewBag.Message = "Your products page.";
            if ((mail != null)&& (idUser != null) && (jo != null))
            {
                string urlAction = String.Format("/tn.esprit.R2S-web/resources/api/email-model/parse/{0}/{1}/{2}", mail, idUser, jo);
                String joi = await GetWSObjectEmail<String>(urlAction);
                parse = joi;
            }
                    
            ViewBag.e = email.GetMany().ToList();

            ViewBag.j = job.GetMany().ToList();
            ViewBag.u = user.GetMany().ToList();
            return View();
        }

       

        public async Task<ActionResult> SendMail()
        {
            SmtpClient smtp = new SmtpClient();
            MailMessage msg = new MailMessage();
            smtp.Credentials = new NetworkCredential("mouna.sassi@esprit.tn", "moncef123456");
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Timeout = 20000;
            msg.From = new MailAddress("mouna.sassi@esprit.tn");
            msg.To.Add("mohamedfiras.barrek@esprit.tn");
            msg.Body = parse;
            smtp.Send(msg);
            return View();
        }
    }

}