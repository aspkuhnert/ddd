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
   public class IdentificationValueEntityTypeConfiguration :
      IEntityTypeConfiguration<IdentificationValue>
   {
      public void Configure(EntityTypeBuilder<IdentificationValue> valueConfiguration)
      {
         valueConfiguration
            .ToTable("inventory_identification_values");

         valueConfiguration
            .HasKey(entity => new
            {
               entity.CatalogItemId,
               entity.IdentificationTypeId
            });

         valueConfiguration
            .HasOne(entity => entity.Type)
            .WithMany()
            .HasForeignKey(entity => entity.IdentificationTypeId);
      }
   }
}
