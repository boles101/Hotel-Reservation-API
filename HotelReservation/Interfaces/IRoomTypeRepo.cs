using HotelReservation.Models;
using HotelReservation.Models.Dtos;

namespace HotelReservation.Interfaces
{
    public interface IRoomTypeRepo
    {
        public Task<bool> AddRoomType(RoomType roomType);
        public Task <bool> RemoveRoomType(int RoomtypeId);
        public Task<RoomType> GetRoomTypeByIdAsync(int RoomTypeId);
        public Task<ICollection<RoomType>> GetALlRoomTypes();
        public Task<bool> SaveChangesAsync();


    }
}
