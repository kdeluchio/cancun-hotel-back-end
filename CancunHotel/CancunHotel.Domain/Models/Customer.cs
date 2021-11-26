using CancunHotel.Domain.Enums;
using System.Collections.Generic;

namespace CancunHotel.Domain.Models
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public bool ChangePassword { get; set; }
        public UserAccessLevel UserAccessLevel { get; set; }
        public virtual List<Booking> Booking { get; set; }

    }
}
