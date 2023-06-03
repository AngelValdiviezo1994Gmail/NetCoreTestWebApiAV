using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTest.Application.Features.Clientes.Interfaces;
using WebApiTest.Domain.Entities;

namespace WebApiTest.Persistence.Configurations
{
    public class FeatureConfiguration : IEntityTypeConfiguration<Features>
    {
        //Relaciona el feature con los archivos adjuntos
        public void Configure(EntityTypeBuilder<Features> builder)
        {

            builder.HasKey(x => x.Id);

            builder.HasMany(g => g.archivosAdjuntos)
              .WithOne(g => g.objFeatures)
              .HasForeignKey(g => g.IdFeature)
              .IsRequired()
              .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
