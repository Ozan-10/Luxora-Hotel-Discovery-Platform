using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TripNova.WebUI.Services;

namespace TripNova.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly BookingApiService _bookingApiService;
        private readonly HttpClient _httpClient;

        public DefaultController(
            BookingApiService bookingApiService,
            HttpClient httpClient)
        {
            _bookingApiService = bookingApiService;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _bookingApiService.SearchLocationAsync("Paris");

            var hotels = await _bookingApiService.GetHotelsAsync();

            ViewBag.hotels = hotels;

            // WEATHER API

            var weatherRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,

                RequestUri = new Uri("https://weatherapi-com.p.rapidapi.com/current.json?q=Paris"),

                Headers =
                {
                    { "x-rapidapi-key", "eec7b340afmsh16e04f0253f3e04p121918jsn4eac6f07d62f" },
                    { "x-rapidapi-host", "weatherapi-com.p.rapidapi.com" },
                },
            };

            using var weatherResponse =
                await _httpClient.SendAsync(weatherRequest);

            if (weatherResponse.IsSuccessStatusCode)
            {
                var weatherBody =
                    await weatherResponse.Content.ReadAsStringAsync();

                dynamic weatherData =
                    JsonConvert.DeserializeObject(weatherBody);

                ViewBag.weatherTemp =
                    weatherData.current.temp_c;

                ViewBag.weatherCity =
                    weatherData.location.name;
            }

            // CURRENCY API

            var currencyRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,

                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/latest?from=USD&to=TRY,EUR,GBP"),

                Headers =
                {
                    { "x-rapidapi-key", "eec7b340afmsh16e04f0253f3e04p121918jsn4eac6f07d62f" },
                    { "x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
                },
            };

            using var currencyResponse =
                await _httpClient.SendAsync(currencyRequest);

            if (currencyResponse.IsSuccessStatusCode)
            {
                var currencyBody =
                    await currencyResponse.Content.ReadAsStringAsync();

                dynamic currencyData =
                    JsonConvert.DeserializeObject(currencyBody);

                ViewBag.usdTry =
                    currencyData.rates.TRY;

                ViewBag.usdEur =
                    currencyData.rates.EUR;

                ViewBag.usdGbp =
                    currencyData.rates.GBP;
            }

            return View(values);
        }
    }
}