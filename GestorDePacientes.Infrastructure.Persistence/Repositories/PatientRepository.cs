using GestorDePacientes.Core.Application.Interfaces.Repositories;
using GestorDePacientes.Core.Domain.Entities;
using GestorDePacientes.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace GestorDePacientes.Infrastructure.Persistence.Repositories
{
    public class PatientRepository : GenericRepositoryAsync<Patient>, IPatientReposity
    {
        private readonly ApplicationContext _dbContext;
        public PatientRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public bool ValidateIdentification(string identification)
        {
            var isCreated = _dbContext.Patients.Any(x => x.Identification == identification);
            return isCreated;
        }
    }
}
