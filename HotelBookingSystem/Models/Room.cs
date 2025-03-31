using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystem.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public decimal PricePerNight { get; set; }

        public bool IsAvailable { get; set; } = true;
    }
}
