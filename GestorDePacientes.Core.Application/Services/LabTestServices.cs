using AutoMapper;
using GestorDePacientes.Core.Application.Interfaces.Repositories;
using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.ViewModels.LabTestViewModels;
using GestorDePacientes.Core.Domain.Entities;

namespace GestorDePacientes.Core.Application.Services
{
    public class LabTestServices : GenericService<SaveLabTestViewModel, LabTestViewModel, LabTests>, ILabTestServices
    {
        public LabTestServices(IMapper mapper, ILabTestRepository _labTestRepository) : base(mapper, _labTestRepository)
        {
        }
    }
}