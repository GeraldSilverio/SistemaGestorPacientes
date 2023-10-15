using System.ComponentModel.DataAnnotations;

namespace GestorDePacientes.Core.Application.ViewModels.LabTestViewModels
{
    public class SaveLabTestViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "DEBE COMPLETAR ESTE CAMPO")]
        public string Name { get; set; } = null!;
    }
}
