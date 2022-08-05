using Cto.Tutorial.CleanArchitecture.BuildingBlocks.Domain;

namespace Cto.Tutorial.CleanArchitecture.Domain.Sales.Events
{
   public class SalesOrderCreatedDomainEvent :
      DomainEventBase
   {
      public Guid SalesOrderId { get; }

      public DateTime OrderDate { get; }

      public Address PlacingCustomer { get; }

      public SalesOrderCreatedDomainEvent(Guid id, DateTime orderDate, Address placingCustomer)
         : base()
      {
         SalesOrderId = id;
         OrderDate = orderDate;
         PlacingCustomer = placingCustomer;
      }
   }
}