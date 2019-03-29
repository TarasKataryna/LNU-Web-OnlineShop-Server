using System.ComponentModel.DataAnnotations;

namespace DAL.ModelsDto
{
    public class LogInDto
    {
        [Required(ErrorMessage = "Username is required")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }

    }
}
