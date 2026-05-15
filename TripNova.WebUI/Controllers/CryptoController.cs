using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TripNova.WebUI.Controllers
{
    public class CryptoController : Controller
    {
        private readonly HttpClient _httpClient;

        public CryptoController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,

                RequestUri = new Uri("https://coinranking1.p.rapidapi.com/coins"),

                Headers =
                {
                    { "x-rapidapi-key", "eec7b340afmsh16e04f0253f3e04p121918jsn4eac6f07d62f" },
                    { "x-rapidapi-host", "coinranking1.p.rapidapi.com" },
                },
            };

            using var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();

            dynamic data = JsonConvert.DeserializeObject(body);

            ViewBag.coins = data.data.coins;

            return View();
        }
    }
}