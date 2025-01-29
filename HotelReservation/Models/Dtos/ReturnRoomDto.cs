using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservation.Models.Dtos
{
    public class ReturnRoomDto
    {
        public int RoomId { get; set; }
        [Required]
        public string  RoomDescription { get; set; }
        public int Capacity { get; set; }

    }
}
