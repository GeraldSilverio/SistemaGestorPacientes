using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.ViewModels.LabTestViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.SistemaGestorPacientes.Controllers
{
    public class LabTestsController : Controller
    {
        private readonly ILabTestServices _labTestsServices;

        public LabTestsController(ILabTestServices labTestsServices)
        {
            _labTestsServices = labTestsServices;
        }

        public async Task<IActionResult> Index()
        {
            var labTests = await _labTestsServices.GetAll();
            return View(labTests);
        }

        public IActionResult Create()
        {
            return View(new SaveLabTestViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveLabTestViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", vm);
                }

                await _labTestsServices.Add(vm);
                return RedirectToRoute(new { controller = "LabTests", action = "Index" });
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
                var labTest = await _labTestsServices.GetById(id);
                return View("Create", labTest);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(SaveLabTestViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", vm);
                }
                await _labTestsServices.Update(vm, vm.Id);
                return RedirectToRoute(new { controller = "LabTests", action = "Index" });
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
                var labTest = await _labTestsServices.GetById(id);
                return View("Delete", labTest);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteP(int id)
        {
            try
            {
                await _labTestsServices.Delete(id);
                return RedirectToRoute(new { controller = "LabTests", action = "Index" });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }


    }
}