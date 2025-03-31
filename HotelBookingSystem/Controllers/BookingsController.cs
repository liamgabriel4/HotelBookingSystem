using HotelBookingSystem.Models;
using HotelBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    public class BookingsController : Controller
    {
        private readonly DataService _dataService;

        public BookingsController(DataService dataService)
        {
            _dataService = dataService;
        }

        public IActionResult Index()
        {
            var bookings = _dataService.GetBookings();
            return View(bookings);
        }

        public IActionResult Create()
        {
            ViewBag.Rooms = _dataService.GetRooms().Where(r => r.IsAvailable).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                var room = _dataService.GetRooms().FirstOrDefault(r => r.Id == booking.RoomId);
                if (room == null || !room.IsAvailable)
                {
                    ModelState.AddModelError("", "Selected room is not available.");
                    ViewBag.Rooms = _dataService.GetRooms().Where(r => r.IsAvailable).ToList();
                    return View(booking);
                }

                _dataService.AddBooking(booking);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Rooms = _dataService.GetRooms().Where(r => r.IsAvailable).ToList();
            return View(booking);
        }
    }
}
