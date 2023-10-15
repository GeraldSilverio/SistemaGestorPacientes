using GestorDePacientes.Core.Application.Interfaces.Repositories;
using GestorDePacientes.Core.Domain.Entities;
using GestorDePacientes.Infrastructure.Persistence.Context;

namespace GestorDePacientes.Infrastructure.Persistence.Repositories
{
    public class MedicalAppoinmentRepository : GenericRepositoryAsync<MedicalAppointment>, IMedicalAppoinmentRepository
    {
        public MedicalAppoinmentRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
