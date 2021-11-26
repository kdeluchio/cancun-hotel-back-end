using System;
using System.Collections.Generic;
using System.Text;

namespace CancunHotel.Domain.Models
{
    public class Room : BaseEntity
    {
        public string Number { get; set; }
        public string Floor { get; set; }
        public string Description { get; set; }
        public virtual List<Booking> Booking { get; set; }

    }
}
