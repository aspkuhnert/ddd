using Cto.Tutorial.CleanArchitecture.Domain.BuildingBlocks;

namespace Cto.Tutorial.CleanArchitecture.Domain.Sales.Events
{
   public class SalesOrderCreatedDomainEvent :
      DomainEventBase
   {
      public Guid SalesOrderId { get; }

      public DateTime OrderDate { get; }

      public string OrderNumber { get; }

      public Address PlacingCustomer { get; }

      public List<SalesOrderItem> Items { get; }

      public SalesOrderCreatedDomainEvent(Guid id, DateTime orderDate, string orderNumber, Address placingCustomer, List<SalesOrderItem> items)
         : base()
      {
         SalesOrderId = id;
         OrderDate = orderDate;
         OrderNumber = orderNumber;
         PlacingCustomer = placingCustomer;
         Items = items;
      }
   }
}