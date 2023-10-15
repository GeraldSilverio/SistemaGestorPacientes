using GestorDePacientes.Core.Domain.Common;

namespace GestorDePacientes.Core.Domain.Entities
{
    public class AppoinmentStatus:AuditableBaseEntity
    {
        public string Description { get; set; } = null!;

        public ICollection<MedicalAppointment> MedicalAppointments { get; set; } = null!;
    }
}
