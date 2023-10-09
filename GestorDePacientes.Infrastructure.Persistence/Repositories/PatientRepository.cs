using GestorDePacientes.Core.Application.Interfaces.Repositories;
using GestorDePacientes.Core.Domain.Entities;
using GestorDePacientes.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDePacientes.Infrastructure.Persistence.Repositories
{
    public class PatientRepository : GenericRepositoryAsync<Patient>, IPatientReposity
    {
        public PatientRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
