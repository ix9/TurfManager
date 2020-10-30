using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TurfManager.Models;

namespace TurfManager.Controllers
{
    public class SummaryViewController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<SummaryViewModel> summarylist = null;
            using (var client = new HttpClient())
            {

                bool isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

                if (isDevelopment)
                {
                    client.BaseAddress = new Uri("https://localhost:44332/api/");
                    //client.BaseAddress = new Uri(Context.Request.Host);
                }
                else
                {
                    client.BaseAddress = new Uri("https://turfmanager.azurewebsites.net/api/");
                }

                var responseTask = client.GetAsync("summaries?Last45=true");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<IList<SummaryViewModel>>();
                    readTask.Wait();
                    summarylist = readTask.Result;

                    decimal RunningTotal = 0;

                    foreach (var item in summarylist)
                    {


                        //if (item.summaryApplication.GetValueOrDefault(false))
                        //{
                        //    RunningTotal = 0;
                        //}

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

                        //switch (item.summaryGddcumulative) 
                        //{
                        //    case decimal n when (n == 0):
                        //        item.summaryBackgroundTR = "#99ffa0";
                        //        break;
                        //    case decimal n when (n >= 200):
                        //        item.summaryBackgroundTR = "#FF545D";
                        //        break;
                        //}

                    }

                    HttpContext.Response.Headers.Add("Cumulative", RunningTotal.ToString());



                }
                else
                {
                    summarylist = Enumerable.Empty<SummaryViewModel>();
                    ModelState.AddModelError(string.Empty, "Server errror - please contact administrator.");

                }
            }
            
            return View(summarylist);
        }
    }
}
