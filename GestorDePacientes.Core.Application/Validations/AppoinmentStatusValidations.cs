using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.Services;
using System.ComponentModel.DataAnnotations;

namespace GestorDePacientes.Core.Application.Validations
{
    public class AppoinmentStatusValidations : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var appoinmentService = validationContext.GetService(typeof(IAppoinmetStatusService)) as IAppoinmetStatusService;
            var description = (string)value;

            if (appoinmentService.Any(appoinment => appoinment.Description == description))
            {
                return new ValidationResult("ESTE ESTADO YA EXISTE");
            }

            return ValidationResult.Success;
        }
    }
}
