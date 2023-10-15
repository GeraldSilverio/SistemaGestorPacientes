using AutoMapper;
using GestorDePacientes.Core.Application.Interfaces.Repositories;
using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.ViewModels.AppoinmentStatusViewModels;
using GestorDePacientes.Core.Domain.Entities;

namespace GestorDePacientes.Core.Application.Services
{
    public class AppoinmentStatusService : GenericService<SaveAppoinmentViewModel, AppoinmentStatusViewModel, AppoinmentStatus>,IAppoinmetStatusService
    {
        private readonly IAppoinmentStatusRepository _appoinmentStatusRepository;
        public AppoinmentStatusService(IMapper mapper, IAppoinmentStatusRepository appoinmentStatusRepository) : base(mapper, appoinmentStatusRepository)
        {
            _appoinmentStatusRepository = appoinmentStatusRepository;
        }

        public async Task<int> GetAppoinmetIdbyName(string name)
        {
            var id = await _appoinmentStatusRepository.GetAppoinmetIdbyName(name);
            return id;
        }
    }
}
