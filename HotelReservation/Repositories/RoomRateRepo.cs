using HotelReservation.Data;
using HotelReservation.Interfaces;
using HotelReservation.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Repositories
{
    
    public class RoomRateRepo : IRoomRateRepo
    {
        private readonly HotelDbContext _context;

        public RoomRateRepo(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddRoomRateAsync(SeasonRate seasonRate)
        {
            await _context.seasonRates.AddAsync(seasonRate);
           var save=  await _context.SaveChangesAsync();

            return save > 0;
            
        }

        public async Task<ICollection<SeasonRate>> GetAllRatesAsync()
        {
            return await _context.seasonRates.OrderBy(r =>r.RateID).ToListAsync();
        }

        public async Task<bool> RemoveRoomRateAsync(int roomRateId)
        {
            var roomRate = await _context.seasonRates.FindAsync(roomRateId);
            if (roomRate == null)
                return false;
            _context.seasonRates.Remove(roomRate);
            var save = await _context.SaveChangesAsync();
            return save > 0;

        }
    }
}
