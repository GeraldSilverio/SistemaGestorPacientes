using GestorDePacientes.Core.Application.ViewModels.RolViewModels;
using GestorDePacientes.Core.Domain.Entities;

namespace GestorDePacientes.Core.Application.Interfaces.Services
{
    public interface IRolServices:IGenericService<SaveRolViewModel,RolViewModel, Rol>
    {
    }
}
