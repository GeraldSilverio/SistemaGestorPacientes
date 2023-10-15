namespace GestorDePacientes.Core.Application.ViewModels.MedicalViewModels
{
    public class MedicalViewModel
    {
        public int Id { get; set; }
        public string PatientName { get; set; } = null!;
        public string DoctortName { get; set; } = null!;
        public string StatustName { get; set; } = null!;
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }
        public int IdAppoinmentStatus { get; set; }
        public string? DateOfAppoinment { get; set; }
        public TimeSpan HourOfAppoinment { get; set; } 
        public string ReasonOfAppoinment { get; set; } = null!;
    }
}
