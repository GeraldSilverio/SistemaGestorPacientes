using GestorDePacientes.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDePacientes.Core.Application.Validations
{
    public class UserEmailValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var userServices = validationContext.GetService(typeof(IUserServices)) as IUserServices;
            var email = (string)value;

            if (userServices.ValidateEmail(email))
            {
                return new ValidationResult("ESTE EMAIL YA ESTA EN USO, INGRESE OTRO POR FAVOR");
            }

            return ValidationResult.Success;

        }
    }
}
