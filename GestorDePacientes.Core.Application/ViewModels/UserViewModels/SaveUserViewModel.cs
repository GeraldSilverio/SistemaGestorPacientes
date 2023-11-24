using GestorDePacientes.Core.Application.Validations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GestorDePacientes.Core.Application.ViewModels.UserViewModels
{
    public class SaveUserViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "ESTE CAMPO ES OBLIGATORIO")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "ESTE CAMPO ES OBLIGATORIO")]
        [DataType(DataType.Text)]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage = "ESTE CAMPO ES OBLIGATORIO")]
        [DataType(DataType.Text)]
        [UserValidations]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "ESTE CAMPO ES OBLIGATORIO")]
        [DataType(DataType.Text)]
        [UserValidations]
        public string UserName { get; set; } = null!;
        [Required(ErrorMessage = "ESTE CAMPO ES OBLIGATORIO")]

        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Compare(nameof(Password), ErrorMessage = "LAS CONTRASEÑAS NO COINCIDEN")]
        [Required(ErrorMessage = "ESTE CAMPO ES OBLIGATORIO")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "DEBE SELECCIONAR UN ROL.")]
        public int IdRol { get; set; }

    }
}
