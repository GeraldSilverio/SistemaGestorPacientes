using GestorDePacientes.Core.Application.ViewModels.UserViewModels;
using GestorDePacientes.Core.Domain.Entities;

namespace GestorDePacientes.Core.Application.Interfaces.Services
{
    public interface IUserServices:IGenericService<SaveUserViewModel,UserViewModel,User>
    {
        Task<List<UserViewModel>> GetAllViewModelWithInclude();
        Task<UserViewModel> LoginAsync(LoginViewModel loginView);

        Task<bool> ChangePassword(ChangePasswordViewModel vm);



    }
}
