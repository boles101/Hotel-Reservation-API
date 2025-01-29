namespace HotelReservation.Models
{
    public class CalculateReservationRequest
    {
        
       public DateOnly CheckInDate { get; set; }
       public DateOnly CheckOutDate { get; set; }
       public int NumberOfGuests { get; set; }
       public int RoomTypeId { get; set; }
       public int MealPlanId { get; set; }
    
    }
}
