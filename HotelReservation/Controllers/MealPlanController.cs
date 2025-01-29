using AutoMapper;
using HotelReservation.Interfaces;
using HotelReservation.Models;
using HotelReservation.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Controllers
{
   
    public class MealPlanController : BaseController
    {
        private readonly IMealPlanRepo _mealPlan;
        private readonly IMapper _mapper;

        public MealPlanController(IMealPlanRepo  mealPlan , IMapper mapper)
        {
            _mealPlan = mealPlan;
            _mapper = mapper;
        }

        [HttpGet("Get-All-Meal-Plans")]
        public async Task<IActionResult> GetAllMealPlans()
        {
            var mealPlans = await _mealPlan.GetAllMealPlansAsync();
            var mappedMealPlan = _mapper.Map<ICollection<MealPlanDto>>(mealPlans);
            if(mappedMealPlan == null) 
                return NotFound("Something went wrong retrieving the Meal Plans");
            return Ok(mappedMealPlan);
        }

        [HttpPost("Add-New-Meal-Plan")]
        public async Task<IActionResult> AddNewMealPlan(MealPlanDto mealPlanDto)
        {
            if (!ModelState.IsValid || mealPlanDto == null)
                return BadRequest();
            var mappedMealPlan = _mapper.Map<MealPlan>(mealPlanDto);
           var result =  await _mealPlan.AddMealPlanAsync(mappedMealPlan);
            if(result)
                return Ok(mappedMealPlan);
            return BadRequest("something went wrong...");

        }

        [HttpDelete("Delete-Meal-Plan")]
        public async Task<IActionResult> DeleteMealPlan(int MealPlanId)
        {

           var result = await _mealPlan.RemoveMealPlanAsync(MealPlanId);
            if (!result)
                return BadRequest("Remove Failed..Please Re-check the id and try again");
            return Ok("Meal Plan Was Removed Successfully");

        }


    }
}
