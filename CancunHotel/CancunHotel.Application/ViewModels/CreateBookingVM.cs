using System;
using System.ComponentModel.DataAnnotations;

namespace CancunHotel.Application.ViewModels
{
    public class CreateBookingVM
    {
        [Display(Name = "Room Id")]
        [Required]
        public Guid RoomId { get; set; }

        [Display(Name = "CheckIn")]
        [Required]
        public DateTime CheckIn { get; set; }

        [Display(Name = "CheckOut")]
        [Required]
        public DateTime CheckOut { get; set; }

    }
}
