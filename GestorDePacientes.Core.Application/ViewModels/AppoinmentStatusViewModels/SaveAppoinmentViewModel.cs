using GestorDePacientes.Core.Application.Validations;
using System.ComponentModel.DataAnnotations;

namespace GestorDePacientes.Core.Application.ViewModels.AppoinmentStatusViewModels
{
    public class SaveAppoinmentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="ESTE CAMPO ES OBLIGATORIO")]
        [AppoinmentStatusValidations]
        public string Description { get; set; } = null!;
    }
}
