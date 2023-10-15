using GestorDePacientes.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorDePacientes.Infrastructure.Persistence.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.UserName).IsUnique();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.LastModifiedBy).IsRequired(false);
            builder.Property(x => x.CreatyBy).IsRequired(false);


            builder.HasOne(x=>x.Rol)
                .WithMany(x=>x.Users)
                .HasForeignKey(x=> x.IdRol)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
