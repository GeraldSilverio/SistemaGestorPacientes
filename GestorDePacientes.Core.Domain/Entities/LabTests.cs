using GestorDePacientes.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDePacientes.Core.Domain.Entities
{
    public class LabTests:AuditableBaseEntity
    {
        public string Name { get; set; } = null!;
        public ICollection<PatientLabTests> PatientLabTests { get; set; } = null!;

    }
}
