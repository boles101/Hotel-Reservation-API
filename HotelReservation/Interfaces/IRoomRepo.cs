using HotelReservation.Models;
using HotelReservation.Models.Dtos;

namespace HotelReservation.Interfaces
{
    public interface IRoomRepo
    {

        public  Task<bool> AddRoomAsync(Room room);
        public  Task<bool> RemoveRoomAsync(int roomId);
        public  Task<ICollection<ReturnRoomDto>> GetAllRoomsAsync();
    }
}
