using GestorDePacientes.Core.Application.ViewModels.LabTestViewModels;
using GestorDePacientes.Core.Domain.Entities;

namespace GestorDePacientes.Core.Application.Interfaces.Services
{
    public interface ILabTestServices:IGenericService<SaveLabTestViewModel,LabTestViewModel,LabTests>
    {
    }
}
