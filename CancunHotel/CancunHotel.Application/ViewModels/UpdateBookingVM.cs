using System;
using System.ComponentModel.DataAnnotations;

namespace CancunHotel.Application.ViewModels
{
    public class UpdateBookingVM
    {
        [Display(Name = "Booking Id")]
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "CheckIn")]
        [Required]
        public DateTime CheckIn { get; set; }

        [Display(Name = "CheckOut")]
        [Required]
        public DateTime CheckOut { get; set; }

    }
}
