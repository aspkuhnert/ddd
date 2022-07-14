using Cto.Tutorial.CleanArchitecture.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.CleanArchitecture.Infrastructure
{
   public static class ModelBuilderExtenssions
   {
      //public static ModelBuilder CreateSalesModuleShadowProperties(this ModelBuilder builder)
      //{
      //   foreach (var entityType in builder.Model.GetEntityTypes())
      //   {
      //      builder.Entity(entityType.ClrType).Property<DateTime>("DateCreated");
      //      builder.Entity(entityType.ClrType).Property<DateTime>("DateUpdated");
      //   }

      //   return builder;
      //}

      public static ModelBuilder Seed(this ModelBuilder builder)
      {
         builder
            .Entity<SalesOrderStatus>()
            .HasData(
               new SalesOrderStatus(1, "Started"),
               new SalesOrderStatus(2, "AwaitingValidation"),
               new SalesOrderStatus(3, "StockConfirmed"),
               new SalesOrderStatus(4, "StockRejected"),
               new SalesOrderStatus(5, "PartlyDelivered"),
               new SalesOrderStatus(6, "Delivered"),
               new SalesOrderStatus(7, "PartlyInvoiced"),
               new SalesOrderStatus(8, "Invoiced"));

         return builder;
      }
    }
}
