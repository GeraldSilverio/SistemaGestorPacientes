using Microsoft.AspNetCore.Http;

namespace GestorDePacientes.Core.Application.Interfaces.Interfaces
{
    public interface IUploadFile
    {
        string UplpadFile(IFormFile file, int id, bool isEditMode = false, string imagePath = "");
    }
}
