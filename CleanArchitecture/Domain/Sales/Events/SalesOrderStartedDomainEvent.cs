﻿using Cto.Tutorial.CleanArchitecture.BuildingBlocks.Domain;

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