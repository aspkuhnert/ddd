namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Infrastructure.Integration.Outbox
{
   public abstract class OutboxMessageBase
   {
      public Guid Id { get; }

      public DateTime OccurredOn { get; }

      public string ServiceType { get; }

      public string ImplementationType { get; }

      public string Data { get; }

      public DateTime? ProcessedOn { get; }

      protected OutboxMessageBase(Guid id, DateTime occurredOn, string serviceType, string implementationType, string data)
      {
         Id = id;
         OccurredOn = occurredOn;
         ServiceType = serviceType;
         ImplementationType = implementationType;
         Data = data;
      }

      protected OutboxMessageBase()
      {
      }
   }
}