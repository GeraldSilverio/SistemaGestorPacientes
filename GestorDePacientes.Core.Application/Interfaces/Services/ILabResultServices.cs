using GestorDePacientes.Core.Application.ViewModels.LabResultViewModels;
using GestorDePacientes.Core.Domain.Entities;

namespace GestorDePacientes.Core.Application.Interfaces.Services
{
    public interface ILabResultServices:IGenericService<SaveLabResultViewModel,LabResultViewModel,PatientLabTests>
    {
        Task<List<LabResultViewModel>> GetByFiltersAsync(FilterLabResultViewModel filter);
    }
}
