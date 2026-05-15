using Microsoft.AspNetCore.Mvc;

namespace TripNova.WebUI.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Detail()
        {
            dynamic room = new
            {
                RoomName = "Executive Deluxe Suite",
                Price = "18.900",
                Capacity = "2 Yetişkin",
                Bed = "King Bed",
                Size = "45 m²",
                View = "Deniz Manzarası"
            };

            ViewBag.room = room;

            return View();
        }
    }
}