using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GestorDePacientes.Core.Application.ViewModels.UserViewModels
{
    public class SaveUserViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name cannot be empty")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "LastName cannot be empty")]
        [DataType(DataType.Text)]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage = "Email cannot be empty")]
        [DataType(DataType.Text)]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "User cannot be empty")]
        [DataType(DataType.Text)]
        public string UserName { get; set; } = null!;
        [Required(ErrorMessage = "Password cannot be empty")]

        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;

        [Range(1 , int.MaxValue)]
        public int IdRol { get; set; }

    }
}
