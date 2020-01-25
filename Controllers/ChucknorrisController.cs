using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleWebApp.Models;
using SimpleWebApp1.SimpleUI;

namespace SimpleWebApp1.Controllers
{
    public class ChucknorrisController : Controller
    {
        public ChuckNorisJokes SelectCategories()
        {
            ChuckNorisJokes chuckNorisJokes = new ChuckNorisJokes();
            chuckNorisJokes.Categories = new List<string>();

            chuckNorisJokes.Categories.Add("animal");
            chuckNorisJokes.Categories.Add("Career");
            chuckNorisJokes.Categories.Add("Celebrity");
            chuckNorisJokes.Categories.Add("dev");
            chuckNorisJokes.Categories.Add("explicit");
            chuckNorisJokes.Categories.Add("fashion");
            chuckNorisJokes.Categories.Add("food");
            chuckNorisJokes.Categories.Add("history");
            chuckNorisJokes.Categories.Add("money");
            chuckNorisJokes.Categories.Add("movie");
            chuckNorisJokes.Categories.Add("music");
            chuckNorisJokes.Categories.Add("political");
            chuckNorisJokes.Categories.Add("religion");
            chuckNorisJokes.Categories.Add("science");
            chuckNorisJokes.Categories.Add("sports");
            chuckNorisJokes.Categories.Add("travel");

            return chuckNorisJokes;

        }
        public IActionResult Index()
        {
            ChuckNorisJokes chuckNorisJokes = SelectCategories();
            return View(chuckNorisJokes);
        }

        [HttpPost]
        public ActionResult Index(ChuckNorisJokes chuckNorisJokes, string Categories)
        {
            chuckNorisJokes = SelectCategories();

            if(Categories != null)
            {
                /*Calling the API for chucknorris.io*/
                string apiKey = "CHUCK API";
                HttpWebRequest apiRequest = WebRequest.Create("https://api.chucknorris.io/Jokes/random?" + Categories + "={category}" + apiKey) as HttpWebRequest;

                string apiResponse = "";
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    apiResponse = reader.ReadToEnd();
                }
                //End 

                //JSON to translate to CSharp
                Randomm category = JsonConvert.DeserializeObject<Randomm>(apiResponse);

                StringBuilder b = new StringBuilder();
                b.Append("<table><tr><th> Chuck </th></tr>");
                b.Append("<tr><td>id</td><td>" + category.id + "</td></tr>" );
                b.Append("<tr><td>id</td><td>" + category.IconUrl + "</td></tr>");
                b.Append("<tr><td>id</td><td>" + category.Url + "</td></tr>");
                b.Append("<tr><td>id</td><td>" + category.Value + "</td></tr>");
                b.Append("</table");
                chuckNorisJokes.apiResponse = b.ToString();
            }

            return View(chuckNorisJokes);
        }
        
    }
}