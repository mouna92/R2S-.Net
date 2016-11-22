using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using R2S.GUI.Models;

namespace R2S.GUI.Controllers
{
    public class BaseController : Controller
    {
        private UserManager _userManager;

        public UserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<UserManager>(); }
            private set { _userManager = value; }
        }

        public User CurrentUser => UserManager.FindByIdAsync(User.Identity.GetUserId<long>()).Result;

        public async Task<T> GetWSObject<T>(string uriActionString)
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
                    var a = ((HttpResponseMessage)response).Content.ReadAsStringAsync().Result;
                    returnValue = JsonConvert.DeserializeObject<T>(((HttpResponseMessage)response).Content.ReadAsStringAsync().Result);
                }
                return returnValue;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.GetBaseException().Message);
                throw (e);
            }
        }

    }
}