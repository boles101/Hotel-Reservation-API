namespace HotelReservation.Interfaces
{
    public interface IReservationRepo
    {
        public Task<decimal> CalculateReservationAsync(DateOnly CheckIn,DateOnly CheckOut,
            int numberOfGuests,int roomTypeId,int mealPlanId);




    }
}
