using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using TurfManager.Models;


namespace TurfManager.Controllers
{
    public class SummaryViewController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<SummaryView> summarylist = null;
            using (var client = new HttpClient())
            {

                // bool isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

                var apiUrl = new Uri(Request.Scheme + "://" + Request.Host.Value + "/api/");
                client.BaseAddress = apiUrl;
               // client.BaseAddress = globalApiUrl;

                var responseTask = client.GetAsync("summaries?Last45=True");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<IList<SummaryView>>();
                    readTask.Wait();
                    summarylist = readTask.Result;

                    decimal RunningTotal = 0;

                    foreach (var item in summarylist)
                    {


                        if (item.summaryAction == 1)
                        {
                            RunningTotal = 0;
                            item.summaryBackgroundTR = "#99ffa0";
                        }


                        RunningTotal = RunningTotal + item.summaryGddtotal.GetValueOrDefault(0);
                        item.summaryGddcumulative = RunningTotal;

                        if (item.summaryGddcumulative > 199)
                        {
                            item.summaryBackgroundTR = "#FF545D";
                        }

                        
                    }

                    HttpContext.Response.Headers.Add("Cumulative", RunningTotal.ToString());



                }
                else
                {
                    summarylist = Enumerable.Empty<SummaryView>();
                    ModelState.AddModelError(string.Empty, "Server error");

                }
            }
            
            return View(summarylist);
        }
    }
}
