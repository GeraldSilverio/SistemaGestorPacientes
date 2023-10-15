using GestorDePacientes.Core.Application.ViewModels.MedicalViewModels;
using GestorDePacientes.Core.Domain.Entities;

namespace GestorDePacientes.Core.Application.Interfaces.Services
{
    public interface IMedicalAppoinmentService:IGenericService<SaveMedicalViewModel,MedicalViewModel,MedicalAppointment>
    {
        Task<List<MedicalViewModel>> GetAllViewModelWithInclude();
    }
}
