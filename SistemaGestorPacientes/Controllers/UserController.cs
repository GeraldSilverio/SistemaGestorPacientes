using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc;
using WebApp.SistemaGestorPacientes.Middlewares;

namespace WebApp.SistemaGestorPacientes.Controllers
{
    public class UserController : Controller
    {
        private readonly IRolServices _rolServices;
        private readonly IUserServices _userServices;
        private readonly ValidateUserSession _validateUserSession;

        public UserController(IRolServices rolServices, IUserServices userServices, ValidateUserSession validateUserSession)
        {
            _rolServices = rolServices;
            _userServices = userServices;
            _validateUserSession = validateUserSession;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            return View(await _userServices.GetAllViewModelWithInclude());
        }

        public async Task<IActionResult> Create()
        {
            if (!_validateUserSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            ViewBag.Rols = await _rolServices.GetAll();
            return View(new SaveUserViewModel());
        }

        public async Task<IActionResult> Update(int id)
        {
            if (!_validateUserSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            ViewBag.Rols = await _rolServices.GetAll();
            var entity = await _userServices.GetById(id);
            entity.ConfirmPassword = entity.Password;
            return View("Create", entity);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            var entity = await _userServices.GetById(id);
            return View("Delete", entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveUserViewModel vm)
        {
            try
            {
                if (!_validateUserSession.HasAdmin())
                {
                    return RedirectToRoute(new { controller = "Login", action = "Index" });
                }
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
                if (!_validateUserSession.HasAdmin())
                {
                    return RedirectToRoute(new { controller = "Login", action = "Index" });
                }
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
                if (!_validateUserSession.HasAdmin())
                {
                    return RedirectToRoute(new { controller = "Login", action = "Index" });
                }
                if (!ModelState.IsValid)
                {

                    var userExisted = await _userServices.GetById(vm.Id);
                    if ((vm.Id == userExisted.Id) && (vm.UserName == userExisted.UserName) || (vm.Id == userExisted.Id) && (vm.Email == userExisted.Email))
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

        public async Task<IActionResult> ChangePassword(int id)
        {
            try
            {
                if (!_validateUserSession.HasAdmin())
                {
                    return RedirectToRoute(new { controller = "Login", action = "Index" });
                }
                var userCreated = await _userServices.GetById(id);
                var changePassword = new ChangePasswordViewModel();
                changePassword.Id = userCreated.Id;
                return View(changePassword);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpPost]

        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel vm)
        {
            if (!_validateUserSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            if (!await _userServices.ChangePassword(vm))
            {
                return View(vm);
            }
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }
    }
}
