using GestorDePacientes.Core.Application.Interfaces.Repositories;
using GestorDePacientes.Core.Domain.Entities;
using GestorDePacientes.Infrastructure.Persistence.Context;

namespace GestorDePacientes.Infrastructure.Persistence.Repositories
{
    public class DoctorRepository : GenericRepositoryAsync<Doctor>, IDoctorRepository
    {
        public DoctorRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
