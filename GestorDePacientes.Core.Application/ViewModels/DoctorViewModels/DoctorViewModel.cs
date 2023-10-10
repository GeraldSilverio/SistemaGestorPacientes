namespace GestorDePacientes.Core.Application.ViewModels.DoctorViewModels
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Identification { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}
