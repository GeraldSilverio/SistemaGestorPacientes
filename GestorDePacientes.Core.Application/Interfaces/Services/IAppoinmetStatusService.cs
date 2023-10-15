using GestorDePacientes.Core.Application.ViewModels.AppoinmentStatusViewModels;
using GestorDePacientes.Core.Domain.Entities;

namespace GestorDePacientes.Core.Application.Interfaces.Services
{
    public interface IAppoinmetStatusService:IGenericService<SaveAppoinmentViewModel,AppoinmentStatusViewModel,AppoinmentStatus>
    {
        Task<int> GetAppoinmetIdbyName(string name);
    }
}
