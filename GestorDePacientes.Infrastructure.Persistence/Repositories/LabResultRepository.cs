using GestorDePacientes.Core.Application.Interfaces.Repositories;
using GestorDePacientes.Core.Domain.Entities;
using GestorDePacientes.Infrastructure.Persistence.Context;

namespace GestorDePacientes.Infrastructure.Persistence.Repositories
{
    public class LabResultRepository : GenericRepositoryAsync<PatientLabTests>, ILabResultRepository
    {
        private readonly ApplicationContext _dbContext;
        public LabResultRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteByIdAppoinment(int id)
        {
            var labResults =  _dbContext.PatientLabTests.Where(x => x.IdMedicalAppoinment == id).ToList();

            foreach (var Appoinmet in labResults)
            {
                _dbContext.PatientLabTests.Remove(Appoinmet);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
