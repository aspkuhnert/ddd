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
   public class CatalogItemEntityTypeConfiguration :
      IEntityTypeConfiguration<CatalogItem>
   {
      public void Configure(EntityTypeBuilder<CatalogItem> builder)
      {
         builder
            .ToTable("inventory_catalogitems");

         builder
            .HasKey(entity => entity.Id);

         builder
            .Ignore(entity => entity.DomainEvents);

         builder
            .Property(entity => entity.Version)
            .IsRequired()
            .HasColumnName("Version");
      }
   }
}
