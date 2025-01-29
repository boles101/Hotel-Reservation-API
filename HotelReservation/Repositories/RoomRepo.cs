using HotelReservation.Data;
using HotelReservation.Interfaces;
using HotelReservation.Models;
using HotelReservation.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace HotelReservation.Repositories
{
    public class RoomRepo : IRoomRepo
    {
        private readonly HotelDbContext _context;

        public RoomRepo(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddRoomAsync(Room room)
        {
            _context.Rooms.Add(room); 
            var save = await _context.SaveChangesAsync();// returns the number of rows affected by the save ! 
            return save > 0;  
            
        }

        public async Task<ICollection<ReturnRoomDto>> GetAllRoomsAsync()
        {
            return  await _context.Rooms
                .Include(r => r.Roomtype)
                .Select(r => new ReturnRoomDto()
                {
                    RoomId = r.RoomId,
                    RoomDescription = r.Roomtype.Description,
                    Capacity = r.Capacity,

                }).ToListAsync();
        }

        public async  Task<bool> RemoveRoomAsync(int roomId)
        {
            var room = await _context.Rooms.FindAsync(roomId);
            if (room == null)
            {
                return false;
            }
            _context.Remove(room);
            var save= await _context.SaveChangesAsync();
            return save > 0;
        }
    }
}
