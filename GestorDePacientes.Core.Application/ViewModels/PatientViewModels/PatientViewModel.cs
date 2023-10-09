namespace GestorDePacientes.Core.Application.ViewModels.PatientViewModels
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Identification { get; set; } = null!;
        public DateTime DateOfBorn { get; set; }
        public string Direction { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public bool IsSmoker { get; set; }
        public bool IsAllegier { get; set; }
    }
}
