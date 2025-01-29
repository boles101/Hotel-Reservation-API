using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservation.Models.Dtos
{
    public class MealPlanDto
    {
        public int MealPlanId { get;private set; }

        [Required, MaxLength(100)]
        public string MealPlanName { get; set; }    

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal PlanPrice { get; set; }
    }   
}
