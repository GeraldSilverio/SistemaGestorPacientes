using AutoMapper;
using GestorDePacientes.Core.Application.Interfaces.Repositories;
using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.ViewModels.UserViewModels;
using GestorDePacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDePacientes.Core.Application.Services
{
    public class UserServices : GenericService<SaveUserViewModel, UserViewModel, User>, IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IMapper mapper, IGenericRepositoryAsync<User> repositoryAsync, IUserRepository userRepository) : base(mapper, repositoryAsync)
        {
            _userRepository = userRepository;
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

        public bool ValidateUserName(string userName)
        {
           return  _userRepository.ValidateUserName(userName);
        }
    }
}
