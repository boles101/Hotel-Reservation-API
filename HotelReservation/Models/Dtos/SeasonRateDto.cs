using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Models.Dtos
{
    public class SeasonRateDto
    {
        public int RateID { get;private set; }

        [Required, Column(TypeName = "date")]
        public DateOnly StartDate { get; set; }

        [Required, Column(TypeName = "date")]
        public DateOnly EndDate { get; set; }

        [Required, Column(TypeName = "decimal(18, 2)")]
        public decimal RateMultiplier { get; set; }
    }
}
