using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TurfManager.Models;
using Action = System.Action;


namespace TurfManager.Controllers
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
            IEnumerable<ActionSummaryView> actionlist = null;
            using (var client = new HttpClient())
            {
                var apiUrl = new Uri(Request.Scheme + "://" + Request.Host.Value + "/api/");
                client.BaseAddress = apiUrl;

                var responseTask = client.GetAsync("summaries/GetActionSummary");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {


                    var readTask = result.Content.ReadAsAsync<IList<ActionSummaryView>>();
                    readTask.Wait();
                    actionlist = readTask.Result;
                   

                }
                else
                {
                    actionlist = Enumerable.Empty<ActionSummaryView>();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }


            return View(actionlist);
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
    }
}
