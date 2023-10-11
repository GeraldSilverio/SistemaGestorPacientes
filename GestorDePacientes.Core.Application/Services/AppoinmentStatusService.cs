using AutoMapper;
using GestorDePacientes.Core.Application.Interfaces.Repositories;
using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.ViewModels.AppoinmentStatusViewModels;
using GestorDePacientes.Core.Domain.Entities;

namespace GestorDePacientes.Core.Application.Services
{
    public class AppoinmentStatusService : GenericService<SaveAppoinmentViewModel, AppoinmentStatusViewModel, AppoinmentStatus>,IAppoinmetStatusService
    {
        public AppoinmentStatusService(IMapper mapper, IAppoinmentStatusRepository appoinmentStatusRepository) : base(mapper, appoinmentStatusRepository)
        {
        }
    }
}
