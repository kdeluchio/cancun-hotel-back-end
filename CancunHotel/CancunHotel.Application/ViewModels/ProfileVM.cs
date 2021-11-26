using System;

namespace CancunHotel.Application.ViewModels
{
    public class ProfileVM
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DocumentNumber { get; set; }

        public string EMail { get; set; }
    }
}
