using System.ComponentModel.DataAnnotations;

namespace ControlePenal.Models
{
    public class LoginModel
    {

        [Required(ErrorMessage = "UserName obrigatório.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password obrigatório.")]
        public string Password { get; set; }
        

    }
}
