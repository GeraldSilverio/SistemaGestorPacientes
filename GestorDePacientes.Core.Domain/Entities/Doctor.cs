using GestorDePacientes.Core.Domain.Common;

namespace GestorDePacientes.Core.Domain.Entities
{
    public class Doctor:AuditableBaseEntity
    {
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Identification { get; set; } = null!;
        public string ImageUrl { get; set; }

        //Relacion con tabla MedicalAppoinment
        public ICollection<MedicalAppointment> MedicalAppointments { get; set; } = null!;
    }
}
