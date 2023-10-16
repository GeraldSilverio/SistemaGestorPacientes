using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.ViewModels.PatientViewModels;
using Microsoft.AspNetCore.Mvc;
using WebApp.SistemaGestorPacientes.Middlewares;

namespace WebApp.SistemaGestorPacientes.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly ValidateUserSession _validateUserSession;

        public PatientController(IPatientService patientService, ValidateUserSession validateUserSession)
        {
            _patientService = patientService;
            _validateUserSession = validateUserSession;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasAsis())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            return View(await _patientService.GetAll());
        }

        public IActionResult Create()
        {
            if (!_validateUserSession.HasAsis())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            return View(new SavePatientViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SavePatientViewModel vm)
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
                SavePatientViewModel patientCreated = await _patientService.Add(vm);

                if (patientCreated != null && patientCreated.Id != 0)
                {
                    patientCreated.ImageUrl = _patientService.UplpadFile(vm.File, patientCreated.Id);
                    await _patientService.Update(patientCreated, patientCreated.Id);
                }
                return RedirectToRoute(new { controller = "Patient", action = "Index" });

            }
            catch (Exception ex)
            {
                return View("Index", ex);
            }

        }

        public async Task<IActionResult> Update(int id)
        {
            if (!_validateUserSession.HasAsis())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            var patient = await _patientService.GetById(id);
            return View("Create", patient);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SavePatientViewModel vm)
        {
            try
            {
                if (!_validateUserSession.HasAsis())
                {
                    return RedirectToRoute(new { controller = "Login", action = "Index" });
                }
                if (!ModelState.IsValid)
                {
                    //Validando que si estoy editando el mismo paciente con su cedula, si es el mismo se edita
                    var userExisted = await _patientService.GetById(vm.Id);
                    if ((vm.Id == userExisted.Id) && (vm.Identification == userExisted.Identification))
                    {
                        await _patientService.Update(vm, vm.Id);
                        return RedirectToRoute(new { controller = "Patient", action = "Index" });
                    }
                    //Si no era el mismo, y era otro diferente que queria cambiar su cedula, le dara el mensaje.
                    return View("Create", vm);
                }
                //Cambiar la foto del paciente.
                SavePatientViewModel patientCreated = await _patientService.GetById(vm.Id);
                if (patientCreated != null && patientCreated.Id != 0)
                {
                    vm.ImageUrl = _patientService.UplpadFile(vm.File, patientCreated.Id, true, patientCreated.ImageUrl);
                    await _patientService.Update(vm, vm.Id);
                }
                return RedirectToRoute(new { controller = "Patient", action = "Index" });
            }
            catch (Exception ex)
            {
                return View("Index", ex);
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
                var patient = await _patientService.GetById(id);
                return View("Delete", patient);
            }
            catch (Exception ex)
            {
                return View("Index", ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteP(int id)
        {
            try
            {
                if (!_validateUserSession.HasAsis())
                {
                    return RedirectToRoute(new { controller = "Login", action = "Index" });
                }
                await _patientService.Delete(id);
                return RedirectToRoute(new { controller = "Patient", action = "Index" });

            }
            catch (Exception ex)
            {
                return View("Index", ex.Message);
            }
        }
    }
}
