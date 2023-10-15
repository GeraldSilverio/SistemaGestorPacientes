using System.ComponentModel.DataAnnotations;

namespace GestorDePacientes.Core.Application.ViewModels.RolViewModels
{
    public class SaveRolViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "ESTE CAMPO ES OBLIGATORIO")]
        public string Name { get; set; } = null!;
    }
}
