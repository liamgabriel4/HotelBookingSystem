using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
