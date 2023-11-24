using GestorDePacientes.Core.Domain.Common;

namespace GestorDePacientes.Core.Domain.Entities
{
    public class MedicalAppointment:AuditableBaseEntity
    {
        public DateTime DateOfAppoinment { get; set; }
        public TimeSpan HourOfAppoinment { get; set; }
        public string ReasonOfAppoinment { get; set; } = null!;

        //Relation With Status.
        public int IdAppoinmentStatus { get; set; }
        public AppoinmentStatus AppoinmentStatus { get; set; } = null!;

        //Relation With Patient
        public int IdPatient { get; set; }
        public Patient Patient { get; set; } = null!;

        //Relation With Doctor
        public int IdDoctor { get; set; }
        public Doctor Doctor { get; set; } = null!;

        //Relacion con tabla LabTest.
        public ICollection<PatientLabTests> PatientLabTests { get; set; } = null!;
    }
}
