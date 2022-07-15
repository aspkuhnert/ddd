using Cto.Tutorial.CleanArchitecture.Domain.BuildingBlocks;

namespace Cto.Tutorial.CleanArchitecture.Domain.Sales
{
   public class SalesOrderStatus :
      Enumeration
   {
      public static SalesOrderStatus Started = new SalesOrderStatus(1, nameof(Started).ToLowerInvariant());

      public static SalesOrderStatus AwaitingStockValidation = new SalesOrderStatus(2, nameof(AwaitingStockValidation).ToLowerInvariant());

      public static SalesOrderStatus StockConfirmed = new SalesOrderStatus(3, nameof(StockConfirmed).ToLowerInvariant());

      public static SalesOrderStatus StockRejected = new SalesOrderStatus(4, nameof(StockRejected).ToLowerInvariant());

      public static SalesOrderStatus PartlyDelivered = new SalesOrderStatus(5, nameof(PartlyDelivered).ToLowerInvariant());

      public static SalesOrderStatus Delivered = new SalesOrderStatus(6, nameof(Delivered).ToLowerInvariant());

      public static SalesOrderStatus PartlyInvoiced = new SalesOrderStatus(7, nameof(PartlyInvoiced).ToLowerInvariant());

      public static SalesOrderStatus Invoiced = new SalesOrderStatus(8, nameof(Invoiced).ToLowerInvariant());

      public static SalesOrderStatus Copied = new SalesOrderStatus(9, nameof(Copied).ToLowerInvariant());

      public SalesOrderStatus(int id, string name)
         : base(id, name)
      {
      }

      public static IEnumerable<SalesOrderStatus> List() =>
         new[] { Started, AwaitingStockValidation, StockConfirmed, PartlyDelivered, Delivered, PartlyInvoiced, Invoiced, Copied };
   }
}