using GestorDePacientes.Core.Application.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;

namespace GestorDePacientes.Core.Application.Validations
{
    public class RolValidations : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var rolServices = validationContext.GetService(typeof(IRolServices)) as IRolServices;

            var name = (string)value;

            if (rolServices.Any(rol => rol.Name == name))
            {
                return new ValidationResult("ESTE ROL YA ESTA EXISTE");
            }

            return ValidationResult.Success;

        }
    }
}
