using AutoMapper;
using GestorDePacientes.Core.Application.Interfaces.Repositories;
using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.ViewModels.RolViewModels;
using GestorDePacientes.Core.Domain.Entities;

namespace GestorDePacientes.Core.Application.Services
{
    public class RolServices : GenericService<SaveRolViewModel, RolViewModel, Rol>, IRolServices
    {
        public RolServices(IMapper mapper, IRolRepository rolRepository) : base(mapper, rolRepository)
        {
        }
    }
}
