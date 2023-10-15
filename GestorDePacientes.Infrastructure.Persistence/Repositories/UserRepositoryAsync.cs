using GestorDePacientes.Core.Application.Helpers;
using GestorDePacientes.Core.Application.Interfaces.Repositories;
using GestorDePacientes.Core.Application.ViewModels.UserViewModels;
using GestorDePacientes.Core.Domain.Entities;
using GestorDePacientes.Infrastructure.Persistence.Context;

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
            var isCreated = _dbContext.Users.Any(x => x.UserName == userName);
            return isCreated;
        }

        public override async Task<User> AddAsync(User entity)
        {
            entity.Password = PassWordEncryption.ComputeSha256Hash(entity.Password);
            await base.AddAsync(entity);
            return entity;
        }

        public async Task<User> LoginAsync(LoginViewModel loginView)
        {
            string passwordEncrypy = PassWordEncryption.ComputeSha256Hash(loginView.Password);

            var users = await GetAllWithIncludeAsync(new List<string> { "Rol" });
            User user = users.FirstOrDefault(user => user.UserName ==loginView.UserName && user.Password == passwordEncrypy) ;

            return user;
        }
    }
}
