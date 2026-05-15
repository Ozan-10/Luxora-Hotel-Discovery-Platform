using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TripNova.WebUI.Controllers
{
    public class WeatherController : Controller
    {
        private readonly HttpClient _httpClient;

        public WeatherController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,

                RequestUri = new Uri("https://weatherapi-com.p.rapidapi.com/current.json?q=Paris"),

                Headers =
                {
                    { "x-rapidapi-key", "eec7b340afmsh16e04f0253f3e04p121918jsn4eac6f07d62f" },
                    { "x-rapidapi-host", "weatherapi-com.p.rapidapi.com" },
                },
            };

            using var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();

            dynamic data = JsonConvert.DeserializeObject(body);

            ViewBag.city = data.location.name;
            ViewBag.temp = data.current.temp_c;
            ViewBag.desc = data.current.condition.text;
            ViewBag.icon = data.current.condition.icon;

            return View();
        }
    }
}