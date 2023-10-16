using GestorDePacientes.Core.Application.Interfaces.Interfaces;
using GestorDePacientes.Core.Application.ViewModels.PatientViewModels;
using GestorDePacientes.Core.Domain.Entities;

namespace GestorDePacientes.Core.Application.Interfaces.Services
{
    public interface IPatientService : IGenericService<SavePatientViewModel, PatientViewModel, Patient>,IUploadFile
    {
        bool ValidateIdentification(string identification);
    }


}
