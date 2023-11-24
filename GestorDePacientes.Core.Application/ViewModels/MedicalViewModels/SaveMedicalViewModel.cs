using System.ComponentModel.DataAnnotations;

namespace GestorDePacientes.Core.Application.ViewModels.MedicalViewModels
{
    public class SaveMedicalViewModel
    {

        public int Id { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "DEBE SELECCIONAR UN PACIENTE")]
        public int IdPatient { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "DEBE SELECCIONAR UN DOCTOR")]
        public int IdDoctor { get; set; }
        public int IdAppoinmentStatus { get; set; }
        [Required(ErrorMessage = "ESTE CAMPO ES OBLIGATORIO")]
        public DateTime DateOfAppoinment { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "ESTE CAMPO ES OBLIGATORIO")]
        public TimeSpan HourOfAppoinment { get; set; }
        [Required(ErrorMessage = "ESTE CAMPO ES OBLIGATORIO")]
        public string ReasonOfAppoinment { get; set; } = null!;
    }
}
