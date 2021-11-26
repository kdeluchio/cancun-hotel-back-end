using CancunHotel.Data.Mapping;
using CancunHotel.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CancunHotel.Data.Context
{
    public class CancunHotelContext : DbContext
    {
        public DbSet<Room> Room { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Booking> Booking { get; set; }

        public CancunHotelContext(DbContextOptions<CancunHotelContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoomMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new BookingMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
