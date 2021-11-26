using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CancunHotel.Application.ViewModels
{
    public class CreateRoomVM
    {
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
