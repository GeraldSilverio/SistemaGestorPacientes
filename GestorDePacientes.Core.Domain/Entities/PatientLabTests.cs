using GestorDePacientes.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDePacientes.Core.Domain.Entities
{
    public class PatientLabTests : AuditableBaseEntity
    {
        public int IdPatient { get; set; }
        public Patient Patient { get; set; } = null!;
        public int IdLabTests { get; set; }
        public LabTests LabTests { get; set; } = null!;
        public string Comments { get; set; } = null!;
        public bool IsCompleted { get; set; }
    }
}
