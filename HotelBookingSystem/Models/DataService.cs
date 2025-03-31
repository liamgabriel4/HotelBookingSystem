using HotelBookingSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace HotelBookingSystem.Services
{
    public class DataService
    {
        public List<Room> Rooms { get; set; } = new();
        public List<Booking> Bookings { get; set; } = new();

        public DataService()
        {
            // Seed initial rooms
            Rooms.Add(new Room { Id = 1, Name = "Deluxe Suite", Capacity = 2, PricePerNight = 1200, IsAvailable = true });
            Rooms.Add(new Room { Id = 2, Name = "Family Room", Capacity = 4, PricePerNight = 1800, IsAvailable = true });
        }

        // Room Operations
        public List<Room> GetRooms() => Rooms;

        public void AddRoom(Room room)
        {
            room.Id = Rooms.Count > 0 ? Rooms.Max(r => r.Id) + 1 : 1;
            Rooms.Add(room);
        }

        // Booking Operations
        public List<Booking> GetBookings() => Bookings;

        public void AddBooking(Booking booking)
        {
            booking.Id = Bookings.Count > 0 ? Bookings.Max(b => b.Id) + 1 : 1;
            booking.TotalPrice = (decimal)(booking.CheckOutDate - booking.CheckInDate).TotalDays *
                                 Rooms.First(r => r.Id == booking.RoomId).PricePerNight;
            Bookings.Add(booking);

            // Mark room as unavailable
            var room = Rooms.FirstOrDefault(r => r.Id == booking.RoomId);
            if (room != null) room.IsAvailable = false;
        }
    }
}
