using Cto.Tutorial.CleanArchitecture.Domain.Sales.Events;
using MediatR;

namespace Cto.Tutorial.CleanArchitecture.Application.DomainEventHandlers
{
   public class SalesOrderCreatedDomainEventHandler :
   INotificationHandler<SalesOrderCreatedDomainEvent>
   {
      public SalesOrderCreatedDomainEventHandler()
      {
      }

      public async Task Handle(SalesOrderCreatedDomainEvent notification, CancellationToken cancellationToken)
      {
         // TODO: add to event store db
      }
   }
}