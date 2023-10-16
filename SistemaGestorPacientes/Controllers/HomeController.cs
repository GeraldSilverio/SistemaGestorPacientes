using Microsoft.AspNetCore.Mvc;
using WebApp.SistemaGestorPacientes.Middlewares;

namespace WebApp.SistemaGestorPacientes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ValidateUserSession _validateUserSession;

        public HomeController(ValidateUserSession validateUserSession)
        {
            _validateUserSession = validateUserSession;
        }

        public IActionResult Index()
        {
            if(!_validateUserSession.HasAsis() && !_validateUserSession.HasAdmin())
            {
                return RedirectToRoute(new {controller ="Login", action="Index"});
            }
            return View();
        }
    }
}
