using GestorDePacientes.Core.Application.Validations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GestorDePacientes.Core.Application.ViewModels.UserViewModels
{
    public class SaveUserViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.Text)]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.Text)]
        [UserEmailValidation]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.Text)]
        [UserNameValidation]
        public string UserName { get; set; } = null!;
        [Required(ErrorMessage = "Este campo es requerido")]

        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Compare(nameof(Password), ErrorMessage = "Las contraseñas no coiciden")]
        [Required(ErrorMessage = "Debe colocar una contraseña")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El valor proporcionado para IdRol está fuera del rango válido.")]
        public int IdRol { get; set; }

    }
}
