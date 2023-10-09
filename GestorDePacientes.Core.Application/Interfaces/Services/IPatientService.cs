using GestorDePacientes.Core.Application.ViewModels.PatientViewModels;
using GestorDePacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDePacientes.Core.Application.Interfaces.Services
{
    public interface IPatientService:IGenericService<SavePatientViewModel,PatientViewModel,Patient>
    {
    }
}
