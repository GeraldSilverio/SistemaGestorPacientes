using AutoMapper;
using GestorDePacientes.Core.Application.Interfaces.Repositories;
using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.ViewModels.MedicalViewModels;
using GestorDePacientes.Core.Domain.Entities;

namespace GestorDePacientes.Core.Application.Services
{
    public class MedicalAppoinmentService : GenericService<SaveMedicalViewModel, MedicalViewModel, MedicalAppointment>, IMedicalAppoinmentService
    {
        private readonly IMedicalAppoinmentRepository _medicalAppoinmentRepository;
        public MedicalAppoinmentService(IMapper mapper, IMedicalAppoinmentRepository medicalAppoinmentRepository) : base(mapper, medicalAppoinmentRepository)
        {
            _medicalAppoinmentRepository = medicalAppoinmentRepository;
        }

        public async Task<List<MedicalViewModel>> GetAllViewModelWithInclude()
        {
            var medicalAppointments = await _medicalAppoinmentRepository.GetAllWithIncludeAsync(new List<string> { "Patient","Doctor", "AppoinmentStatus"});

            return medicalAppointments.Select(medical => new MedicalViewModel
            {
                Id = medical.Id,
                PatientName = medical.Patient.Name,
                DoctortName = medical.Doctor.Name,
                DateOfAppoinment = medical.DateOfAppoinment.ToString("yyyy-MM-dd"),
                HourOfAppoinment = medical.HourOfAppoinment,
                ReasonOfAppoinment = medical.ReasonOfAppoinment,
                IdPatient = medical.Patient.Id,
                IdDoctor = medical.Doctor.Id,
                StatustName = medical.AppoinmentStatus.Description,
                IdAppoinmentStatus = medical.AppoinmentStatus.Id,

            }).ToList();
        }
    }
}
