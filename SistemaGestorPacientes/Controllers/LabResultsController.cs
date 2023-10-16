using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.ViewModels.LabResultViewModels;
using Microsoft.AspNetCore.Mvc;
using WebApp.SistemaGestorPacientes.Middlewares;

namespace WebApp.SistemaGestorPacientes.Controllers
{
    public class LabResultsController : Controller
    {
        private readonly ILabResultServices _labResultServices;
        private readonly ValidateUserSession _validateUserSession;

        public LabResultsController(ILabResultServices labResultServices, ValidateUserSession validateUserSession)
        {
            _labResultServices = labResultServices;
            _validateUserSession = validateUserSession;
        }

        public async Task<IActionResult> Index(FilterLabResultViewModel filter)
        {
            try
            {
                if (!_validateUserSession.HasAsis())
                {
                    return RedirectToRoute(new { controller = "Login", action = "Index" });
                }
                return View(await _labResultServices.GetByFiltersAsync(filter));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public async Task<IActionResult> Report(int id)
        {
            try
            {
                if (!_validateUserSession.HasAsis())
                {
                    return RedirectToRoute(new { controller = "Login", action = "Index" });
                }
               
                var labResultCreated = await _labResultServices.GetById(id);
                return View(labResultCreated);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Report(SaveLabResultViewModel vm)
        {
            try
            {
                if (!_validateUserSession.HasAsis())
                {
                    return RedirectToRoute(new { controller = "Login", action = "Index" });
                }

                //Reportando resultados.
                var LabResultCreated = await _labResultServices.GetById(vm.Id);
                LabResultCreated.IsCompleted= true;
                LabResultCreated.Comments = vm.Comments;


                await _labResultServices.Update(LabResultCreated, LabResultCreated.Id);
                return RedirectToRoute(new { controller = "LabResults", action = "Index" });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
