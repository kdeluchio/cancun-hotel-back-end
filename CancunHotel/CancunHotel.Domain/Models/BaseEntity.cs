using System;
using System.ComponentModel.DataAnnotations;

namespace CancunHotel.Domain.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedIn { get; set; }

        public DateTime? UpdatedIn { get; set; }

    }
}
