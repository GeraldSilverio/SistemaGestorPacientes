using Microsoft.AspNetCore.Mvc;

namespace WebApp.SistemaGestorPacientes.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
