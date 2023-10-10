using GestorDePacientes.Core.Application.Interfaces.Repositories;
using GestorDePacientes.Core.Domain.Entities;
using GestorDePacientes.Infrastructure.Persistence.Context;

namespace GestorDePacientes.Infrastructure.Persistence.Repositories
{
    public class LabTestRepository : GenericRepositoryAsync<LabTests>, ILabTestRepository
    {
        public LabTestRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
