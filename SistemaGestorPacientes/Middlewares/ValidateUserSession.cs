using GestorDePacientes.Core.Application.ViewModels.UserViewModels;
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


            if (userViewModel == null || userViewModel.RolName != "ASISTENTE")
            {
                return false;
            }
            return true;
        }
        public bool HasAdmin()
        {
            UserViewModel userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");

            if (userViewModel == null || userViewModel.RolName != "ADMINISTRADOR")
            {
                return false;
            }

            return true;
        }

    }
}

