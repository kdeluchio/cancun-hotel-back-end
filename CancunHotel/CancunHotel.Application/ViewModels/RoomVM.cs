using System;
using System.ComponentModel.DataAnnotations;

namespace CancunHotel.Application.ViewModels
{
    public class RoomVM
    {
        [Display(Name = "Room Id")]
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Number")]
        [Required]
        [StringLength(10)]
        public string Number { get; set; }

        [Display(Name = "Floor")]
        [Required]
        [StringLength(10)]
        public string Floor { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

    }
}
