using System.ComponentModel.DataAnnotations;

namespace GestorDePacientes.Core.Application.ViewModels.LabResultViewModels
{
    public class SaveLabResultViewModel
    {
        public int Id { get; set; } = 0;
        public int IdMedicalAppoinment { get; set; } = 0;
        public int IdPatient { get; set; } = 0;

        [Range(1, int.MaxValue, ErrorMessage = "ESTE CAMPO ES OBLIGATORIO")]
        public List<int> IdLabTest { get; set; }
        public int? IdLabTests { get; set; } = 0;
        public bool IsCompleted { get; set; }= false;
        public string? Comments { get; set; } = " ";
    }
}
