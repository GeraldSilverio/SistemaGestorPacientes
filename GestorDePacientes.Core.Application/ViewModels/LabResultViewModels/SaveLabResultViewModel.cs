using System.ComponentModel.DataAnnotations;

namespace GestorDePacientes.Core.Application.ViewModels.LabResultViewModels
{
    public class SaveLabResultViewModel
    {
        public int Id { get; set; }
        public int IdMedicalAppoinment { get; set; }
        public int IdPatient { get; set; }
        public List<int>? IdLabTest { get; set; }
        public int IdLabTests { get; set; }
        public bool IsCompleted { get; set; }
        public string? Comments { get; set; }
    }
}
