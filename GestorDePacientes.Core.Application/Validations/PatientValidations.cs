using GestorDePacientes.Core.Application.Interfaces.Services;
using System.ComponentModel.DataAnnotations;

namespace GestorDePacientes.Core.Application.Validations
{
    public class PatientValidations:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var patientServices = validationContext.GetService(typeof(IPatientService)) as IPatientService;
            var identification = (string)value;

            if (patientServices.Any(patient=> patient.Identification == identification))
            {
                return new ValidationResult("ESTA CEDULA YA ESTA EN USO, INGRESE OTRA DIFERENTE POR FAVOR");
            }
            return ValidationResult.Success;
        }
    }
}
