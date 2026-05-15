using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TripNova.WebUI.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly HttpClient _httpClient;

        public CurrencyController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,

                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/latest?from=USD&to=TRY,EUR,GBP"),

                Headers =
                {
                    { "x-rapidapi-key", "eec7b340afmsh16e04f0253f3e04p121918jsn4eac6f07d62f" },
                    { "x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
                },
            };

            using var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();

            dynamic data = JsonConvert.DeserializeObject(body);

            ViewBag.tryRate = data.rates.TRY;
            ViewBag.eurRate = data.rates.EUR;
            ViewBag.gbpRate = data.rates.GBP;

            return View();
        }
    }
}