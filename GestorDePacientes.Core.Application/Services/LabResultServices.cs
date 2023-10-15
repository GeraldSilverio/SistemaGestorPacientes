using AutoMapper;
using GestorDePacientes.Core.Application.Interfaces.Repositories;
using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.ViewModels.LabResultViewModels;
using GestorDePacientes.Core.Application.ViewModels.MedicalViewModels;
using GestorDePacientes.Core.Domain.Entities;

namespace GestorDePacientes.Core.Application.Services
{
    public class LabResultServices : GenericService<SaveLabResultViewModel, LabResultViewModel, PatientLabTests>,ILabResultServices
    {
        public ILabResultRepository _labResultRepository { get; set; }
        public LabResultServices(IMapper mapper, ILabResultRepository labResultRepository) : base(mapper, labResultRepository)
        {
            _labResultRepository = labResultRepository;
        }

        public override async Task<SaveLabResultViewModel> Add(SaveLabResultViewModel viewModel)
        {
            var labResult = new List<PatientLabTests>();
            foreach (var idLab in viewModel.IdLabTest) 
            {
                var lab = new PatientLabTests()
                {
                    IdPatient = viewModel.IdPatient,
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

        public async Task<List<LabResultViewModel>> GetAllViewModelWithInclude()
        {
            var labResults = await _labResultRepository.GetAllWithIncludeAsync(new List<string> { "Patient", "LabTests" });

            var result =  labResults.Select(labResult => new LabResultViewModel
            {
                Id = labResult.Id,
                PatientName = labResult.Patient.Name + " " + labResult.Patient.LastName,
                PatientIdentification = labResult.Patient.Identification,
                LabTestName = labResult.LabTests.Name,
                IsCompleted = labResult.IsCompleted,
            }).Where(x => x.IsCompleted != true).ToList();

            return result;
        }
    }

}
