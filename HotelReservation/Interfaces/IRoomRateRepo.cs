using HotelReservation.Models;

namespace HotelReservation.Interfaces
{
    public interface IRoomRateRepo
    {
        public Task<bool> AddRoomRateAsync(SeasonRate roomRate);
        public Task<bool> RemoveRoomRateAsync(int roomRateId);
        public Task<ICollection<SeasonRate>> GetAllRatesAsync();

    }
}
