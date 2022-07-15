using Cto.Tutorial.CleanArchitecture.Domain.Sales.Events;
using MediatR;

namespace Cto.Tutorial.CleanArchitecture.Application.DomainEventHandlers
{
   public class SalesOrderStartedDomainEventHandler :
      INotificationHandler<SalesOrderStartedDomainEvent>
   {
      public SalesOrderStartedDomainEventHandler()
      {
      }

      public async Task Handle(SalesOrderStartedDomainEvent notification, CancellationToken cancellationToken)
      {
         // TODO: add to event store db
      }
   }
}