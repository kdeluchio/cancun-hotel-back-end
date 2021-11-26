using System.ComponentModel.DataAnnotations;

namespace CancunHotel.Application.ViewModels
{
    public class LoginVM
    {
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
