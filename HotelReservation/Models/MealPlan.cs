using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservation.Models
{
    public class MealPlan
    {
        public int MealPlanId { get; set; }

        [Required,MaxLength(100)]
        public string MealPlanName { get; set; }    

        [Required, Column(TypeName = "decimal(18, 2)")]
        public decimal PlanPrice { get; set; }
        public ICollection<Reservation> Reservations { get; set; }

    }   
}