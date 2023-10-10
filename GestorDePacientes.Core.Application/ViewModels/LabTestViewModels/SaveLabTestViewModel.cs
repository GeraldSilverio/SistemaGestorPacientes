using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDePacientes.Core.Application.ViewModels.LabTestViewModels
{
    public class SaveLabTestViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "DEBE COMPLETAR ESTE CAMPO")]
        public string Name { get; set; } = null!;
    }
}
