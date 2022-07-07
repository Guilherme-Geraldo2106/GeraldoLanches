using System.ComponentModel.DataAnnotations;

namespace GeraldoLanches.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Digite um Nome")]
        [Display(Name = "Usuario")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }


        public string ReturnUrl { get; set; }
    }
}
