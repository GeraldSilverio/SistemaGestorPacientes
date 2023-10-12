using System.ComponentModel.DataAnnotations;

namespace GestorDePacientes.Core.Application.ViewModels.UserViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "ESTE CAMPO ES OBLIGATORIO")]
        public string UserName { get; set; } = null!;
        public string PassWord { get; set; } = null!;
    }
}
