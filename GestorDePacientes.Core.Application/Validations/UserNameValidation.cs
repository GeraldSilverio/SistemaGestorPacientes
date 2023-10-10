﻿using GestorDePacientes.Core.Application.Interfaces.Services;
using GestorDePacientes.Core.Application.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return new ValidationResult("El nombre de usuario que has ingresado ya está en uso. Por favor, elige otro nombre de usuario.");
            }

            return ValidationResult.Success;

        }
    }
}