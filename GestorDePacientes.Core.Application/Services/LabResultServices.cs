using AutoMapper;
using GestorDePacientes.Core.Application.Interfaces.Repositories;
using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.ViewModels.LabResultViewModels;
using GestorDePacientes.Core.Domain.Entities;

namespace GestorDePacientes.Core.Application.Services
{
    public class LabResultServices : GenericService<SaveLabResultViewModel, LabResultViewModel, PatientLabTests>,ILabResultServices
    {
        public readonly ILabResultRepository _labResultRepository;
        public readonly IMedicalAppoinmentService _medicalService;
        public LabResultServices(IMapper mapper, ILabResultRepository labResultRepository, IMedicalAppoinmentService medicalService) : base(mapper, labResultRepository)
        {
            _labResultRepository = labResultRepository;
            _medicalService = medicalService;
        }

        public override async Task<SaveLabResultViewModel> Add(SaveLabResultViewModel viewModel)
        {
            //Busco la cita creada para tener el Id del paciente de esa cita.
            var medicalCreated = await _medicalService.GetById(viewModel.IdMedicalAppoinment);

            var labResult = new List<PatientLabTests>();
            foreach (var idLab in viewModel.IdLabTest) 
            {
                var lab = new PatientLabTests()
                {
                    IdMedicalAppoinment = viewModel.IdMedicalAppoinment,
                    IdPatient = medicalCreated.IdPatient,
                    IdLabTests = idLab,
                    IsCompleted = false,
                };
                labResult.Add(lab);
            }

            foreach(var labTest in labResult)
            {
                await _labResultRepository.AddAsync(labTest);
            }
            return viewModel;
        }

        public async Task DeleteByIdAppoinment(int id)
        {
            await _labResultRepository.DeleteByIdAppoinment(id);
        }

        public async Task<List<LabResultViewModel>> GetByFiltersAsync(FilterLabResultViewModel filter)
        {
            var labResults = await _labResultRepository.GetAllWithIncludeAsync(new List<string> { "Patient", "LabTests", "MedicalAppointment" });

            var result = labResults.Select(labResult => new LabResultViewModel
            {
                Id = labResult.Id,
                PatientName = labResult.Patient.Name + " " + labResult.Patient.LastName,
                PatientIdentification = labResult.Patient.Identification,
                LabTestName = labResult.LabTests.Name,
                IsCompleted = labResult.IsCompleted,
                IdMedicalAppoinment = labResult.MedicalAppointment.Id
                
            }).Where(x => x.IsCompleted != true).ToList();
            

            if (filter.Identification != null)
            {
                result = result.Where(s => s.PatientIdentification.ToLower() == filter.Identification.ToLower()).ToList();
            }

            return result;
        }

        public async Task<List<LabResultViewModel>> GetByIdAppoinment(int id)
        {
            var labResults = await _labResultRepository.GetAllWithIncludeAsync(new List<string> { "Patient", "LabTests", "MedicalAppointment" });

            var result = labResults.Select(labResult => new LabResultViewModel
            {
                Id = labResult.Id,
                LabTestName = labResult.LabTests.Name,
                IsCompleted = labResult.IsCompleted,
                IdMedicalAppoinment = labResult.MedicalAppointment.Id

            }).Where(x => x.IdMedicalAppoinment == id).ToList();

            return result;
        }
    }

}
