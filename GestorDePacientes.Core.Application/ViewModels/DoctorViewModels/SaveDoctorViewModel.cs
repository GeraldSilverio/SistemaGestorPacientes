using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GestorDePacientes.Core.Application.ViewModels.DoctorViewModels
{
    public class SaveDoctorViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "ESTE CAMPO ES OBLIGATORIO")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "ESTE CAMPO ES OBLIGATORIO")]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage = "ESTE CAMPO ES OBLIGATORIO")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "ESTE CAMPO ES OBLIGATORIO")]
        public string PhoneNumber { get; set; } = null!;
        [Required(ErrorMessage = "ESTE CAMPO ES OBLIGATORIO")]
        public string Identification { get; set; } = null!;
        public string? ImageUrl { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? File { get; set; }
    }
}
