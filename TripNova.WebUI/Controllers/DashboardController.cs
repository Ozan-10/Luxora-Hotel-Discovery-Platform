using Microsoft.AspNetCore.Mvc;

namespace TripNova.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.UsdTry = 39.12;
            ViewBag.EurTry = 42.85;
            ViewBag.GbpTry = 50.44;
            ViewBag.WeatherDegree = "14°";

            ViewBag.City = "Paris";

            ViewBag.WeatherStatus = "Parçalı Bulutlu";

            ViewBag.WeatherIcon = "fa-solid fa-cloud-sun";

            return View();
        }
    }
}