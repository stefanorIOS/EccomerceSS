using System.ComponentModel.DataAnnotations;

namespace EccomerceSS.ViewModel
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "You are missing the Email, please type one")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "you are missing a password, please type on")]
        public string Password { get; set; }
    }
}
