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
        public UserServices(IMapper mapper, IGenericRepositoryAsync<User> repositoryAsync) : base(mapper, repositoryAsync)
        {
        }


    }
}
