using Cto.Tutorial.CleanArchitecture.Domain.BuildingBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.CleanArchitecture.Domain.Sales.Events
{
   public class SalesOrderStartedDomainEvent :
      DomainEventBase
   {
      public Guid SalesOrderId { get; }

      public SalesOrderStartedDomainEvent(Guid id)
         : base()
      {
         SalesOrderId = id;
      }
   }
}
