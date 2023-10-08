﻿using GestorDePacientes.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDePacientes.Core.Domain.Entities
{
    public class Doctor:AuditableBaseEntity
    {
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Identification { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;

        //Relacion con tabla MedicalAppoinment
        public ICollection<MedicalAppointment> MedicalAppointments { get; set; } = null!;
    }
}