using GestorDePacientes.Core.Domain.Entities;

namespace GestorDePacientes.Core.Application.Interfaces.Repositories
{
    public interface IAppoinmentStatusRepository : IGenericRepositoryAsync<AppoinmentStatus>
    {
        Task<int> GetAppoinmetIdbyName(string name);
    }
}
