using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.Services;
using GestorDePacientes.Core.Application.ViewModels.AppoinmentStatusViewModels;
using GestorDePacientes.Core.Application.ViewModels.RolViewModels;
using Microsoft.AspNetCore.Mvc;
using WebApp.SistemaGestorPacientes.Middlewares;

namespace WebApp.SistemaGestorPacientes.Controllers
{
    public class RolController : Controller
    {

        private readonly IRolServices _rolServices;
        private readonly ValidateUserSession _validateUserSession;
        public RolController(IRolServices rolServices, ValidateUserSession validateUserSession)
        {
            _rolServices = rolServices;
            _validateUserSession = validateUserSession;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                if (!_validateUserSession.HasAdmin())
                {
                    return RedirectToRoute(new { controller = "Login", action = "Index" });
                }
                var roles = await _rolServices.GetAll();
                return View(roles);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }
        public IActionResult Create()
        {
            if (!_validateUserSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            return View(new SaveRolViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveRolViewModel vm)
        {
            try
            {
                if (!_validateUserSession.HasAdmin())
                {
                    return RedirectToRoute(new { controller = "Login", action = "Index" });
                }
                if (!ModelState.IsValid)
                {
                    return View("Create", vm);
                }
                vm.Name = vm.Name.ToUpper();
                await _rolServices.Add(vm);
                return RedirectToRoute(new { controller = "Rol", action = "Index" });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                if (!_validateUserSession.HasAdmin())
                {
                    return RedirectToRoute(new { controller = "Login", action = "Index" });
                }
                var rol = await _rolServices.GetById(id);
                return View("Create", rol);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(SaveRolViewModel vm)
        {
            try
            {
                if (!_validateUserSession.HasAdmin())
                {
                    return RedirectToRoute(new { controller = "Login", action = "Index" });
                }
                if (!ModelState.IsValid)
                {
                    return View("Create", vm);
                }
                vm.Name = vm.Name.ToUpper();
                await _rolServices.Update(vm, vm.Id);
                return RedirectToRoute(new { controller = "Rol", action = "Index" });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!_validateUserSession.HasAdmin())
                {
                    return RedirectToRoute(new { controller = "Login", action = "Index" });
                }
                var rol = await _rolServices.GetById(id);
                return View("Delete", rol);

            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                if (!_validateUserSession.HasAdmin())
                {
                    return RedirectToRoute(new { controller = "Login", action = "Index" });
                }
                await _rolServices.Delete(id);
                return RedirectToRoute(new { controller = "Rol", action = "Index" });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}