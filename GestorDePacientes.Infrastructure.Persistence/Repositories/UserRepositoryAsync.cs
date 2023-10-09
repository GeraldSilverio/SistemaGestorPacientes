using GestorDePacientes.Core.Application.Interfaces.Repositories;
using GestorDePacientes.Core.Domain.Entities;
using GestorDePacientes.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDePacientes.Infrastructure.Persistence.Repositories
{
    public class UserRepositoryAsync : GenericRepositoryAsync<User>, IUserRepository
    {
        private readonly ApplicationContext _dbContext;
        public UserRepositoryAsync(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public bool ValidateUserName(string userName)
        {
            var isCreated =  _dbContext.Users.Any(x=> x.UserName == userName);
            return isCreated;
        }
    }
}
