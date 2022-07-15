namespace Cto.Tutorial.CleanArchitecture.Application.Events
{
   public interface IDomainEventNotification<out TEventType> :
      IDomainEventNotification
   {
      TEventType DomainEvent { get; }
   }
}