using GestorDePacientes.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorDePacientes.Infrastructure.Persistence.EntityConfigurations
{
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("Rol");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.LastModifiedBy).IsRequired(false);
            builder.Property(x => x.CreatyBy).IsRequired(false);

        }
    }
}
