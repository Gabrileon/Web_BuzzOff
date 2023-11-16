using Common.Interfaces;
using Common.Others;
using System.ComponentModel.DataAnnotations;

namespace BuzzOff.Models
{
    public class LoggedUserModel : ILoggedUser
    {
        [Required(ErrorMessage = "O campo email é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo email é obrigatório")]
        public string Email { get; set; }
        public string Password { get; set; }
        [Required(ErrorMessage = "O campo senha é obrigatório.")]
        public string CPF { get; set; }
        [Display(Name = "Lembre de mim")]
        public bool rememberMe { get; set; }

    }
}
