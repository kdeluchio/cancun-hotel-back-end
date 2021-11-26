using System.ComponentModel.DataAnnotations;

namespace CancunHotel.Application.ViewModels
{
    public class CreateProfileVM
    {
        [Display(Name = "First Name")]
        [Required]
        [StringLength(200)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(200)]
        public string LastName { get; set; }

        [Display(Name = "Document Number")]
        [StringLength(50)]
        public string DocumentNumber { get; set; }

        [Display(Name = "EMail")]
        [Required]
        [StringLength(200)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EMail { get; set; }

        [Display(Name = "Password")]
        [Required]
        [StringLength(10)]
        public string Password { get; set; }

    }
}
