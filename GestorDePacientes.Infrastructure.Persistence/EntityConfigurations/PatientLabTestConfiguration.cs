using GestorDePacientes.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDePacientes.Infrastructure.Persistence.EntityConfigurations
{
    public class PatientLabTestConfiguration : IEntityTypeConfiguration<PatientLabTests>
    {
        public void Configure(EntityTypeBuilder<PatientLabTests> builder)
        {
            builder.ToTable("PatientLabTests");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Patient)
                .WithMany(x => x.PatientLabTests)
                .HasForeignKey(x => x.IdPatient)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x=> x.LabTests)
                .WithMany(x=> x.PatientLabTests)
                .HasForeignKey(x=> x.IdLabTests)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
