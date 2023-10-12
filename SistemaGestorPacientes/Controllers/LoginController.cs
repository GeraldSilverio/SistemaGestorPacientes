using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc;
using SistemaGestorPacientes.Models;
using System.Diagnostics;

namespace SistemaGestorPacientes.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserServices _userServices;

        public LoginController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public IActionResult Index()
        {
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
                var user = await _userServices.LoginAsync(vm);

                if (user != null)
                {
                    return RedirectToRoute(new { controller = "User", action = "Index" });
                }
                else
                {
                    ModelState.AddModelError("userValidation", "Datos de acceso incorrectos");
                }

                return View("Index", vm);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}