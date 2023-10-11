using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDePacientes.Core.Application.ViewModels.AppoinmentStatusViewModels
{
    public class AppoinmentStatusViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
    }
}
