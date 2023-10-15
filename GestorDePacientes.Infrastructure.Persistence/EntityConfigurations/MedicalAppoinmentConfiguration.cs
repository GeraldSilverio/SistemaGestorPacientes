using GestorDePacientes.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorDePacientes.Infrastructure.Persistence.EntityConfigurations
{
    public class MedicalAppoinmentConfiguration : IEntityTypeConfiguration<MedicalAppointment>
    {
        public void Configure(EntityTypeBuilder<MedicalAppointment> builder)
        {
            builder.ToTable("MedicalAppointment");
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.HourOfAppoinment).HasColumnType("time");
            builder.Property(x => x.LastModifiedBy).IsRequired(false);
            builder.Property(x => x.CreatyBy).IsRequired(false);


            //Relacion con el estado de la cita, cita tener un estado y un estado muchas citas.
            builder.HasOne(x => x.AppoinmentStatus)
                .WithMany(x => x.MedicalAppointments)
                .HasForeignKey(x => x.IdAppoinmentStatus)
                .OnDelete(DeleteBehavior.Cascade);

            //Relacion con Patient, una cita tiene un paciente y un paciente muchas citas.

            builder.HasOne(x=> x.Patient)
                .WithMany(x=> x.MedicalAppointments)
                .HasForeignKey(x=> x.IdPatient)
                .OnDelete(DeleteBehavior.Cascade);

            //Relacion con Patient, una cita tiene un doctor y un doctor muchas citas.

            builder.HasOne(x => x.Doctor)
                .WithMany(x => x.MedicalAppointments)
                .HasForeignKey(x => x.IdDoctor)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
