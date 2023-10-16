﻿using GestorDePacientes.Core.Application.Interfaces.Services;
using System.ComponentModel.DataAnnotations;

namespace GestorDePacientes.Core.Application.Validations
{
    public class UserNameValidation:ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var userServices = validationContext.GetService(typeof(IUserServices)) as IUserServices;
            var userName = (string)value;

            if (userServices.ValidateUserName(userName))
            {
                return new ValidationResult("ESTE NOMBRE DE USUARIO ESTA EN USO, INGRESE OTRO POR FAVOR.");
            }

            return ValidationResult.Success;

        }
    }
}
