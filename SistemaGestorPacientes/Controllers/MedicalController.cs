﻿using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.ViewModels.LabResultViewModels;
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
        private readonly ILabTestServices _labTestServices;
        private readonly ILabResultServices _labResultServices;
        private readonly ValidateUserSession _validateUserSession;

        public MedicalController(IMedicalAppoinmentService medicalService, IPatientService patientService, IDoctorServices doctorServices, ValidateUserSession validateUserSession, IAppoinmetStatusService appoinmetStatusService, ILabTestServices labTestServices, ILabResultServices labResultServices)
        {
            _medicalService = medicalService;
            _patientService = patientService;
            _doctorServices = doctorServices;
            _validateUserSession = validateUserSession;
            _appoinmetStatusService = appoinmetStatusService;
            _labTestServices = labTestServices;
            _labResultServices = labResultServices;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                if (!_validateUserSession.HasAsis())
                {
                    return RedirectToRoute(new { controller = "Home", action = "Index" });
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
                    return RedirectToRoute(new { controller = "Home", action = "Index" });
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
                    return RedirectToRoute(new { controller = "Home", action = "Index" });
                }
                if (!ModelState.IsValid)
                {
                    ViewBag.Patients = await _patientService.GetAll();
                    ViewBag.Doctors = await _doctorServices.GetAll();
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
                    return RedirectToRoute(new { controller = "Home", action = "Index" });
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
                    return RedirectToRoute(new { controller = "Home", action = "Index" });
                }
                await _labResultServices.DeleteByIdAppoinment(id);
                await _medicalService.Delete(id);
                return RedirectToRoute(new { controller = "Medical", action = "Index" });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public async Task<IActionResult> Consultar(int id)
        {
            try
            {
                if (!_validateUserSession.HasAsis())
                {
                    return RedirectToRoute(new { controller = "Home", action = "Index" });
                }

                //Pruebas de laboratorio disponibles
                ViewBag.LabTest = await _labTestServices.GetAll();

                //Creo un modelo de LabResult con el id de la cita
                var labResult = new SaveLabResultViewModel();
                labResult.IdMedicalAppoinment = id;

                //Retorno el modelo
                return View("Consultar", labResult);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Consultar(SaveLabResultViewModel vm)
        {
            try
            {

                if (!_validateUserSession.HasAsis())
                {
                    return RedirectToRoute(new { controller = "Home", action = "Index" });
                }

                if (vm.IdLabTest == null)
                {
                    ModelState.AddModelError("medicalValidation", "DEBE SELECCIONAR AL MENOS UNA PRUEBA");
                    ViewBag.LabTest = await _labTestServices.GetAll();
                    return View(vm);
                }
                vm.Id = 0;
                await _labResultServices.Add(vm);

                //Obtengo la Cita creada.
                var medicalCreated = await _medicalService.GetById(vm.IdMedicalAppoinment);

                //Cambiando el estado a Pendiente de Resultados.
                medicalCreated.IdAppoinmentStatus = await _appoinmetStatusService.GetAppoinmetIdbyName("PENDIENTE DE RESULTADOS");
                await _medicalService.Update(medicalCreated, medicalCreated.Id);

                return RedirectToRoute(new { controller = "Medical", action = "Index" });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public async Task<IActionResult> Results(int id)
        {
            if (!_validateUserSession.HasAsis())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            var labResults = await _labResultServices.GetByIdAppoinment(id);
            return View(labResults);
        }

        public async Task<IActionResult> ResultChange(int id)
        {
            if (!_validateUserSession.HasAsis())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            var medicalCreated = await _medicalService.GetById(id);
            medicalCreated.IdAppoinmentStatus = await _appoinmetStatusService.GetAppoinmetIdbyName("COMPLETADA");

            await _medicalService.Update(medicalCreated, medicalCreated.Id);
            return RedirectToRoute(new { controller = "Medical", action = "Index" });
        }
        public async Task<IActionResult> Completed(int id)
        {
            if (!_validateUserSession.HasAsis())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            var labResults = await _labResultServices.GetByIdAppoinment(id);
            return View(labResults);
        }
    }
}
