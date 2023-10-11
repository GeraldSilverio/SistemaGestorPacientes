using GestorDePacientes.Core.Application.Interfaces.Repositories;
using GestorDePacientes.Core.Domain.Entities;
using GestorDePacientes.Infrastructure.Persistence.Context;

namespace GestorDePacientes.Infrastructure.Persistence.Repositories
{
    public class AppoinmentStatusRepository : GenericRepositoryAsync<AppoinmentStatus>, IAppoinmentStatusRepository
    {
        public AppoinmentStatusRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
