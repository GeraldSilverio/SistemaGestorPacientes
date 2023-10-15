namespace GestorDePacientes.Core.Application.ViewModels.UserViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public int IdRol { get; set; }
        public string RolName { get; set; } = null!;

    }
}
