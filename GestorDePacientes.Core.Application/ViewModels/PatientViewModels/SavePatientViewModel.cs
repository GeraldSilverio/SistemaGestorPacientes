using GestorDePacientes.Core.Application.Validations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GestorDePacientes.Core.Application.ViewModels.PatientViewModels
{
    public class SavePatientViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Debe completar este campo")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Debe completar este campo")]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage = "Debe completar este campo")]
        public string PhoneNumber { get; set; } = null!;
        [Required(ErrorMessage = "Debe completar este campo")]
        [PatientIdentificationValidation]
        public string Identification { get; set; } = null!;
        [Required(ErrorMessage = "Debe completar este campo")]
        public DateTime DateOfBorn { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Debe completar este campo")]
        public string Direction { get; set; } = null!;

        [DataType(DataType.Upload)]
        public IFormFile? File { get; set; }
        public string? ImageUrl { get; set; }
        [Required(ErrorMessage = "Debe completar este campo")]
        public bool IsSmoker { get; set; }
        [Required(ErrorMessage = "Debe completar este campo")]
        public bool IsAllegier { get; set; }
    }
}
