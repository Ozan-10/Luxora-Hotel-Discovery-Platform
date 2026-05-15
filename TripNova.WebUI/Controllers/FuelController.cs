using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TripNova.WebUI.Controllers
{
    public class FuelController : Controller
    {
        private readonly HttpClient _httpClient;

        public FuelController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var jsonData = await _httpClient.GetStringAsync(
                "http://hasanadiguzel.com.tr/api/akaryakit/sehir=istanbul");

            dynamic data = JsonConvert.DeserializeObject(jsonData);

            var firstItem = data.data[0];

            ViewBag.benzin = firstItem.Kursunsuz_95;
            ViewBag.motorin = firstItem.Motorin;
            ViewBag.lpg = firstItem.LPG;

            return View();
        }
    }
}