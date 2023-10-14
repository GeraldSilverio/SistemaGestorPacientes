using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.ViewModels.AppoinmentStatusViewModels;
using Microsoft.AspNetCore.Mvc;
using WebApp.SistemaGestorPacientes.Middlewares;

namespace WebApp.SistemaGestorPacientes.Controllers
{
    public class AppoinmentController : Controller
    {
        private readonly IAppoinmetStatusService _appoinmetStatusService;
        private readonly ValidateUserSession _validateUserSession;
        public AppoinmentController(IAppoinmetStatusService appoinmetStatusService, ValidateUserSession validateUserSession)
        {
            _appoinmetStatusService = appoinmetStatusService;
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
                var appoinmets = await _appoinmetStatusService.GetAll();
                return View(appoinmets);
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
            return View(new SaveAppoinmentViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveAppoinmentViewModel vm)
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
                await _appoinmetStatusService.Add(vm);
                return RedirectToRoute(new { controller = "Appoinment", action = "Index" });
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
                var appoinment = await _appoinmetStatusService.GetById(id);
                return View("Create", appoinment);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(SaveAppoinmentViewModel vm)
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
                await _appoinmetStatusService.Update(vm, vm.Id);
                return RedirectToRoute(new { controller = "Appoinment", action = "Index" });
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
                var appoinment = await _appoinmetStatusService.GetById(id);
                return View("Delete", appoinment);

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
                await _appoinmetStatusService.Delete(id);
                return RedirectToRoute(new { controller = "Appoinment", action = "Index" });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }



    }
}
