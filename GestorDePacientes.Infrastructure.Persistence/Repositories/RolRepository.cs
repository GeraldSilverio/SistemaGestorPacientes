﻿using GestorDePacientes.Core.Application.Interfaces.Repositories;
using GestorDePacientes.Core.Domain.Entities;
using GestorDePacientes.Infrastructure.Persistence.Context;

namespace GestorDePacientes.Infrastructure.Persistence.Repositories
{
    public class RolRepository : GenericRepositoryAsync<Rol>, IRolRepository
    {
        public RolRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
