using Cto.Tutorial.CleanArchitecture.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cto.Tutorial.CleanArchitecture.Infrastructure.EntityConfiguration.Sales
{
   public class SalesOrderStatusEntityTypeConfiguration :
      IEntityTypeConfiguration<SalesOrderStatus>
   {
      public void Configure(EntityTypeBuilder<SalesOrderStatus> orderStatusConfiguration)
      {
         orderStatusConfiguration
            .ToTable("sales_orderstatus");

         orderStatusConfiguration
            .HasKey(o => o.Id);

         orderStatusConfiguration
            .Property(o => o.Id)
            .ValueGeneratedNever()
            .IsRequired();

         orderStatusConfiguration
            .Property(o => o.Name)
            .HasMaxLength(200)
            .IsRequired();
      }
   }
}