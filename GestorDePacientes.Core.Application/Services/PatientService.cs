using AutoMapper;
using GestorDePacientes.Core.Application.Interfaces.Repositories;
using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.ViewModels.PatientViewModels;
using GestorDePacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDePacientes.Core.Application.Services
{
    public class PatientService : GenericService<SavePatientViewModel, PatientViewModel, Patient>, IPatientService
    {
        public PatientService(IMapper mapper, IGenericRepositoryAsync<Patient> repositoryAsync) : base(mapper, repositoryAsync)
        {
        }
    }
}
