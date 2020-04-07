using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using COVID_19.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace COVID_19.Controllers
{
    public class HomeController : Controller
    {
        string baseUrl = "https://coronavirus-19-api.herokuapp.com/";
        //public IActionResult Index()
        //{
        //    var model = new CountryDetails()
        //    {
        //        country = "Belgium",
        //        cases = 9134,
        //        todayCases = 1850,
        //        deaths = 353,
        //        todayDeaths = 64,
        //        recovered = 1063,
        //        active = 7718,
        //        critical = 789,
        //        casesPerOneMillion = 788,
        //        deathsPerOneMillion = 30,
        //        firstCase = "\nFeb 03"
        //    };
        //    return View(model);
        //    //return View();
        //}
        public async Task<ActionResult> Index(string id)
        {
            List<CountryDetails> CountryInfo = new List<CountryDetails>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // Sending request to find web api REST service resource GetAllCountries using HttpClient
                 HttpResponseMessage Res = await client.GetAsync("countries");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var CountryResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    CountryInfo = JsonConvert.DeserializeObject<List<CountryDetails>>(CountryResponse);

                }
                return View(CountryInfo);
                //return View(CountryInfo.Where(x = > x.country.StartsWith(search) || search == null).ToList());
    
                //return View(CountryInfo.Where(x => x.country == id|| id == null).ToList());
            }

            
            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //public IActionResult CovidDetailsPerCountry()
        //{
        //    var model = new CountryDetails()
        //    {
        //        country = "Belgium",
        //        cases = 9134,
        //        todayCases = 1850,
        //        deaths = 353,
        //        todayDeaths = 64,
        //        recovered = 1063,
        //        active = 7718,
        //        critical = 789,
        //        casesPerOneMillion = 788,
        //        deathsPerOneMillion = 30,
        //        firstCase = "\nFeb 03"
        //    };
        //    return View(model);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
