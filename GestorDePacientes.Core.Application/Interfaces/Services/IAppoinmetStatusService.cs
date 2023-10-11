using GestorDePacientes.Core.Application.ViewModels.AppoinmentStatusViewModels;
using GestorDePacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDePacientes.Core.Application.Interfaces.Services
{
    public interface IAppoinmetStatusService:IGenericService<SaveAppoinmentViewModel,AppoinmentStatusViewModel,AppoinmentStatus>
    {
    }
}
