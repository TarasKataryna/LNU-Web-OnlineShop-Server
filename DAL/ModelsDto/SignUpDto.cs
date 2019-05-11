using System.ComponentModel.DataAnnotations;

namespace DAL.ModelsDto
{

    public class SignUpDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        //[MinLength(8)]
        //[RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=.,\-_!])([a-zA-Z0-9 @#$%^&+=*.,\-_!]){8,}$", ErrorMessage = "The Password field is not a valid password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string PasswordConfirmed { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

    }
}
