using GestorDePacientes.Core.Application.Interfaces.Services;
using System.ComponentModel.DataAnnotations;

namespace GestorDePacientes.Core.Application.Validations
{
    public class PatientIdentificationValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var patientServices = validationContext.GetService(typeof(IPatientService)) as IPatientService;
            var identification = (string)value;

            if (patientServices.ValidateIdentification(identification))
            {
                return new ValidationResult("ESTA CEDULA YA ESTA EN USO, INGRESE OTRA DIFERENTE POR FAVOR");
            }
            return ValidationResult.Success;
        }
    }
}
