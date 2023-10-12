using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDePacientes.Core.Application.ViewModels.RolViewModels
{
    public class SaveRolViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "ESTE CAMPO ES OBLIGATORIO")]
        public string Name { get; set; } = null!;
    }
}
