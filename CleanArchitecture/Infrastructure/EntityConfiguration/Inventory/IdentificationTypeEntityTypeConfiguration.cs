using Cto.Tutorial.CleanArchitecture.Domain.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.CleanArchitecture.Infrastructure.EntityConfiguration.Inventory
{
   public class IdentificationTypeEntityTypeConfiguration :
      IEntityTypeConfiguration<IdentificationType>
   {
      public void Configure(EntityTypeBuilder<IdentificationType> typeConfiguration)
      {
         typeConfiguration
            .ToTable("inventory_identification_types");

         typeConfiguration
            .HasKey(entity => entity.Id);

         typeConfiguration.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .IsRequired();
      }
   }
}
