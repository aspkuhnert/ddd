using Cto.Tutorial.Domain.Seedwork;

namespace Cto.Tutorial.Domain.Orders
{
   public class SalesOrderItem :
      EntityBase
   {
      public Guid Id { get; private set; }

      public Guid ProductId { get; private set; }

      public decimal QuantityOrdered { get; private set; }

      public Money UnitPrice { get; private set; }

      public Money NetPrice { get; private set; }

      protected SalesOrderItem()
      {
         Id = Guid.NewGuid();
         QuantityOrdered = 1;
      }

      private SalesOrderItem(Guid productId)
         : this()
      {
         ProductId = productId;
      }

      public static SalesOrderItem Create(Guid productId)
      {
         return new SalesOrderItem(productId);
      }
   }
}