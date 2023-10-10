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

        public async Task<IActionResult> Index()
        {
            return View(await _userServices.GetAllViewModelWithInclude());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Rols = await _rolServices.GetAll();
            return View(new SaveUserViewModel());
        }

        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Rols = await _rolServices.GetAll();
            var entity = await _userServices.GetById(id);
            return View("Create", entity);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _userServices.GetById(id);
            return View("Delete", entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveUserViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Rols = await _rolServices.GetAll();
                    return View("Create", vm);
                }

                await _userServices.Add(vm);
                return RedirectToRoute(new { controller = "User", action = "Index" });

            }
            catch (Exception ex)
            {
                return View("Index", ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> DeleteP(int id)
        {
            try
            {
                await _userServices.Delete(id);
                return RedirectToRoute(new { controller = "User", action = "Index" });

            }
            catch (Exception ex)
            {
                return View("Index", ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Update(SaveUserViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var userExisted = await _userServices.GetById(vm.Id);
                    if ((vm.Id == userExisted.Id) && (vm.UserName == userExisted.UserName))
                    {
                        await _userServices.Update(vm, vm.Id);
                        return RedirectToRoute(new { controller = "User", action = "Index" });
                    }

                    ViewBag.Rols = await _rolServices.GetAll();
                    return View("Create", vm);
                }
                await _userServices.Update(vm, vm.Id);
                return RedirectToRoute(new { controller = "User", action = "Index" });

            }
            catch (Exception ex)
            {
                return View("Index", ex.Message);
            }
        }
    }
}
