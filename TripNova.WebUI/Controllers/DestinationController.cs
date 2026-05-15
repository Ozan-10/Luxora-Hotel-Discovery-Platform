using Microsoft.AspNetCore.Mvc;
using TripNova.WebUI.Services;

namespace TripNova.WebUI.Controllers
{
    public class DestinationController : Controller
    {
        private readonly BookingApiService _bookingApiService;

        public DestinationController(BookingApiService bookingApiService)
        {
            _bookingApiService = bookingApiService;
        }

        public async Task<IActionResult> Paris()
        {
            string destId = "-1456928";

            var hotels = await _bookingApiService.GetHotelsByCityAsync(destId);

            ViewBag.CityName = "Paris";

            return View(hotels);
        }
    }
}