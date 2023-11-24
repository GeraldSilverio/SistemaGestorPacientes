using System.ComponentModel.DataAnnotations;

namespace GestorDePacientes.Core.Application.ViewModels.UserViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "DEBE INGRESAR SU NOMBRE DE USUARIO")]
        [DataType(DataType.Text)]
        public string UserName { get; set; } = null!;
        [Required(ErrorMessage = "DEBE INGRESAR SU CONTRASEÑA")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
