namespace GestorDePacientes.Core.Application.ViewModels.LabResultViewModels
{
    public class LabResultViewModel
    {
        public int Id { get; set; }
        public int IdPatient { get; set; }
        public int IdMedicalAppoinment { get; set; }
        public string? PatientName { get; set; }
        public string? PatientIdentification { get; set; }
        public int IdLabTest { get; set; }
        public string? LabTestName { get; set; }
        public bool IsCompleted { get; set; }
        public string? Comments { get; set; }
    }
}
