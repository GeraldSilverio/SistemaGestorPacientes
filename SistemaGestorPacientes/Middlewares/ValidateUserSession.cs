using GestorDePacientes.Core.Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Http;
using GestorDePacientes.Core.Application.Helpers;

namespace WebApp.SistemaGestorPacientes.Middlewares
{
    public class ValidateUserSession
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValidateUserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool HasAsis()
        {
            UserViewModel userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");


            if (userViewModel == null || userViewModel.RolName != "Asistente")
            {
                return false;
            }
            return true;
        }
        public bool HasAdmin()
        {
            UserViewModel userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");

            if (userViewModel == null || userViewModel.RolName != "Administrador")
            {
                return false;
            }

            return true;
        }

    }
}

