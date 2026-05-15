using Microsoft.AspNetCore.Mvc;
using TripNova.WebUI.Services;

namespace TripNova.WebUI.Controllers
{
    public class HotelController : Controller
    {
        private readonly BookingApiService _bookingApiService;

        public HotelController(BookingApiService bookingApiService)
        {
            _bookingApiService = bookingApiService;
        }

        public async Task<IActionResult> Search(string city)
        {
            string destId = "-1456928";

            if (!string.IsNullOrEmpty(city))
            {
                var locations = await _bookingApiService.SearchLocationAsync(city);

                if (locations != null && locations.Count > 0)
                {
                    destId = locations[0].dest_id;
                }
            }

            var hotels = await _bookingApiService.GetHotelsByCityAsync(destId);

            return View(hotels);
        }

        public async Task<IActionResult> Detail(string id)
        {
            
            if (id == "demo")
            {
                dynamic hotel = new
                {
                    hotel_name = "Hotel Le Meurice",
                    address = "Paris, France",
                    city = "Paris",
                    district = "Central Paris",
                    country_trans = "France",
                    currency_code = "EUR",
                    review_nr = "9.4",
                    property_photo = "https://images.unsplash.com/photo-1566073771259-6a8506099945?q=80&w=2070"
                };

                ViewBag.hotel = new
                {
                    data = hotel
                };

                return View();
            }

            
            var values = await _bookingApiService.GetHotelDetailAsync(id);

            if (values == null)
            {
                return RedirectToAction("Search");
            }

            ViewBag.hotel = values;

            return View();
        }
    }
}