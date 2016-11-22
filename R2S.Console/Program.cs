using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.Specialized;

using Spring.Json;
using Spring.Social.OAuth1;
using Spring.Social.LinkedIn.Api;
using Spring.Social.LinkedIn.Connect;

namespace R2S.Console
{
    class Program
    {
        // Register your own LinkedIn app at https://www.linkedin.com/secure/developer.
        // Set your API key & secret here
        private const string LinkedInApiKey = "77orruh5qahjq8";
        private const string LinkedInApiSecret = "IPnvrITvDDb2qsSa";

        static void Main(string[] args)
        {
            try
            {
                LinkedInServiceProvider linkedInServiceProvider = new LinkedInServiceProvider(LinkedInApiKey, LinkedInApiSecret);

                
                /* OAuth 'dance' */

                // Authentication using Out-of-band/PIN Code Authentication
                System.Console.Write("Getting request token...");
                NameValueCollection parameters = new NameValueCollection();
                
                parameters.Add("scope", "r_basicprofile r_emailaddress");
                OAuthToken oauthToken = linkedInServiceProvider.OAuthOperations.FetchRequestTokenAsync("oob", parameters).Result;

                System.Console.WriteLine("Done");

                string authenticateUrl = linkedInServiceProvider.OAuthOperations.BuildAuthorizeUrl(oauthToken.Value, null);
                System.Console.WriteLine("Redirect user for authentication: " + authenticateUrl);
                Process.Start(authenticateUrl);
                System.Console.WriteLine("Enter PIN Code from LinkedIn authorization page:");
                string pinCode = System.Console.ReadLine();

                System.Console.Write("Getting access token...");
                AuthorizedRequestToken requestToken = new AuthorizedRequestToken(oauthToken, pinCode);
                OAuthToken oauthAccessToken = linkedInServiceProvider.OAuthOperations.ExchangeForAccessTokenAsync(requestToken, null).Result;
                System.Console.WriteLine("Done");

                /* API */

                ILinkedIn linkedIn = linkedInServiceProvider.GetApi(oauthAccessToken.Value, oauthAccessToken.Secret);

                LinkedInProfile profile = linkedIn.ProfileOperations.GetUserProfileAsync().Result;
                
            }
            catch (AggregateException ae)
            {


                System.Console.WriteLine(ae.GetBaseException());
            }

                
            
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }
            finally
            {
                System.Console.WriteLine("--- hit <return> to quit ---");
                System.Console.ReadLine();
            }
        }
    }
}

