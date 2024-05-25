using Calofit_Project.CommonService;
using Calofit_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Calofit_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Test()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://the-cocktail-db.p.rapidapi.com/search.php?s=vodka"),
                Headers =
    {
        { "X-RapidAPI-Key", "76c1fe8475mshec8195412c011edp1ad681jsn3e10b524abd2" },
        { "X-RapidAPI-Host", "the-cocktail-db.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
            return View();
        }

        public async Task<ActionResult> Index()
        {
            return View();

        }

        private async Task<ActionResult> fetchApi()
        {
            return RedirectToAction("Test");
            string url = "https://www.fruityvice.com/api/fruit/all";
            List<Fruit> list = new List<Fruit>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsondata = await response.Content.ReadAsStringAsync();
                    list = System.Text.Json.JsonSerializer.Deserialize<List<Fruit>>(jsondata);
                    return Content(jsondata, "application/json");
                }
                return Json(1, 0);
            }
        }
        public class FruitList
        {
            public List<Fruit> data { get; set; }
        }
        public class Nutritions
        {
            public int calories { get; set; }
            public double fat { get; set; }
            public double sugar { get; set; }
            public double carbohydrates { get; set; }
            public double protein { get; set; }
        }

        public class Fruit
        {
            [JsonPropertyName("name")]
            public string skibidi { get; set; }
            public int id { get; set; }
            public string family { get; set; }
            public string order { get; set; }
            public string genus { get; set; }
            public Nutritions nutritions { get; set; }
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
