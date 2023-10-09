using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.ViewModels.PatientViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.SistemaGestorPacientes.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _patientService.GetAll());
        }
        public IActionResult Create()
        {
            return View(new SavePatientViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SavePatientViewModel vm)
        {
            try
            {

                var patientCreated = await _patientService.Add(vm);
                patientCreated.ImageUrl = "";
                return RedirectToRoute(new { controller = "Patient", action = "Index" });

            }
            catch (Exception ex)
            {
                return View("Index", ex);
            }

        }
    }
}
