using Cto.Tutorial.CleanArchitecture.Domain.Sales;
using Microsoft.EntityFrameworkCore;

namespace Cto.Tutorial.CleanArchitecture.Infrastructure
{
   public static class ModelBuilderExtenssions
   {
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
               new SalesOrderStatus(8, "Invoiced"),
               new SalesOrderStatus(9, "Copied"));

         return builder;
      }
   }
}