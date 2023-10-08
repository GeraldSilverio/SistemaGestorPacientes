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
    public class LabTestConfiguration : IEntityTypeConfiguration<LabTests>
    {
        public void Configure(EntityTypeBuilder<LabTests> builder)
        {
            builder.ToTable("LabTests");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.LastModifiedBy).IsRequired(false);
            builder.Property(x => x.CreatyBy).IsRequired(false);





        }
    }
}
