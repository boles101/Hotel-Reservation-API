using AutoMapper;
using HotelReservation.Interfaces;
using HotelReservation.Models;
using HotelReservation.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Controllers
{
    public class RoomRateController : BaseController
    {
        private readonly IRoomRateRepo _roomRateRepo;
        private readonly IMapper _mapper;

        public RoomRateController(IRoomRateRepo roomRateRepo,IMapper mapper)
        {
            _roomRateRepo = roomRateRepo;
            _mapper = mapper;
        }

        [HttpGet("Get-All-Room-Rates")]
        public async Task<IActionResult> GetAllRoomRatesAsync()
        {
            var roomRates = await _roomRateRepo.GetAllRatesAsync();
            if(roomRates == null) 
                return NotFound();  
            return Ok(roomRates);
        }

        [HttpPost("Add-New-Room-Rate")]
        public async Task<IActionResult> AddRoomRateAsync(SeasonRateDto roomRateDto)
        {
            if (roomRateDto == null ||!ModelState.IsValid )
                return BadRequest();
            var mappedRoomRate= _mapper.Map<SeasonRate>(roomRateDto);
            var result = await _roomRateRepo.AddRoomRateAsync(mappedRoomRate);
            if (result)
                return Ok(mappedRoomRate);
            return BadRequest("something went wrong when adding to database ");

        }

        [HttpDelete("Delete-Room-Rate")]
        public async Task<IActionResult> DeleteRoomRate(int RoomRateId)
        {
            if(RoomRateId == 0)
                return BadRequest("Please check the entered Id and try again....");
            var result = await _roomRateRepo.RemoveRoomRateAsync(RoomRateId);
           if(result)
                return Ok("Room Rate Was Removed Successfully");
            return BadRequest("Something went wrong on delete... please try again! ");
        }



    }
}
