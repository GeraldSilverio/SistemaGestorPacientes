﻿using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.Services;
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
                SavePatientViewModel patientCreated = await _patientService.Add(vm);

                if(patientCreated != null && patientCreated.Id !=0)
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
            var patient = await _patientService.GetById(id);
            return View("Create", patient);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SavePatientViewModel vm)
        {

        }




    }
}