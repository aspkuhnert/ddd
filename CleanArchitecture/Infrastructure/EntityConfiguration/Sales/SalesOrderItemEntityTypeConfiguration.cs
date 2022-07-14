using Cto.Tutorial.CleanArchitecture.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.CleanArchitecture.Infrastructure.EntityConfiguration.Sales
{
   public class SalesOrderItemEntityTypeConfiguration :
      IEntityTypeConfiguration<SalesOrderItem>
   {
      public void Configure(EntityTypeBuilder<SalesOrderItem> itemConfiguration)
      {
         itemConfiguration
            .ToTable("sales_orderitems");

         itemConfiguration
            .HasKey(entity => entity.Id);

         itemConfiguration
            .Ignore(entity => entity.DomainEvents);

         itemConfiguration
            .Property<Guid>("SalesOrderId")
            .IsRequired();

         itemConfiguration
            .Property<DateTime>("DateCreated")
            .HasDefaultValue(DateTime.Now);

         itemConfiguration
            .Property<DateTime>("DateUpdated")
            .HasDefaultValue(DateTime.Now);

         itemConfiguration
            .OwnsOne(o => o.NetPrice, b =>
            {
               b.Property(p => p.Value)
                  .HasColumnName("NetPriceAmount")
                  .HasPrecision(6, 2);
               b.Property(p => p.Currency)
                  .HasColumnName("NetPriceCurrencyCode")
                  .HasColumnType("char")
                  .HasMaxLength(3);
            });

         itemConfiguration
            .OwnsOne(o => o.UnitPrice, b =>
            {
               b.Property(p => p.Value)
                  .HasColumnName("UnitPriceAmount")
                  .HasPrecision(6, 2);
               b.Property(p => p.Currency)
                  .HasColumnName("UnitPriceCurrencyCode")
                  .HasColumnType("char")
                  .HasMaxLength(3);
            });
      }
   }
}
