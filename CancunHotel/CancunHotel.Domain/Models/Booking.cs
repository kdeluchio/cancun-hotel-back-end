using System;

namespace CancunHotel.Domain.Models
{
    public class Booking : BaseEntity
    {
        public Guid RoomId { get; set; }
        public virtual Room Room { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public bool Cancelled { get; set; }
    }
}
