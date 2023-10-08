using GestorDePacientes.Core.Domain.Entities;
using GestorDePacientes.Infrastructure.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDePacientes.Infrastructure.Persistence.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RolConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new LabTestConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new PatientLabTestConfiguration());
            modelBuilder.ApplyConfiguration(new AppoinmentStatusConfiguration());
            modelBuilder.ApplyConfiguration(new MedicalAppoinmentConfiguration());
        }

        //Dbsets.
        public DbSet<Rol> Rol { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<LabTests> LabTests { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientLabTests> PatientLabTests { get; set; }
        public DbSet<AppoinmentStatus> AppoinmentStatuses { get; set; }
        public DbSet<MedicalAppointment> MedicalAppoinments { get; set; }
    }
}
