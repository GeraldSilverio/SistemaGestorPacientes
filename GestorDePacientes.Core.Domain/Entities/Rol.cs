using GestorDePacientes.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDePacientes.Core.Domain.Entities
{
    public class Rol:AuditableBaseEntity
    {
        public string Name { get; set; } = null!;

        public ICollection<User> Users { get; set; } = null!;
    }
}
