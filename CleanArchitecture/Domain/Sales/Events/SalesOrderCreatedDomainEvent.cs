using Cto.Tutorial.CleanArchitecture.Domain.BuildingBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.CleanArchitecture.Domain.Sales.Events
{
   public class SalesOrderCreatedDomainEvent :
      DomainEventBase
   {
      public Guid SalesOrderId { get; }

      public string OrderNumber { get; }

      public Address Address { get; }

      public SalesOrderCreatedDomainEvent(Guid id, string orderNumber, Address address)
         : base()
      {
         SalesOrderId = id;
         OrderNumber = orderNumber;
         Address = address;
      }
   }
}
