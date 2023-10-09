using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDePacientes.Core.Application.Interfaces.Interfaces
{
    public interface IUploadFile
    {
        string UplpadFile(string file,int id);
    }
}
