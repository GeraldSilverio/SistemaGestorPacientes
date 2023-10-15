using GestorDePacientes.Core.Application.Interfaces.Repositories;
using GestorDePacientes.Core.Domain.Entities;
using GestorDePacientes.Infrastructure.Persistence.Context;

namespace GestorDePacientes.Infrastructure.Persistence.Repositories
{
    public class LabResultRepository : GenericRepositoryAsync<PatientLabTests>, ILabResultRepository
    {
        public LabResultRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
