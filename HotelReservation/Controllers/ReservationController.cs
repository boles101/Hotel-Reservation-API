using HotelReservation.Interfaces;
using HotelReservation.Models;
using HotelReservation.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Controllers
{
   
    public class ReservationController : BaseController
    {
        private readonly IReservationRepo _reservationRepo;

        public ReservationController(IReservationRepo reservationRepo)
        {
            _reservationRepo = reservationRepo;
        }



        [HttpPost("Calculate Reservation Total")]
        public async Task<IActionResult> GetReservationTotal
            (CalculateReservationRequest request)
        {
            try
            {

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var TotalCost = await _reservationRepo.CalculateReservationAsync
                    (
                      request.CheckInDate,
                      request.CheckOutDate,
                      request.NumberOfGuests,
                      request.RoomTypeId,
                      request.MealPlanId
                    );
                var response = new ResponseModel()
                {
                    message = $"Your Total Cost of your stay from {request.CheckInDate} till {request.CheckOutDate} is : {TotalCost}",
                    Cost = TotalCost

                };
                return Ok(response);

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
