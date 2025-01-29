using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservation.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [ForeignKey("RoomType")]
        public int RoomTypeId { get; set; }
        public  RoomType Roomtype { get; set; }
        [Required]
        public int Capacity { get; set; }

    }
}
