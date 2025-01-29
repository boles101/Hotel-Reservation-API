using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Models.Dtos
{
    public class ReturnRoomTypeDto
    {
        public int RoomTypeId { get; set; }

        [Required, MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }


    }
}
