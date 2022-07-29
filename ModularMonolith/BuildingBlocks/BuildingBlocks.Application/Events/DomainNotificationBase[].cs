using Cto.Tutorial.ModularMonolith.BuildingBlocks.Domain;

namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Application.Events
{
   public class DomainNotificationBase<TEvent> :
      IDomainEventNotification<TEvent>
      where TEvent : IDomainEvent
   {
      public TEvent DomainEvent { get; }

      public Guid Id { get; }

      public DomainNotificationBase(TEvent domainEvent, Guid id)
      {
         Id = id;
         DomainEvent = domainEvent;
      }
   }
}