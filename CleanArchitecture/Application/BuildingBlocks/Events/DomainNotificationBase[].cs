using Cto.Tutorial.CleanArchitecture.Domain.BuildingBlocks;

namespace Cto.Tutorial.CleanArchitecture.Application.Events
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