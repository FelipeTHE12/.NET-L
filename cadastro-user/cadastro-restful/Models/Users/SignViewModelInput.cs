using System.ComponentModel.DataAnnotations;

namespace cadastro_restfull.Models.Users
{
    public class SignViewModelInput
    {
        [Required(ErrorMessage = "Login is REQUIERED !")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password is REQUIERED !")]
        public string Password { get; set; }

        [Required(ErrorMessage = "E-Mail is REQUIERED !")]
        public string Email { get; set; }


    }
}
