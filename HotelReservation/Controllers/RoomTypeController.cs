using AutoMapper;
using HotelReservation.Interfaces;
using HotelReservation.Models;
using HotelReservation.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Controllers
{

    public class RoomTypeController : BaseController
    {
        private readonly IRoomTypeRepo _roomTypeRepo;
        private readonly IMapper _mapper;

        public RoomTypeController(IRoomTypeRepo roomTypeRepo, IMapper mapper)
        {
            _roomTypeRepo = roomTypeRepo;
            _mapper = mapper;
        }



        [HttpGet("Get-All-Types")]
        public async Task<IActionResult> GetAllTypes()
        {
            //var types = _roomTypeRepo.GetALlRoomTypes(); 
            var mappedTypes = _mapper.Map<List<ReturnRoomTypeDto>>(await _roomTypeRepo.GetALlRoomTypes());

            return Ok(mappedTypes);

        }


        [HttpGet("Get-Room-Type-By-ID")]
        public async Task<IActionResult> GetRoomTypeById(int RoomTypeId)
        {
            if (RoomTypeId == 0)
                return BadRequest("Invalid Input");
            var roomType = _mapper.Map<ReturnRoomTypeDto>(await _roomTypeRepo.GetRoomTypeByIdAsync(RoomTypeId));
            if (roomType is not null)
                return Ok(roomType);
            return BadRequest("Invalid Id number");
        }


        [HttpPost("Add-Room_Type")]
        public async Task< IActionResult> AddRoomType(RoomTypeDto roomType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var mappedRoomType = _mapper.Map<RoomType>(roomType);
             await _roomTypeRepo.AddRoomType(mappedRoomType);
            return Ok(roomType);
        }


       

        [HttpDelete("Delete-RoomType")]
        public async Task<IActionResult> DeleteRoomType(int roomTypeId)   
        {
            if (roomTypeId == 0 )
                return BadRequest("Invalid Input");
            var roomType = await _roomTypeRepo.GetRoomTypeByIdAsync(roomTypeId); // would be better if made IsExist Method


            var result = await  _roomTypeRepo.RemoveRoomType(roomTypeId);
            if (result)
                return Ok("Removed Successfully");
            else
                return BadRequest("Error Something went Wrong");
        }



    }
}
