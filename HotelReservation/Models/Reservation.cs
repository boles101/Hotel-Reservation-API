using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        [Required]
        public DateOnly CheckInDate { get; set; }
        [Required]
        public DateOnly CheckOutDate { get; set; }
        [Required]
        public int NumberOfGuests { get; set; }


        [Required]
        public int RoomTypeId { get; set; }
        [Required]
        public int MealPlanId { get; set; }     

        //nav props
        public RoomType roomType { get; set; }
        public MealPlan mealPlan { get; set; }
    }
}
