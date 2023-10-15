using GestorDePacientes.Core.Domain.Common;

namespace GestorDePacientes.Core.Domain.Entities
{
    public class Patient:AuditableBaseEntity
    {
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Identification { get; set; } = null!;
        public DateTime DateOfBorn { get; set; }
        public string Direction { get; set; } = null!;
        public string ImageUrl { get; set; }
        public bool IsSmoker { get; set; }
        public bool IsAllegier { get; set; }

        //Relacion con tabla LabTest.
        public ICollection<PatientLabTests> PatientLabTests { get; set; } = null!;

        //Relacion con tabla MedicalAppoinment
        public ICollection<MedicalAppointment> MedicalAppointments { get; set; } = null!;   


    }
}
