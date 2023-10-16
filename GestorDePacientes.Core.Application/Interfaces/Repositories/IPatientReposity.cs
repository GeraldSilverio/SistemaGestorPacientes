using GestorDePacientes.Core.Domain.Entities;

namespace GestorDePacientes.Core.Application.Interfaces.Repositories
{
    public interface IPatientReposity : IGenericRepositoryAsync<Patient>
    {
        bool ValidateIdentification(string identification);
    }
}
