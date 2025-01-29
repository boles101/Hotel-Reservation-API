using HotelReservation.Models;
using HotelReservation.Models.Dtos;

namespace HotelReservation.Interfaces
{
    public interface IMealPlanRepo
    {
        public Task<bool> AddMealPlanAsync(MealPlan mealPlan);
        public Task<bool> RemoveMealPlanAsync(int MealPlanId);
        public Task<bool> SaveChangesAsync();
        public Task<ICollection<MealPlan>> GetAllMealPlansAsync();


    }
}
