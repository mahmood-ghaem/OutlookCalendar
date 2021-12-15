using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OutlookCalendar.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OutlookCalendar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult OauthRedirect()
        {
            var redirectUrl = "https://login.microsoftonline.com/common/oauth2/v2.0/authorize?" +
                              "&scope=Calendars.ReadWrite offline_access User.Read" +
                              "&response_type=code" +
                              "&response_mode=query" +
                              "&state=de-medewerker" +
                              "&redirect_uri=https://localhost:44337/oauth/callback" +
                              "&client_id=MyClientID";
            return Redirect(redirectUrl);
        }
    }
}
