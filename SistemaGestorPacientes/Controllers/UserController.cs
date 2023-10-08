using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.SistemaGestorPacientes.Controllers
{
    public class UserController : Controller
    {
        private readonly IRolServices _rolServices;
        private readonly IUserServices _userServices;

        public UserController(IRolServices rolServices, IUserServices userServices)
        {
            _rolServices = rolServices;
            _userServices = userServices;
        }

        public IActionResult Index()
        {
            return View( new List<UserViewModel>());
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Rols = await _rolServices.GetAll();
            return View(new SaveUserViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveUserViewModel vm)
        {
            await _userServices.Add(vm);
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }
    }
}
