using AutoMapper;
using GestorDePacientes.Core.Application.Helpers;
using GestorDePacientes.Core.Application.Interfaces.Repositories;
using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.ViewModels.UserViewModels;
using GestorDePacientes.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<bool> ChangePassword(ChangePasswordViewModel vm)
        {
            //Busco el usuario al que quiero cambiar la password.
            var userCreated = await _userRepository.GetByIdAsync(vm.Id);

            /*Encripto y valido si la password vieja que el usuario mando
             es igual a la que esta en la base de datos.*/
            var oldPassword = PassWordEncryption.ComputeSha256Hash(vm.OldPassword);

            //Si son diferentes manda False.
            if(oldPassword != userCreated.Password)
            {
                return false;
            }
            //Si son iguales procede a cambiar la password.
            userCreated.Password = PassWordEncryption.ComputeSha256Hash(vm.NewPassword); ;
            await _userRepository.UpdateAsync(userCreated, userCreated.Id);
            return true;
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
    }
}
