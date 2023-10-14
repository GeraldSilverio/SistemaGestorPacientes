using AutoMapper;
using GestorDePacientes.Core.Application.Interfaces.Repositories;
using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.ViewModels.UserViewModels;
using GestorDePacientes.Core.Domain.Entities;

namespace GestorDePacientes.Core.Application.Services
{
    public class UserServices : GenericService<SaveUserViewModel, UserViewModel, User>, IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserServices(IMapper mapper, IUserRepository userRepository) : base(mapper, userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<UserViewModel>> GetAllViewModelWithInclude()
        {
            var users = await _userRepository.GetAllWithIncludeAsync(new List<string> { "Rol" });

            return users.Select(user => new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                IdRol = user.Rol.Id,
                RolName = user.Rol.Name,
                Email = user.Email,
                UserName = user.UserName
            }).ToList();
        }

        public async Task<UserViewModel> LoginAsync(LoginViewModel loginView)
        {
            User user = await _userRepository.LoginAsync(loginView);

            if (user == null)
            {
                return null;
            }
            UserViewModel userVw = new()
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                IdRol = user.Rol.Id,
                RolName = user.Rol.Name,
                Email = user.Email,
                UserName = user.UserName,
            };
            return userVw;
        }

        public bool ValidateUserName(string userName)
        {
            return _userRepository.ValidateUserName(userName);
        }
    }
}
