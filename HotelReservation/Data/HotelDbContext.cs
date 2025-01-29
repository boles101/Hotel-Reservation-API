using HotelReservation.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<SeasonRate> seasonRates { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }
        public DbSet<Reservation> reservations { get; set; }    


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SeasonRate>()
            .Property(p => p.StartDate)
            .HasColumnType("date");

            modelBuilder.Entity<SeasonRate>()
            .Property(p => p.EndDate)
            .HasColumnType("date");

            modelBuilder.Entity<SeasonRate>()
            .Property(p => p.RateMultiplier)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<RoomType>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<MealPlan>()
            .Property(p => p.PlanPrice)
            .HasColumnType("decimal(18,2)");
        }
    }
}
