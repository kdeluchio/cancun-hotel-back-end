using CancunHotel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CancunHotel.Data.Mapping
{
    public class BookingMap : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Booking");

            builder.Property(c => c.Id)
                   .HasColumnName("Id");

            builder.Property(c => c.CreatedIn)
                   .HasColumnName("CreatedIn");

            builder.Property(c => c.UpdatedIn)
                   .HasColumnName("UpdatedIn");

            builder.Property(c => c.RoomId)
                   .HasColumnName("RoomId");

            builder.Property(c => c.CustomerId)
                   .HasColumnName("CustomerId");

            builder.Property(c => c.CheckIn)
                   .HasColumnName("CheckIn");

            builder.Property(c => c.CheckOut)
                   .HasColumnName("CheckOut");

            builder.Property(c => c.Cancelled)
                   .HasColumnName("Cancelled");

            builder.HasOne<Customer>(s => s.Customer)
                   .WithMany(g => g.Booking)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasForeignKey(c => c.CustomerId);

            builder.HasOne<Room>(s => s.Room)
                   .WithMany(g => g.Booking)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasForeignKey(c => c.RoomId);
        }
    }
}
