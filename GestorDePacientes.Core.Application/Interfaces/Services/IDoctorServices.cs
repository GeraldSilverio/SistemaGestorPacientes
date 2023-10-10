using GestorDePacientes.Core.Application.Interfaces.Interfaces;
using GestorDePacientes.Core.Application.ViewModels.DoctorViewModels;
using GestorDePacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDePacientes.Core.Application.Interfaces.Services
{
    public interface IDoctorServices:IGenericService<SaveDoctorViewModel,DoctorViewModel,Doctor>,IUploadFile
    {
    }
}
