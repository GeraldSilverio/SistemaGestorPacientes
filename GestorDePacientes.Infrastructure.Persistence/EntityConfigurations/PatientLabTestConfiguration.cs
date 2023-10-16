using GestorDePacientes.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace GestorDePacientes.Infrastructure.Persistence.EntityConfigurations
{
    public class PatientLabTestConfiguration : IEntityTypeConfiguration<PatientLabTests>
    {
        public void Configure(EntityTypeBuilder<PatientLabTests> builder)
        {
            builder.ToTable("PatientLabTests");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.LastModifiedBy).IsRequired(false);
            builder.Property(x => x.CreatyBy).IsRequired(false);
            builder.Property(x => x.Comments).IsRequired(false);

            builder.HasOne(x => x.Patient)
                .WithMany(x => x.PatientLabTests)
                .HasForeignKey(x => x.IdPatient)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.LabTests)
                .WithMany(x => x.PatientLabTests)
                .HasForeignKey(x => x.IdLabTests)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(x => x.MedicalAppointment)
            .WithMany(x => x.PatientLabTests)
            .HasForeignKey(x => x.IdMedicalAppoinment)
            .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
