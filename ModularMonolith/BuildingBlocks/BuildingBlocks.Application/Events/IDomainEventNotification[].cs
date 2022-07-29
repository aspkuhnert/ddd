namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Application.Events
{
   public interface IDomainEventNotification<out TEventType> :
      IDomainEventNotification
   {
      TEventType DomainEvent { get; }
   }
}