using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDePacientes.Core.Application.ViewModels.PatientViewModels
{
    public class SavePatientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Identification { get; set; } = null!;
        public DateTime DateOfBorn { get; set; } =DateTime.Now;
        public string Direction { get; set; } = null!;

        [DataType(DataType.Upload)]
        public IFormFile File { get; set; } = null!;
        public string ImageUrl { get; set; }
        public bool IsSmoker { get; set; }
        public bool IsAllegier { get; set; }
    }
}
