using System.ComponentModel.DataAnnotations;

namespace TestAPIBackend.Authentication
{
    public class LoginModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9#?!@]).{10,}$",
         ErrorMessage = "password must contains at least 10 characters, one lowercase letter, one uppercase letter and one of the following characters: !, @, #, ? or ].")]
        public string Password { get; set; }
    }
}
