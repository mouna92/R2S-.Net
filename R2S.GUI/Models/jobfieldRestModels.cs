using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http;
using R2S.Data.Models;
using System.Net.Http.Headers;

namespace R2S.GUI.Models
{
    public class jobfieldRestModels
    {
        private string BASE_URL = "http://localhost:8080/api/job/form";
        public Task<jobfield> show()
        {
            var jobf = new HttpClient();
            jobf.BaseAddress = new Uri(BASE_URL);
            jobf.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage rep = jobf.GetAsync("form").Result;
            //return rep.Content.ReadAsAsync<jobfield>();
            return null;
        }
    }
}