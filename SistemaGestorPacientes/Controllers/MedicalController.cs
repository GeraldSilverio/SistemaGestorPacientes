using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.ViewModels.MedicalViewModels;
using Microsoft.AspNetCore.Mvc;
using WebApp.SistemaGestorPacientes.Middlewares;

namespace WebApp.SistemaGestorPacientes.Controllers
{
    public class MedicalController : Controller
    {
        private readonly IMedicalAppoinmentService _medicalService;
        private readonly IAppoinmetStatusService _appoinmetStatusService;
        private readonly IPatientService _patientService;
        private readonly IDoctorServices _doctorServices;
        private readonly ValidateUserSession _validateUserSession;

        public MedicalController(IMedicalAppoinmentService medicalService, IPatientService patientService, IDoctorServices doctorServices, ValidateUserSession validateUserSession, IAppoinmetStatusService appoinmetStatusService)
        {
            _medicalService = medicalService;
            _patientService = patientService;
            _doctorServices = doctorServices;
            _validateUserSession = validateUserSession;
            _appoinmetStatusService = appoinmetStatusService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                if (!_validateUserSession.HasAsis())
                {
                    return RedirectToRoute(new { controller = "Login", action = "Index" });
                }
                return View(await _medicalService.GetAllViewModelWithInclude());
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }

        public async Task<IActionResult> Create()
        {
            try
            {
                if (!_validateUserSession.HasAsis())
                {
                    return RedirectToRoute(new { controller = "Login", action = "Index" });
                }
                ViewBag.Patients = await _patientService.GetAll();
                ViewBag.Doctors = await _doctorServices.GetAll();
                return View("Create", new SaveMedicalViewModel());
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveMedicalViewModel vm)
        {
            try
            {
                if (!_validateUserSession.HasAsis())
                {
                    return RedirectToRoute(new { controller = "Login", action = "Index" });
                }
                if (!ModelState.IsValid)
                {
                    return View("Create", vm);
                }
                vm.IdAppoinmentStatus = await _appoinmetStatusService.GetAppoinmetIdbyName("PENDIENTE DE CONSULTA");
                await _medicalService.Add(vm);
                return RedirectToRoute(new { controller = "Medical", action = "Index" });
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
                if (!_validateUserSession.HasAsis())
                {
                    return RedirectToRoute(new { controller = "Login", action = "Index" });
                }
                var medical = await _medicalService.GetById(id);
                return View("Delete", medical);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                if (!_validateUserSession.HasAsis())
                {
                    return RedirectToRoute(new { controller = "Login", action = "Index" });
                }
                await _medicalService.Delete(id);
                return RedirectToRoute(new {controller ="Medical",action = "Index"});
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
