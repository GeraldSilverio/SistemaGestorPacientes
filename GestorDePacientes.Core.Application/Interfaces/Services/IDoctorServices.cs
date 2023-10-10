using GestorDePacientes.Core.Application.Interfaces.Interfaces;
using GestorDePacientes.Core.Application.ViewModels.DoctorViewModels;
using GestorDePacientes.Core.Domain.Entities;

namespace GestorDePacientes.Core.Application.Interfaces.Services
{
    public interface IDoctorServices:IGenericService<SaveDoctorViewModel,DoctorViewModel,Doctor>,IUploadFile
    {
    }
}
