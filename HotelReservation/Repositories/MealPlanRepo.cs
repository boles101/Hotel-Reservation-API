using HotelReservation.Data;
using HotelReservation.Interfaces;
using HotelReservation.Models;
using HotelReservation.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Repositories
{
    public class MealPlanRepo : IMealPlanRepo
    
    {
        private readonly HotelDbContext _context;

        public MealPlanRepo(HotelDbContext context)
        {
            _context = context;
        }


        public async Task<bool> AddMealPlanAsync(MealPlan mealPlan)
        {
            _context.MealPlans.Add(mealPlan);
            return await SaveChangesAsync();
        }

        public async  Task<ICollection<MealPlan>> GetAllMealPlansAsync()
        {
            return  await _context.MealPlans.OrderBy(m => m.MealPlanId).ToListAsync();
        }

        public async Task<bool> RemoveMealPlanAsync(int MealPlanId)
        {
            var MealPlan = await _context.MealPlans.FindAsync(MealPlanId);
            if(MealPlan == null) 
                return false;
            _context.MealPlans.Remove(MealPlan);
            return await SaveChangesAsync();

        }

        public async Task<bool> SaveChangesAsync()
        {
           var result = await _context.SaveChangesAsync();
            return result > 0;

        }
    }
}
