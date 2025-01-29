using HotelReservation.Data;
using HotelReservation.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Repositories
{
    public class ReservationRepo : IReservationRepo
    {
        private readonly HotelDbContext _context;

        public ReservationRepo(HotelDbContext context)
        {
            _context = context;
        }
        public async  Task<decimal> CalculateReservationAsync
            (DateOnly CheckIn, DateOnly CheckOut, int numberOfGuests, int roomTypeId, int mealPlanId)
        {
            var totalDays = (CheckOut.DayNumber - CheckIn.DayNumber);
            var roomType = await _context.RoomTypes.FindAsync(roomTypeId);
            var mealPlan = await _context.MealPlans.FindAsync(mealPlanId);
            var room = await _context.Rooms.FirstOrDefaultAsync(r => r.RoomTypeId == roomTypeId);


            if (roomType == null || mealPlan == null || room == null)
                throw new ArgumentNullException("The Room-type Id or the Meal-Plan Id  might be invalid" +
                    "or RoomType might not be linked to a room...");

            if (numberOfGuests > room.Capacity)
                throw new ArgumentException("The Number of Guests exceeded the Capacity of the room");


            var CorrectRate = await _context.seasonRates
                    .Where(r => r.StartDate <= CheckOut && r.EndDate >= CheckIn)
                    .OrderBy(r => r.StartDate)
                    .ToListAsync();

            decimal totalCost = 0;

            foreach (var rate in CorrectRate)
            {
                var start = rate.StartDate > CheckIn ? rate.StartDate : CheckIn;
                var end = rate.EndDate < CheckOut ? rate.EndDate : CheckOut;
                var daysAtRate = (end.DayNumber - start.DayNumber) + 1; // Includes the end day

                if (daysAtRate > 0)
                {
                    var dailyCost = (roomType.Price + mealPlan.PlanPrice) * daysAtRate;
                    totalCost += dailyCost * rate.RateMultiplier;
                }
            }

            return totalCost;

        }
    }
}
