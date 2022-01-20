using System.ComponentModel.DataAnnotations;

namespace EccomerceSS.ViewModel
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage ="You are missing the Email, please type one")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="You are missing a phone number, please type one")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage ="You are missing a username, please type one")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="you are missing a password, please type on")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Please type your password again")]
        [Compare("Password",ErrorMessage ="The two password doesn not match, check them out")]
        public string RepeatPassword { get; set; }
    }
}
