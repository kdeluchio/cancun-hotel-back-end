using CancunHotel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CancunHotel.Data.Mapping
{
    public class RoomMap : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Room");

            builder.Property(c => c.Id)
                   .HasColumnName("Id");

            builder.Property(c => c.CreatedIn)
                   .HasColumnName("CreatedIn");

            builder.Property(c => c.UpdatedIn)
                   .HasColumnName("UpdatedIn");

            builder.Property(c => c.Number)
                   .HasColumnName("Number")
                   .HasMaxLength(10);

            builder.Property(c => c.Floor)
                   .HasColumnName("Floor")
                   .HasMaxLength(10);

            builder.Property(c => c.Description)
                   .HasColumnName("Description")
                   .HasMaxLength(200);

            builder.HasMany<Booking>(s => s.Booking)
                   .WithOne(g => g.Room)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasForeignKey(c => c.RoomId);
        }
    }
}
