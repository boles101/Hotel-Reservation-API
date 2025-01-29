using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Models.Dtos
{
    public class RoomDto
    {
        
        public int? RoomId { get; private set; }
        public int RoomTypeId { get; set; }
        public int Capacity { get; set; }

    }
}
