using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.Services;
using GestorDePacientes.Core.Application.ViewModels.AppoinmentStatusViewModels;
using GestorDePacientes.Core.Application.ViewModels.RolViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.SistemaGestorPacientes.Controllers
{
    public class RolController : Controller
    {

        private readonly IRolServices _rolServices;
        public RolController(IRolServices rolServices)
        {
            _rolServices = rolServices;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
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
            return View(new SaveRolViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveRolViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", vm);
                }
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
                if (!ModelState.IsValid)
                {
                    return View("Create", vm);
                }
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