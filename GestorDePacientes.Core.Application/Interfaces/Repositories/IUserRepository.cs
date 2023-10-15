using GestorDePacientes.Core.Application.ViewModels.UserViewModels;
using GestorDePacientes.Core.Domain.Entities;

namespace GestorDePacientes.Core.Application.Interfaces.Repositories
{
    public interface IUserRepository:IGenericRepositoryAsync<User>
    {
        bool ValidateUserName(string userName);
        Task<User> LoginAsync(LoginViewModel loginView);
    }
}
