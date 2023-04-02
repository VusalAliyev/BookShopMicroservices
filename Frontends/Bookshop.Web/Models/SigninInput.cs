using System.ComponentModel.DataAnnotations;

namespace Bookshop.Web.Models
{
    public class SigninInput
    {
        [Required]
        [Display(Name = "Email adress")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Remember me")]
        public bool IsRemember { get; set; }
    }
}
