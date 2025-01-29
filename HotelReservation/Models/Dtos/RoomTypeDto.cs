using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Models.Dtos
{
    public class RoomTypeDto
    {
        [Required, MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
