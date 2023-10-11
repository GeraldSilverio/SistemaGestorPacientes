using System.ComponentModel.DataAnnotations;

namespace GestorDePacientes.Core.Application.ViewModels.AppoinmentStatusViewModels
{
    public class SaveAppoinmentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="ESTE CAMPO ES OBLIGATORIO")]
        public string Description { get; set; } = null!;
    }
}
