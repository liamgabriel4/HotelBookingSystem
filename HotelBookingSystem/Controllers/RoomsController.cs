using HotelBookingSystem.Models;
using HotelBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    public class RoomsController : Controller
    {
        private readonly DataService _dataService;

        public RoomsController(DataService dataService)
        {
            _dataService = dataService;
        }

        public IActionResult Index()
        {
            var rooms = _dataService.GetRooms();
            return View(rooms);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                _dataService.AddRoom(room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }
    }
}
