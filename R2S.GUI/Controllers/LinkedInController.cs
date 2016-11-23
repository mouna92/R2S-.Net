using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using R2S.Data.Models;
using Spring.Json;
using Spring.Social.OAuth1;
using Spring.Social.LinkedIn.Api;
using Spring.Social.LinkedIn.Connect;
using WebGrease.Css.Extensions;

namespace R2S.GUI.Controllers
{
    public class LinkedInController : Controller
    {
        // Register your own LinkedIn app at https://www.linkedin.com/secure/developer.
        // Configure the OAuth Redirect URL with 'http://localhost/LinkedIn/Callback'
        // Set your API key & secret here
        private const string LinkedInApiKey = "77orruh5qahjq8";
        private const string LinkedInApiSecret = "IPnvrITvDDb2qsSa";

        IOAuth1ServiceProvider<ILinkedIn> linkedInProvider =
            new LinkedInServiceProvider(LinkedInApiKey, LinkedInApiSecret);

        // GET: /LinkedIn/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: /LinkedIn/SignIn
        public ActionResult SignIn()
        {
            OAuthToken requestToken=null;
            
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("scope", "r_basicprofile r_emailaddress");
                Debug.WriteLine(linkedInProvider.ToString());
            requestToken = linkedInProvider.OAuthOperations.FetchRequestTokenAsync("http://localhost:65354/LinkedIn/Callback", parameters).Result;
            Session["RequestToken"] = requestToken;
            return Redirect(linkedInProvider.OAuthOperations.BuildAuthenticateUrl(requestToken.Value, null));
        }

        // GET: /LinkedIn/Callback
        public ActionResult Callback(string oauth_verifier)
        {
            OAuthToken requestToken = Session["RequestToken"] as OAuthToken;
            AuthorizedRequestToken authorizedRequestToken = new AuthorizedRequestToken(requestToken, oauth_verifier);
            
            OAuthToken token = linkedInProvider.OAuthOperations.ExchangeForAccessTokenAsync(authorizedRequestToken, null).Result;

            Session["AccessToken"] = token;

            ILinkedIn linkedInClient = linkedInProvider.GetApi(token.Value, token.Secret);
            LinkedInProfile profile = linkedInClient.ProfileOperations.GetUserProfileAsync().Result;
            return View(profile);
        }


        

        public ActionResult Search(string skills)
        {
            List<LinkedInFullProfile> profiles = JsonConvert.DeserializeObject<List<LinkedInFullProfile>>(System.IO.File.ReadAllText(@"C:\Users\kello\Source\Repos\R2S-.Net\R2S.GUI\members.json"));
            List<LinkedInFullProfile> profilesSearched =new List<LinkedInFullProfile>();
            foreach (var p in profiles)
            {
                foreach (var s in p.Skills)
                {
                    if (s.Equals(skills))
                    { profilesSearched.Add(p);}
                }
                
            }
            return View(profilesSearched);
            
        }


    }
}
