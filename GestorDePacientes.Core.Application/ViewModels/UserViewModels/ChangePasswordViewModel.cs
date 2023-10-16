
using System.ComponentModel.DataAnnotations;


namespace GestorDePacientes.Core.Application.ViewModels.UserViewModels
{
    public class ChangePasswordViewModel
    {
        public int Id { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "ESTE CAMPO ES OBLIGATORIO")]
        public string OldPassword { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "ESTE CAMPO ES OBLIGATORIO")]
        public string NewPassword { get; set; } = null!;
        [Compare(nameof(NewPassword), ErrorMessage = "LAS CONTRASEÑAS NO COINCIDEN")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "ESTE CAMPO ES OBLIGATORIO")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
