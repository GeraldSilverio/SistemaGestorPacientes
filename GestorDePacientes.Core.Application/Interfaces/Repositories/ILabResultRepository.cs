using GestorDePacientes.Core.Domain.Entities;

namespace GestorDePacientes.Core.Application.Interfaces.Repositories
{
    public interface ILabResultRepository :IGenericRepositoryAsync<PatientLabTests>
    {
        Task DeleteByIdAppoinment(int id);
    }
}
