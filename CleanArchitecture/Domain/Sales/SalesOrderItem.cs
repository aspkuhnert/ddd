using Cto.Tutorial.CleanArchitecture.BuildingBlocks.Domain;

namespace Cto.Tutorial.CleanArchitecture.Domain.Sales
{
   public class SalesOrderItem :
      EntityBase
   {
      public Guid Id { get; private set; }

      public Guid ProductId { get; private set; }

      public string ProductName { get; private set; }

      public string OrderCurrency { get; private set; }

      public decimal QuantityOrdered { get; private set; }

      public Money UnitPrice { get; private set; }

      public Money NetPrice { get; private set; }
      
      private SalesOrderItem()
      {
         Id = Guid.NewGuid();
         QuantityOrdered = 1;
      }

      private SalesOrderItem(string currency)
         : this()
      {
         OrderCurrency = currency;
      }

      private SalesOrderItem(Guid productId, string currency)
         : this(currency)
      {
         ProductId = productId;
      }

      public static SalesOrderItem Create(Guid productId, string productName, decimal unitPrice, decimal quantityOrdered, string currency)
      {
         var item = new SalesOrderItem(productId, currency);

         item.ProductName = productName;
         var unitPriceMoney = Money.Of(unitPrice, currency);
         item.UnitPrice = unitPriceMoney;
         item.QuantityOrdered = quantityOrdered;

         return item;
      }

      public SalesOrderItem Calculate()
      {
         NetPrice = Money.Of((decimal)UnitPrice.Value * QuantityOrdered, OrderCurrency);

         return this;
      }

      protected override void Apply(IDomainEvent @event)
      {
         throw new NotImplementedException();
      }
   }
}