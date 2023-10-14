using System.ComponentModel.DataAnnotations;

namespace GestorDePacientes.Core.Application.ViewModels.UserViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Debe colocar el nombre de usuario")]
        [DataType(DataType.Text)]
        public string UserName { get; set; } = null!;
        [Required(ErrorMessage = "Debe colocar una contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
