using GestorDePacientes.Core.Application.Interfaces.Repositories;
using GestorDePacientes.Core.Domain.Entities;
using GestorDePacientes.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace GestorDePacientes.Infrastructure.Persistence.Repositories
{
    public class AppoinmentStatusRepository : GenericRepositoryAsync<AppoinmentStatus>, IAppoinmentStatusRepository
    {
        private readonly ApplicationContext _dbcontext;
        public AppoinmentStatusRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<int> GetAppoinmetIdbyName(string name)
        {
            var appoinmetId = await _dbcontext.AppoinmentStatuses
                .FirstOrDefaultAsync(x => x.Description == name);

            return appoinmetId.Id;
        }
    }
}
