using System.ComponentModel.DataAnnotations;

namespace cadastro_restfull.Models.Users
{
    public class LoginViewModelInput
    {
        [Required(ErrorMessage = "Login is REQUIERED !")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password is REQUIERED !")]
        public string Password { get; set; }
    }
}
