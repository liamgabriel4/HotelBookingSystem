using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystem.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required, EmailAddress]
        public string CustomerEmail { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
