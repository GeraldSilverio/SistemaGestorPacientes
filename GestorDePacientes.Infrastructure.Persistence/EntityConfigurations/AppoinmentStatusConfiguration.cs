using GestorDePacientes.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorDePacientes.Infrastructure.Persistence.EntityConfigurations
{
    public class AppoinmentStatusConfiguration : IEntityTypeConfiguration<AppoinmentStatus>
    {
        public void Configure(EntityTypeBuilder<AppoinmentStatus> builder)
        {
            builder.ToTable("AppoinmentStatus");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.LastModifiedBy).IsRequired(false);
            builder.Property(x => x.CreatyBy).IsRequired(false);
            //Datos que se crearan solos, asi no tendra que comenzar a crear estados de citas.
            builder.HasData(
                new AppoinmentStatus { Id = 1,Description= "PENDIENTE DE CONSULTA" },
                new AppoinmentStatus { Id = 2,Description= "PENDIENTE DE RESULTADOS" },
                new AppoinmentStatus { Id = 3,Description= "COMPLETADA" }
                );
        }
    }
}
