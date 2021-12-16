using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;

namespace OutlookCalendar.Controllers
{
    public class OAuthController : Controller
    {
        string tokensFile = "D:\\tokens.json";
        public ActionResult Callback(string code, string state, string error)
        {
            if (!string.IsNullOrWhiteSpace(code))
            {
                RestClient restClient = new RestClient();
                RestRequest restRequest = new RestRequest();

                restRequest.AddParameter("client_id", "MyClientID");
                restRequest.AddParameter("scope", "Calendars.ReadWrite offline_access User.Read");
                restRequest.AddParameter("redirect_uri", "https://localhost:44337/oauth/callback");
                restRequest.AddParameter("code", code);
                restRequest.AddParameter("grant_type", "authorization_code");
                restRequest.AddParameter("client_secret", "MyClientSecret");

                restClient.BaseUrl = new Uri("https://login.microsoftonline.com/common/oauth2/v2.0/token");
                
                var response = restClient.Post(restRequest);

                response.ContentType = "application/x-www-form-urlencoded";

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    System.IO.File.WriteAllText(tokensFile, response.Content);
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Error", "Home");
        }
    }
}
