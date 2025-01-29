using AutoMapper;
using HotelReservation.Interfaces;
using HotelReservation.Models;
using HotelReservation.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.Runtime.InteropServices;

namespace HotelReservation.Controllers
{
    
    public class RoomController : BaseController
    {
        private readonly IRoomRepo _roomRepo;
        private readonly IMapper _mapper;

        public RoomController(IRoomRepo roomRepo ,IMapper mapper)
        {
            _roomRepo = roomRepo;
            _mapper = mapper;
        }


        [HttpGet("Get-All-Rooms")]
        public async Task<IActionResult> GetAllRooms()
        {
            var mappedRooms = _mapper.Map<List<ReturnRoomDto>>(await _roomRepo.GetAllRoomsAsync());
            return Ok(mappedRooms);
        }






        [HttpPost("Add-Room")]
        public async Task<IActionResult> AddRoom(RoomDto roomDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            if(roomDto.RoomId.HasValue)
                return BadRequest("Id should be set for new entries");

            var mappedRoom = _mapper.Map<Room> (roomDto);

            if (mappedRoom.Capacity <= 0 || mappedRoom.Capacity > 2)
                return BadRequest("Capaciity is up to 2 people at the moment");

            var result = await  _roomRepo.AddRoomAsync(mappedRoom);
            if (result)
                return Ok("New Room has been added successfully.");
            else
                return BadRequest("Couldn't save the changes. Something went wrong");
        }



       



        [HttpDelete("Delete-Room")]

        public async Task<IActionResult> DeleteRoom(int RoomId)
        {
            var Room = await  _roomRepo.RemoveRoomAsync(RoomId);
            if (Room)
                return Ok("Room Removed Successfully");
            else
                return BadRequest("Couldn't save the changes. Something went wrong");
        }




    }
}
