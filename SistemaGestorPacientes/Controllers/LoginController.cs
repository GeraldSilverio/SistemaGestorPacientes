using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc;
using GestorDePacientes.Core.Application.Helpers;
using Microsoft.AspNetCore.Http;
using WebApp.SistemaGestorPacientes.Middlewares;

namespace SistemaGestorPacientes.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly ValidateUserSession _validateUserSession;
        public LoginController(IUserServices userServices, ValidateUserSession validateUserSession)
        {
            _userServices = userServices;
            _validateUserSession = validateUserSession;
        }

        public IActionResult Index()
        {
            if (_validateUserSession.HasAsis() || _validateUserSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Index", vm);
                }
                UserViewModel user = await _userServices.LoginAsync(vm);

                if (user != null)
                {
                    HttpContext.Session.Set<UserViewModel>("user", user);
                    return RedirectToRoute(new { controller = "Home", action = "Index" });
                }
                else
                {
                    ModelState.AddModelError("userValidation", "DATOS DE ACCESO INCORRECTOS");
                }

                return View("Index", vm);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("user");
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }
    }
}