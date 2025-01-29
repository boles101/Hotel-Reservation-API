using AutoMapper;
using HotelReservation.Data;
using HotelReservation.Interfaces;
using HotelReservation.Models;
using HotelReservation.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Repositories
{
    public class RoomTypeRepo : IRoomTypeRepo
    {
        private readonly HotelDbContext _context;
        private readonly IMapper _mapper;

        public RoomTypeRepo(HotelDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<bool> AddRoomType(RoomType roomType)
        {
            _context.RoomTypes.Add(roomType);
            var result = await SaveChangesAsync();
            if (result)
                return true;
            else
                return false;
        }

        public async Task<ICollection<RoomType>> GetALlRoomTypes()
        {
            return  await _context.RoomTypes.OrderBy( r => r.RoomTypeId ).ToListAsync();
        }

        public async Task<RoomType> GetRoomTypeByIdAsync(int RoomTypeId)
        {
            return await _context.RoomTypes.FindAsync(RoomTypeId);   
        }

        public async Task<bool> RemoveRoomType(int RoomTypeId )
        {
            var roomtype = await GetRoomTypeByIdAsync(RoomTypeId);
            _context.RoomTypes.Remove(roomtype);
            return await SaveChangesAsync();
            
        }

        public async Task<bool> SaveChangesAsync()
        {
            var save = await _context.SaveChangesAsync();
            return save> 0 ? true : false;
        }
    }
}
