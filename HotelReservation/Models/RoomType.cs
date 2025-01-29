using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Models
{
    public class RoomType
    {
        [Key]
        public int RoomTypeId { get; set; }
        [Required,MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; } = 50;
        public List<Room> Rooms { get; set; } = new List<Room>();
        public ICollection<Reservation> Reservations { get; set; }


    }
}
