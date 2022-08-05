namespace Cto.Tutorial.CleanArchitecture.BuildingBlocks.Application.Events
{
   public interface IDomainEventNotification<out TEventType> :
      IDomainEventNotification
   {
      TEventType DomainEvent { get; }
   }
}