namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Infrastructure.EventBus
{
   public interface IIntegrationEventHandler<in TIntegrationEvent> :
      IIntegrationEventHandler
      where TIntegrationEvent : IntegrationEvent
   {
      Task Handle(TIntegrationEvent integrationEvent);
   }
}