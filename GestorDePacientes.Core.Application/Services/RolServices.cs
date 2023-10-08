using AutoMapper;
using GestorDePacientes.Core.Application.Interfaces.Repositories;
using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.ViewModels.RolViewModels;
using GestorDePacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDePacientes.Core.Application.Services
{
    public class RolServices : GenericService<SaveRolViewModel, RolViewModel, Rol>, IRolServices
    {
        public RolServices(IMapper mapper, IGenericRepositoryAsync<Rol> repositoryAsync) : base(mapper, repositoryAsync)
        {
        }
    }
}
