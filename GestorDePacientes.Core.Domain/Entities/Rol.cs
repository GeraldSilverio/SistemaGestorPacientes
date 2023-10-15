using GestorDePacientes.Core.Domain.Common;

namespace GestorDePacientes.Core.Domain.Entities
{
    public class Rol:AuditableBaseEntity
    {
        public string Name { get; set; } = null!;

        public ICollection<User> Users { get; set; } = null!;
    }
}
