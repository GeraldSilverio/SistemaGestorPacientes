using AutoMapper;
using GestorDePacientes.Core.Application.Interfaces.Repositories;
using GestorDePacientes.Core.Application.ViewModels.LabResultViewModels;
using GestorDePacientes.Core.Domain.Entities;

namespace GestorDePacientes.Core.Application.Services
{
    public class LabResultServices : GenericService<SaveLabResultViewModel, LabResultViewModel, PatientLabTests>
    {
        public LabResultServices(IMapper mapper, ILabResultRepository labResultRepository) : base(mapper, labResultRepository)
        {
        }
    }

}
