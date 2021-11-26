using CancunHotel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CancunHotel.Data.Mapping
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.Property(c => c.Id)
                   .HasColumnName("Id");

            builder.Property(c => c.CreatedIn)
                   .HasColumnName("CreatedIn");

            builder.Property(c => c.UpdatedIn)
                   .HasColumnName("UpdatedIn");

            builder.Property(c => c.FirstName)
                   .HasColumnName("FirstName")
                   .HasMaxLength(200);

            builder.Property(c => c.LastName)
                   .HasColumnName("LastName")
                   .HasMaxLength(200);

            builder.Property(c => c.DocumentNumber)
                   .HasColumnName("DocumentNumber")
                   .HasMaxLength(50);

            builder.Property(c => c.EMail)
                   .HasColumnName("EMail")
                   .HasMaxLength(200);

            builder.Property(c => c.Password)
                   .HasColumnName("Password")
                   .HasMaxLength(20);

            builder.Property(c => c.ChangePassword)
                   .HasColumnName("ChangePassword");

            builder.Property(c => c.UserAccessLevel)
                   .HasColumnName("UserAccessLevel")
                   .HasConversion<int>();

            builder.HasMany<Booking>(s => s.Booking)
                   .WithOne(g => g.Customer)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasForeignKey(c => c.CustomerId);

        }
    }
}
